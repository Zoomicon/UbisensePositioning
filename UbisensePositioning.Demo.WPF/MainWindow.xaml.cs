//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: MainWindow.xaml.cs
//Version: 20151201

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
    }

    #endregion

    #region --- Cleanup ---

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      ubisensePositioningUI.Cleanup(); //probably not needed if WPF calls Dispose automatically on controls that implement IDisposable, but to be safe call Dispose anyway (it ignores subsequent calls)
    }

    #endregion

  }

}
