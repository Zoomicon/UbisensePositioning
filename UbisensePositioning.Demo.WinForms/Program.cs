//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: Program.cs
//Version: 20151110

using System;
using System.Windows.Forms;

namespace Ubisense.Positioning
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}