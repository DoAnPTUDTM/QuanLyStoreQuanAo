using GUI.AdminGUI;
using GUI.SalesGUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static Form currentForm;

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAddStaff());
            //Application.Run(new frmLogin());
            //Application.Run(new frmMainAdmin());
            //Application.Run(new frmMainSales());
        }
    }
}
