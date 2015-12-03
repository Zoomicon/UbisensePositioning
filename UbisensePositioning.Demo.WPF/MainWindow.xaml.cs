//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: MainWindow.xaml.cs
//Version: 20151203

using System.Windows;

namespace Ubisense.Positioning.Demo.WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    #region --- Initialization ---

    public MainWindow()
    {
      InitializeComponent();
      ubisensePositioningUI.Positioning.ButtonPressed += UbisensePositioning_ButtonPressed;
    }

    #endregion

    #region --- Cleanup ---

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      ubisensePositioningUI.Cleanup(); //probably not needed if WPF calls Dispose automatically on controls that implement IDisposable, but to be safe call Dispose anyway (it ignores subsequent calls)
    }

    #endregion

    #region --- Events ---

    private void UbisensePositioning_ButtonPressed(object sender, Ubisense.UData.Data.ObjectButtonPressed.RowType? oldRow, Ubisense.UData.Data.ObjectButtonPressed.RowType newRow)
    {
      MessageBox.Show(string.Format("Tag ID: {0}, Button: {1}, Time: {2}", newRow.object_.Id, newRow.button_, newRow.timestamp_), "Button Pressed");
    }

    #endregion

  }

}
