using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СartridgeMaster
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
            LogonForm frm = new LogonForm();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }            
            
        }
    }
}
