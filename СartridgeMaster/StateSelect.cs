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
        public state_types Selected = null;
        public StateSelect(ObjectType otype)
        {
            InitializeComponent();
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            StateItem si = new StateItem();
            si.State = null;
            listBox1.Items.Add(si);
            foreach(state_types st in Runtime.DB.state_types.Where(x => x.object_type.Value == (int)otype))
            {
                si = new StateItem();
                si.State = st;
                listBox1.Items.Add(si);
            }
            listBox1.EndUpdate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                Selected = (listBox1.SelectedItem as StateItem).State;
                if(ValueSelected != null)
                    ValueSelected(this, new EventArgs());
            }                       
        }
    }

    public class StateItem
    {
        public state_types State { get; set; }
        public override string ToString()
        {
            if (State != null)
                return State.name;
            else
                return "Нет";
        }
    }
}
