using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLS1000Utility
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

            FormUtils.SetDefaultIcon();

            //Application.Run(new Form1());
            //Application.Run(new AppConfiguration());
            //Application.Run(new LicensingForm());
            Application.Run(new LoginForm());
            //Application.Run(new MainForm());
            //Application.Run(new DBSetupForm());
        }
    }
    public static class FormUtils
    {
        public static void SetDefaultIcon()
        {
            var icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            typeof(Form)
                .GetField("defaultIcon", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .SetValue(null, icon);
        }
    }
}
