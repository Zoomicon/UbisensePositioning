//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: MainForm.cs
//Version: 20151110

//Based on Ubisense SDK's ObjectPosition sample - http://ubisense.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Ubisense.UBase;

namespace Ubisense.Positioning
{
  public partial class MainForm : Form
  {

    #region --- Constants ---

    private const string STR_INITIALIZING = " - Getting objects...";
    private const string STR_NEW = "NEW";
    private const string STR_NONE = "none";

    #endregion

    #region --- Fields ---

    private UbisensePositioning ubisensePositioning;

    #endregion

    #region --- Initialization ---

    public MainForm()
    {
      InitializeComponent();
      InitAsync();
    }

    private void InitAsync()
    {
      Text = Text + STR_INITIALIZING;
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

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Cleanup();
    }

    #endregion

    #region --- Properties ---

    private bool NoSelection {
      get
      {
        return (listEntries.SelectedItems.Count == 0);
      }
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
      listItem.SubItems.Add(name);

      listEntries.Items.Add(listItem);
    }

    #endregion

    #region --- Events ---

    private void UbisensePositioning_GetObjectsCompleted(object sender, SortedDictionary<string, UObject> objects)
    {
      // Fill up the list box with all the available objects
      foreach (var o in objects)
        AddToList(o.Key, o.Value);

      Text = Text.Replace(STR_INITIALIZING, "");
    }

    private void listEntries_SelectedIndexChanged(object sender, EventArgs e)
    {
      // Has the user selected an entry?
      if (listEntries.SelectedItems.Count != 1)
      {
        ubisensePositioning.SelectedObject = null;
        return;
      }

      var selectedItem = listEntries.SelectedItems[0];

      // Update the selected Obj
      ubisensePositioning.SelectedObject = (UObject)selectedItem.Tag; //we assigned the Tag property of each list item at "AddToList"

      // Update the labels
      lblSelectedObj.Text = selectedItem.Tag.ToString();
      lblSelectedName.Text = selectedItem.Name;
    }

    private void btnGetPos_Click(object sender, EventArgs e)
    {
      // Has the user selected an entry?
      if (NoSelection) return;

      Position? pos = ubisensePositioning.GetPosition();
      if (pos.HasValue)
      {
        lblCurrentPosX.Text = pos.Value.P.X.ToString();
        lblCurrentPosY.Text = pos.Value.P.Y.ToString();
        lblCurrentPosZ.Text = pos.Value.P.Z.ToString();
      }
      else
        lblCurrentPosX.Text = lblCurrentPosY.Text = lblCurrentPosZ.Text = STR_NONE;
    }

    private void btnSetPos_Click(object sender, EventArgs e)
    {
      if ((listEntries.SelectedItems.Count != 1) ||
          (tboxNewPosX.Text == "") ||
          (tboxNewPosY.Text == "") ||
          (tboxNewPosZ.Text == ""))
        return;

      double x, y, z;
      if (!double.TryParse(tboxNewPosX.Text, out x) ||
          !double.TryParse(tboxNewPosY.Text, out y) ||
          !double.TryParse(tboxNewPosZ.Text, out z)) return;

      if (ubisensePositioning.SetPosition(x, y, z))
      {
        lblCurrentPosX.Text = lblCurrentPosY.Text = lblCurrentPosZ.Text = STR_NEW;
        tboxNewPosX.Text = tboxNewPosY.Text = tboxNewPosZ.Text = "";
      }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      // Has the user selected an entry?
      if (NoSelection) return;

      ubisensePositioning.RemovePosition();
      lblCurrentPosX.Text = lblCurrentPosY.Text = lblCurrentPosZ.Text = STR_NONE;
    }

    #endregion

  }
}
