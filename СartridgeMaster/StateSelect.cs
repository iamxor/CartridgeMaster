using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СartridgeMaster
{
    public delegate void ValueSelectedHandler(object sender, EventArgs e);

    public partial class StateSelect : UserControl
    {
        public event ValueSelectedHandler ValueSelected;
        public StateSelect()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueSelected(this, new EventArgs());
        }
    }
}
