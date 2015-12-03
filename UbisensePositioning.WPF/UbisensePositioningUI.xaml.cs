//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: UbisensePositioningUI.xaml.cs
//Version: 20151203

//Based on Ubisense SDK's ObjectPosition sample - http://ubisense.net

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using Ubisense.UBase;

namespace Ubisense.Positioning.WPF
{
  /// <summary>
  /// Interaction logic for UbisensePositioningUI.xaml
  /// </summary>
  public partial class UbisensePositioningUI : UserControl
  {

    #region --- Constants ---

    protected const string STR_INITIALIZING = " - Getting objects...";
    protected const string STR_NONE = "";

    #endregion

    #region --- Fields ---

    protected UbisensePositioning ubisensePositioning;

    #endregion

    #region --- Initialization ---

    public UbisensePositioningUI()
    {
      InitializeComponent();
      InitAsync();
    }

    private void InitAsync()
    {
      Title = Title + STR_INITIALIZING;
      ubisensePositioning = new UbisensePositioning(); //initializing here to not delay the user interface's startup
      ubisensePositioning.GetObjectsCompleted += UbisensePositioning_GetObjectsCompleted;
      ubisensePositioning.ButtonPressed += UbisensePositioning_ButtonPressed;
      ubisensePositioning.GetObjectsAsync(); //getting objects may take some time
    }

    #endregion

    #region --- Cleanup ---

    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing) // Dispose managed state (managed objects)
          Cleanup();

        // Note: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // set large fields to null.

        disposedValue = true;
      }
    }

    // Note: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~KinectAudioPositioningUI() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // Note: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }

    public void Cleanup()
    {
      //TODO: call ubisensePositioning.Dispose() and set it to null
      ubisensePositioning = null;
    }

    #endregion

    #region --- Properties ---

    public UbisensePositioning Positioning
    {
      get { return ubisensePositioning; }
    }

    public string Title
    {
      get
      {
        return txtTitle.Text;
      }
      set
      {
        txtTitle.Text = value;
      }
    }

    private bool NoSelection
    {
      get
      {
        return (listEntries.SelectedItems.Count == 0);
      }
    }

    #endregion

    #region --- Methods ---

    private void AddToList(SortedDictionary<string, UObject> objects)
    {
      listEntries.DataContext = objects;
    }

    #endregion

    #region --- Methods ---

    private void AddToList(string name, UObject obj)
    {
      ListViewItem listItem = new ListViewItem();

      // Use these to update the selected object
      listItem.Tag = obj;
      listItem.Name = name;

      // These are displayed in the ListView control
      listItem.Text = obj.Id.ToString();

      listEntries.Items.Add(listItem);
    }

    #endregion

    #region --- Events ---

    private void UbisensePositioning_GetObjectsCompleted(object sender, SortedDictionary<string, UObject> objects)
    {
      // Fill up the list box with all the available objects
      foreach (var o in objects)
        AddToList(o.Key, o.Value);

      Title = Title.Replace(STR_INITIALIZING, "");
    }

    private void listEntries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
      // Has the user selected an entry?
      if (listEntries.SelectedItems.Count != 1)
      {
        ubisensePositioning.SelectedObject = null;
        lblSelectedObj.Text = lblSelectedName.Text = "";
        return;
      }

      // Get the selection
      ListViewItem selectedItem = (ListViewItem)listEntries.SelectedValue;
      UObject selectedObject = (UObject)selectedItem.Tag; //we assigned the Tag property of each list item at "AddToList"

      // Update the selected Obj
      ubisensePositioning.SelectedObject = selectedObject;

      // Update the labels
      lblSelectedObj.Text = selectedObject.ToString();
      lblSelectedName.Text = selectedItem.Name;
    }

    private void btnGetPos_Click(object sender, RoutedEventArgs e)
    {
      // Has the user selected an entry?
      if (NoSelection) return;

      Position? pos = ubisensePositioning.GetPosition();
      if (pos.HasValue)
      {
        txtPositionX.Text = pos.Value.P.X.ToString();
        txtPositionY.Text = pos.Value.P.Y.ToString();
        txtPositionZ.Text = pos.Value.P.Z.ToString();
      }
      else
        txtPositionX.Text = txtPositionY.Text = txtPositionZ.Text = STR_NONE;
    }

    private void btnSetPos_Click(object sender, RoutedEventArgs e)
    {
      if ((listEntries.SelectedItems.Count != 1) ||
          (txtPositionX.Text == "") ||
          (txtPositionY.Text == "") ||
          (txtPositionZ.Text == ""))
        return;

      double x, y, z;
      if (!double.TryParse(txtPositionX.Text, out x) ||
          !double.TryParse(txtPositionY.Text, out y) ||
          !double.TryParse(txtPositionZ.Text, out z)) return;

      MessageBox.Show(ubisensePositioning.SetPosition(x, y, z) ? "Set position succesfully" : "Failed");
    }

    private void btnRemove_Click(object sender, RoutedEventArgs e)
    {
      // Has the user selected an entry?
      if (NoSelection) return;

      MessageBox.Show(ubisensePositioning.RemovePosition() ? "Removed position succesfully" : "Failed");
      txtPositionX.Text = txtPositionY.Text = txtPositionZ.Text = STR_NONE;
    }

    private void UbisensePositioning_ButtonPressed(object sender, Ubisense.UData.Data.ObjectButtonPressed.RowType? oldRow, Ubisense.UData.Data.ObjectButtonPressed.RowType newRow)
    {
      MessageBox.Show(string.Format("Tag ID: {0}, Button: {1}, Time: {2}", newRow.object_.Id, newRow.button_, newRow.timestamp_), "Button Pressed");
    }

    #endregion

  }

  #region ListViewItem class

  public class ListViewItem
  {
    public ListViewItem()
    {
    }

    public string Name { get; set; }
    public string Text { get; set; }
    public object Tag { get; set; }
  }

  #endregion

}

