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
    //
    public partial class StatesForm : Form
    {
        public StatesForm()
        {
            InitializeComponent();
        }

        public void FillStateTypes()
        {
            if(tvObjectType.SelectedNode != null)
            {
                lvStates.BeginUpdate();
                lvStates.Items.Clear();
                int object_type = int.Parse(tvObjectType.SelectedNode.Tag.ToString());
                foreach(state_types st in Runtime.DB.state_types.Where(x => x.object_type.Value == object_type).OrderBy(x => x.state_value.Value))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = st.state_value.Value.ToString();
                    item.SubItems.Add(st.name);
                    item.Tag = st;
                    lvStates.Items.Add(item);
                }
                lvStates.EndUpdate();
            }            
        }

        private void добавитьСтатусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state_types st = new state_types();
            st.id = Guid.NewGuid();
            st.object_type = 0;
            st.state_value = 0;
            st.name = "";
            StateTypeForm frm = new StateTypeForm(true, st);
            frm.ShowDialog();
            FillStateTypes();
        }

        private void tvObjectType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillStateTypes();
        }

        private void lvStates_DoubleClick(object sender, EventArgs e)
        {
            if(lvStates.SelectedItems.Count > 0)
            {
                state_types st = lvStates.SelectedItems[0].Tag as state_types;
                StateTypeForm frm = new StateTypeForm(false, st);
                frm.ShowDialog();
                FillStateTypes();
            }
        }

        private void удалитьСтатусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvStates.SelectedItems.Count > 0)
            {
                state_types st = lvStates.SelectedItems[0].Tag as state_types;
                if (MessageBox.Show("Удалить статус?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Runtime.DB.state_types.Remove(st);
                    Runtime.DB.SaveChanges();
                    FillStateTypes();
                }                
            }
        }
    }
}
