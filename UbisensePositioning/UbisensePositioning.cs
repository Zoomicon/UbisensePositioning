//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: UbisensePositioning.cs
//Version: 20151110

//Based on Ubisense SDK's ObjectPosition sample

using System.Collections.Generic;
using System.ComponentModel;
using Ubisense.UBase;
using Ubisense.ULocation;
using Ubisense.UName.Naming;

namespace Ubisense.Positioning
{
  //TODO: implement IDisposable and call into a protected ReleaseUbisense method

  public class UbisensePositioning
  {
    #region --- Fields ---

    protected Schema namingSchema;
    protected MultiCell multicell;
    protected SortedDictionary<string, UObject> objects = new SortedDictionary<string, UObject>(); //using an empty dictionary at start
    protected UObject? selectedObject; //=null
    protected bool initialized; //=false

    #endregion --- Fields ---

    #region --- Initialization ---

    public UbisensePositioning()
    {
    }

    public void Initialize() //TODO: add InitializeAsync (but make sure other async methods don't call the Async version)
    {
      if (initialized) return;

      // Instantiate the schema objects
      multicell = new MultiCell();
      namingSchema = new Schema(false);

      // Load all the available cells
      foreach (var cellInfo in multicell.GetAvailableCells())
        multicell.LoadCell(cellInfo.Value, true); // Load the cells

      // Connect the naming schema
      namingSchema.ConnectAsClient();

      // Initialize objects and selectedObject
      objects = new SortedDictionary<string, UObject>(); //using an empty dictionary
      selectedObject = null;

      initialized = true;
    }

    public void CheckInitialized()
    {
      if (!initialized)
        Initialize();
    }

    #endregion --- Initialization ---

    #region --- Properties ---

    public bool Initialized
    {
      get { return initialized; }
    }

    public SortedDictionary<string, UObject> Objects
    {
      get { return objects; }
    }

    public UObject? SelectedObject
    {
      get { return selectedObject; }
      set { selectedObject = value; }
    }

    #endregion --- Properties ---

    #region --- Methods ---

    #region GetObjects

    public SortedDictionary<string, UObject> GetObjects()
    {
      if (!initialized) Initialize();

      SortedDictionary<string, UObject> result = new SortedDictionary<string, UObject>();
      using (ReadTransaction xact = namingSchema.ReadTransaction())
        foreach (ObjectName.RowType row in ObjectName.object_name_(xact))
          result.Add(row.name_, row.object_);
      return result;
    }

    public void GetObjectsAsync()
    {
      BackgroundWorker getObjectsAsyncWorker = new BackgroundWorker();
      getObjectsAsyncWorker.DoWork += GetObjectsAsyncWorker_DoWork;
      getObjectsAsyncWorker.RunWorkerCompleted += GetObjectsAsyncWorker_Completed;
      getObjectsAsyncWorker.RunWorkerAsync();
    }

    private void GetObjectsAsyncWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      objects = GetObjects();
    }

    private void GetObjectsAsyncWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
      if (GetObjectsCompleted != null)
        GetObjectsCompleted(this, objects);
    }

    #endregion GetObjects

    #region GetPosition

    public Position? GetPosition()
    {
      return GetPosition(selectedObject.Value); //called method can handle null value
    }

    public Position? GetPosition(UObject obj) //note: have to use full namespace below, since different ReadTransaction classes are defined at various Ubisense namespaces
    {
      if (obj != null)
      {
        CheckInitialized();

        // Iterate over the Location relation to find the obj's position
        using (Ubisense.ULocation.CellData.ReadTransaction xact = multicell.Schema.ReadTransaction())
          foreach (Ubisense.ULocation.CellData.Location.RowType r in Ubisense.ULocation.CellData.Location.object_(xact, obj))
            return r.position_;
      }

      return null;
    }

    #endregion GetPosition

    #region SetPosition

    public bool SetPosition(double x, double y = 0.0, double z = 0.0, double theta = 0.0)
    {
      return SetPosition(selectedObject.Value, x, y, z, theta); //called method can handle null value
    }

    public bool SetPosition(UObject obj, double x, double y = 0.0, double z = 0.0, double theta = 0.0)
    {
      if (obj != null)
      {
        CheckInitialized();
        return multicell.SetObjectLocation(obj, new Position(x, y, z, theta));
      }
      else
        return false;
    }

    #endregion SetPosition

    #region RemovePosition

    public bool RemovePosition()
    {
      return RemovePosition(selectedObject.Value); //called method can handle null value
    }

    public bool RemovePosition(UObject obj)
    {
      if (obj != null)
      {
        CheckInitialized();
        return multicell.RemoveObjectLocation(obj);
      }
      else
        return false;
    }

    #endregion RemovePosition

    #endregion --- Methods ---

    #region --- Events ---

    public delegate void GetObjectsCompletedEventHandler(object sender, SortedDictionary<string, UObject> objects);

    public event GetObjectsCompletedEventHandler GetObjectsCompleted;

    #endregion --- Events ---
  }
}