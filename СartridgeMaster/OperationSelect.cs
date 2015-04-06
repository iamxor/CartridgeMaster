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
    public partial class OperationSelect : UserControl
    {
        public event ValueSelectedHandler ValueSelected;
        public operation_types Selected = null;
        public OperationSelect(ObjectType otype)
        {
            InitializeComponent();
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            foreach (operation_types ot in Runtime.DB.operation_types.Where(x => x.object_type.Value == (int)otype))
            {
                OperationTypeItem itm = new OperationTypeItem();
                itm.OperationType = ot;
                listBox1.Items.Add(itm);
            }
            listBox1.EndUpdate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Selected = (listBox1.SelectedItem as OperationTypeItem).OperationType;
                if (ValueSelected != null)
                    ValueSelected(this, new EventArgs());
            }  
        }
    }

    public class OperationTypeItem
    {
        public operation_types OperationType { get; set; }
        public override string ToString()
        {
            if (OperationType != null)
                return OperationType.name;
            return "";
        }
    }
}
