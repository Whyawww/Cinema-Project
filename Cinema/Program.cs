using Cinema.Help;
using Cinema.View;
using System;
using System.Windows.Forms;

namespace Cinema
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var user = new GrabUser();
            if(!user.CheckSession())
                Application.Run(new Login());
            else
                Application.Run(new Home());
        }
    }
}
