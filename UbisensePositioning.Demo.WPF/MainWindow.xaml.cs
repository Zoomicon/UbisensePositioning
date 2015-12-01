//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: MainWindow.xaml.cs
//Version: 20151201

//Based on Ubisense SDK's ObjectPosition sample - http://ubisense.net

using System;
using System.Collections.Generic;
using System.Windows;

using Ubisense.UBase;

namespace Ubisense.Positioning.Demo.WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    #region --- Constants ---

    private const string STR_INITIALIZING = " - Getting objects...";
    private const string STR_NONE = "";

    #endregion

    #region --- Fields ---

    private UbisensePositioning ubisensePositioning;

    #endregion

    #region --- Initialization ---

    public MainWindow()
    {
      InitializeComponent();
      InitAsync();
    }

    private void InitAsync()
    {
      Title = Title + STR_INITIALIZING;
      ubisensePositioning = new UbisensePositioning(); //initializing here to not delay the user interface's startup
      ubisensePositioning.GetObjectsCompleted += UbisensePositioning_GetObjectsCompleted;
      ubisensePositioning.GetObjectsAsync(); //getting objects may take some time
    }

    #endregion

    #region --- Cleanup ---

    private void Cleanup()
    {
      //TODO: call ubisensePositioning.Dispose() and set it to null
    }


    #endregion

    #region --- Properties ---

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
