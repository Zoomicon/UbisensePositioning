//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: UbisensePositioning.cs
//Version: 20151203

//Based on Ubisense SDK's ObjectPosition and DetectButtonPresses samples

using System.Collections.Generic;
using System.ComponentModel;
using Ubisense.UBase;
using Ubisense.ULocation;

namespace Ubisense.Positioning
{
  //TODO: implement IDisposable and call into a protected ReleaseUbisense method

  public class UbisensePositioning
  {
    #region --- Fields ---

    protected Ubisense.UName.Naming.Schema namingSchema;
    protected Ubisense.UData.Data.Schema dataSchema;
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

      InitializePositioning();
      InitializeButtons();

      initialized = true;
    }

    protected void InitializePositioning()
    {
      // Instantiate the schema objects
      multicell = new MultiCell();
      namingSchema = new Ubisense.UName.Naming.Schema(false); //note: there are different Schema classes in other namespaces

      // Load all the available cells
      foreach (var cellInfo in multicell.GetAvailableCells())
        multicell.LoadCell(cellInfo.Value, true); // Load the cells

      // Connect the naming schema
      namingSchema.ConnectAsClient();

      // Initialize objects and selectedObject
      objects = new SortedDictionary<string, UObject>(); //using an empty dictionary
      selectedObject = null;
    }

    protected void InitializeButtons()
    {
      dataSchema = new Ubisense.UData.Data.Schema(true); //note: there are different Schema classes in other namespaces

      // Connect to the data schema
      dataSchema.ConnectAsClient();

      // Add an insert event handler to detect the addition of new rows
      Ubisense.UData.Data.ObjectButtonPressed.AddInsertHandler(dataSchema, OnButton);

      // Add an update event handler to detect updates of existing rows
      Ubisense.UData.Data.ObjectButtonPressed.AddUpdateHandler(dataSchema, OnButton);
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
      using (Ubisense.UName.Naming.ReadTransaction xact = namingSchema.ReadTransaction())
        foreach (Ubisense.UName.Naming.ObjectName.RowType row in Ubisense.UName.Naming.ObjectName.object_name_(xact))
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

    public bool SetPosition(UObject obj, Position p)
    {
      if (obj != null)
      {
        CheckInitialized();
        return multicell.SetObjectLocation(obj, p);
      }
      else
        return false;
    }

    public bool SetPosition(Position p)
    {
      return SetPosition(selectedObject.Value, p); //called method can handle null Value
    }

    public bool SetPosition(double x, double y = 0.0, double z = 0.0, double theta = 0.0)
    {
      return SetPosition(selectedObject.Value, new Position(x, y, z, theta)); //called method can handle null Value
    }

    public bool SetPosition(UObject obj, double x, double y = 0.0, double z = 0.0, double theta = 0.0)
    {
      return SetPosition(obj, new Position(x, y, z, theta));
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
    public delegate void ButtonPressedEventHandler(object sender, Ubisense.UData.Data.ObjectButtonPressed.RowType? oldRow, Ubisense.UData.Data.ObjectButtonPressed.RowType newRow);

    public event GetObjectsCompletedEventHandler GetObjectsCompleted;
    public event ButtonPressedEventHandler ButtonPressed;

    // Update event handler that just calls the insert event handler with the new row
    protected void OnButton(Ubisense.UData.Data.ObjectButtonPressed.RowType oldRow, Ubisense.UData.Data.ObjectButtonPressed.RowType newRow)
    {
      if (ButtonPressed != null)
        ButtonPressed(this, oldRow, newRow);
    }

    // Insert event handler that outputs the button presses to the screen
    protected void OnButton(Ubisense.UData.Data.ObjectButtonPressed.RowType row)
    {
      if (ButtonPressed != null)
        ButtonPressed(this, null, row);
    }

    // row.button_ contains the index of the button pressed. Compact tags
    // have button 1; slim tags have buttons 1 and 2.
    //
    // row.object_ contains the Ubisense.ULocationIntegration.Tag whose button
    // was pressed.
    //
    // row.timestamp_ contains the Universal time of the button press.


    #endregion --- Events ---
  }
}