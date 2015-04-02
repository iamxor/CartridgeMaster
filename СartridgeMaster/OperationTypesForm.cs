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
    public partial class OperationTypesForm : Form
    {
        public OperationTypesForm()
        {
            InitializeComponent();
        }

        public void FillOperationTypes()
        {
            if (tvObjectType.SelectedNode != null)
            {
                lvOperationTypes.BeginUpdate();
                lvOperationTypes.Items.Clear();
                int object_type = int.Parse(tvObjectType.SelectedNode.Tag.ToString());
                foreach (operation_types ot in Runtime.DB.operation_types.Where(x => x.object_type.Value == object_type).OrderBy(x => x.operation_value.Value))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = ot.operation_value.Value.ToString();
                    item.SubItems.Add(ot.name);
                    item.Tag = ot;
                    lvOperationTypes.Items.Add(item);
                }
                lvOperationTypes.EndUpdate();
            }
        }

        private void добавитьТипОперацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation_types ot = new operation_types();
            ot.id = Guid.NewGuid();
            ot.object_type = 0;
            ot.operation_value = 0;
            ot.name = "";
            ot.state = Guid.Empty;
            OperationTypeForm frm = new OperationTypeForm(true, ot);
            frm.ShowDialog();
            FillOperationTypes();
        }

        private void удалитьТипОперацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvOperationTypes.SelectedItems.Count > 0)
            {
                operation_types ot = lvOperationTypes.SelectedItems[0].Tag as operation_types;
                OperationTypeForm frm = new OperationTypeForm(false, ot);
                frm.ShowDialog();
                FillOperationTypes();
            }
        }

        private void tvObjectType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillOperationTypes();
        }

        private void lvOperationTypes_DoubleClick(object sender, EventArgs e)
        {
            if (lvOperationTypes.SelectedItems.Count > 0)
            {
                operation_types ot = lvOperationTypes.SelectedItems[0].Tag as operation_types;
                OperationTypeForm frm = new OperationTypeForm(false, ot);
                frm.ShowDialog();
                FillOperationTypes();
            }
        }
    }
}
