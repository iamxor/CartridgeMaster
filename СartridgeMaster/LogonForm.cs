using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СartridgeMaster
{
    public partial class LogonForm : Form
    {
        Utility.ModifyRegistry.ModifyRegistry reg = new Utility.ModifyRegistry.ModifyRegistry();

        public LogonForm()
        {
            InitializeComponent();

            reg.BaseRegistryKey = Microsoft.Win32.Registry.CurrentUser;
            reg.ShowError = true;
            tbHostname.Text = reg.Read("RecentHostName");
            tbUsername.Text = reg.Read("RecentUserName");

            if (!string.IsNullOrEmpty(tbHostname.Text) && !string.IsNullOrEmpty(tbUsername.Text))
                tbPassword.Select();

            lbVer.Text = "Версия: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reg.Write("RecentHostName", tbHostname.Text);
            reg.Write("RecentUserName", tbUsername.Text);

            if(!string.IsNullOrEmpty(tbHostname.Text) && !string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPassword.Text))
            {
                if(Runtime.Connect(tbHostname.Text, tbUsername.Text, tbPassword.Text))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
