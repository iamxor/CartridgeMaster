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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FillLocations();
        }

        public void FillLocations()
        {
            tvLocations.BeginUpdate();
            tvLocations.Nodes.Clear();

            foreach(locations lc in Runtime.DB.locations)
            {
                TreeNode node = new TreeNode();
                node.Text = lc.name;
                node.Tag = lc;
                tvLocations.Nodes.Add(node);
            }

            tvLocations.EndUpdate();
        }

        public void FillPrinters()
        {
            lvPrinters.BeginUpdate();
            lvPrinters.Items.Clear();
            if (tvLocations.SelectedNode != null)
            {
                locations lc = tvLocations.SelectedNode.Tag as locations;
                foreach (printers pr in Runtime.DB.printers.Where(x => x.location_id.Value == lc.id))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = pr.manufacturer;
                    item.SubItems.Add(pr.model);
                    item.SubItems.Add(pr.number);
                    item.SubItems.Add(pr.pages_count.Value.ToString());
                    item.SubItems.Add(pr.state.Value.ToString());
                    item.Tag = pr;
                    lvPrinters.Items.Add(item);
                }                
            }
            lvPrinters.EndUpdate();
        }

        public void FillCartridges()
        {
            lvCartridges.BeginUpdate();
            lvCartridges.Items.Clear();
            if (lvPrinters.SelectedItems.Count > 0)
            {
                printers pr = lvPrinters.SelectedItems[0].Tag as printers;
                foreach(cartridges cr in Runtime.DB.cartridges.Where(x => x.printer_id.Value == pr.id))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = cr.number;
                    item.SubItems.Add(cr.model);
                    item.SubItems.Add(cr.state.ToString());
                    item.Tag = cr;
                    lvCartridges.Items.Add(item);
                }                
            }
            lvCartridges.EndUpdate();
        }

        public void FillCartridgeOperations()
        {
            lvCartridgeOps.BeginUpdate();
            lvCartridgeOps.Items.Clear();
            if (lvCartridges.SelectedItems.Count > 0)
            {
                cartridges cr = lvCartridges.SelectedItems[0].Tag as cartridges;
                foreach (operations op in Runtime.DB.operations.Where(x => x.object_id.Value == cr.id))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = op.datetime.Value.ToShortDateString();
                    item.SubItems.Add(op.operation.Value.ToString());
                    item.SubItems.Add(op.notes);
                    item.Tag = op;
                    lvCartridgeOps.Items.Add(item);
                }                
            }
            lvCartridgeOps.EndUpdate();
        }

        public void FillPrinterOperations()
        {
            lvPrinterOps.BeginUpdate();
            lvPrinterOps.Items.Clear();
            if (lvPrinters.SelectedItems.Count > 0)
            {
                printers pr = lvPrinters.SelectedItems[0].Tag as printers;
                foreach (operations op in Runtime.DB.operations.Where(x => x.object_id.Value == pr.id))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = op.datetime.Value.ToShortDateString();
                    item.SubItems.Add(op.operation.Value.ToString());
                    item.SubItems.Add(op.notes);
                    item.Tag = op;
                    lvPrinterOps.Items.Add(item);
                }
            }
            lvPrinterOps.EndUpdate();
        }

        private void добавитьРасположениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            locations lc = new locations();
            lc.id = Guid.NewGuid();
            lc.parent_id = Guid.Empty;
            lc.name = "";
            LocationForm frm = new LocationForm(true, lc);
            frm.ShowDialog();
            FillLocations();
        }

        private void tvLocations_DoubleClick(object sender, EventArgs e)
        {
            if(tvLocations.SelectedNode != null)
            {
                LocationForm frm = new LocationForm(false, tvLocations.SelectedNode.Tag as locations);
                frm.ShowDialog();
                FillLocations();
            }
        }

        private void добавитьПринтерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tvLocations.SelectedNode != null)
            {
                locations lc = tvLocations.SelectedNode.Tag as locations;
                printers pr = new printers();
                pr.id = Guid.NewGuid();
                pr.location_id = lc.id; 
                pr.manufacturer = "";
                pr.model = "";
                pr.number = "";
                pr.pages_count = 0;
                pr.state = 0;
                PrinterForm frm = new PrinterForm(true, pr);
                frm.ShowDialog();
                FillPrinters();
            }
        }

        private void tvLocations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillPrinters();
            lvPrinterOps.Items.Clear();
            lvCartridges.Items.Clear();
            lvCartridgeOps.Items.Clear();
        }

        private void lvPrinters_DoubleClick(object sender, EventArgs e)
        {
            if(lvPrinters.SelectedItems.Count > 0)
            {
                printers pr = lvPrinters.SelectedItems[0].Tag as printers;
                PrinterForm frm = new PrinterForm(false, pr);
                frm.ShowDialog();
                FillPrinters();
            }
        }

        private void удалитьПринтерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvPrinters.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Удалить принтер?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    printers pr = lvPrinters.SelectedItems[0].Tag as printers;
                    Runtime.DB.printers.Remove(pr);
                    Runtime.DB.SaveChanges();
                    FillPrinters();
                }
            }
        }

        private void удалитьРасположениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvLocations.SelectedNode != null)
            {
                if(MessageBox.Show("Удалить расположение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    locations lc = tvLocations.SelectedNode.Tag as locations;
                    Runtime.DB.locations.Remove(lc);
                    Runtime.DB.SaveChanges();
                    FillLocations();
                }                
            }
        }        

        private void добавитьОперациюСПринтеромToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvPrinters.SelectedItems.Count > 0)
            {
                printers pr = lvPrinters.SelectedItems[0].Tag as printers;
                operations op = new operations();
                op.id = Guid.NewGuid();
                op.object_id = pr.id;
                op.datetime = DateTime.Now;
                op.operation = 0;
                op.notes = "";
                PrinterOperationForm frm = new PrinterOperationForm(true, op);
                frm.ShowDialog();
                FillPrinterOperations();
            }
        }

        private void lvPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvCartridgeOps.Items.Clear();
            FillPrinterOperations();
            FillCartridges();
        }

        private void lvPrinterOps_DoubleClick(object sender, EventArgs e)
        {
            if(lvPrinterOps.SelectedItems.Count > 0)
            {
                operations op = lvPrinterOps.SelectedItems[0].Tag as operations;
                PrinterOperationForm frm = new PrinterOperationForm(false, op);
                frm.ShowDialog();
                FillPrinterOperations();
            }
        }

        private void удалитьОперациюСКартриджемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvCartridgeOps.SelectedItems.Count > 0)
            {
                operations op = lvCartridgeOps.SelectedItems[0].Tag as operations;
                if (MessageBox.Show("Удалить операцию с картриджем?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Runtime.DB.operations.Remove(op);
                    Runtime.DB.SaveChanges();
                    FillCartridgeOperations();
                }
            }
        }

        private void удалитьОперациюСПринтеромToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvPrinterOps.SelectedItems.Count > 0)
            {
                operations op = lvPrinterOps.SelectedItems[0].Tag as operations;
                if (MessageBox.Show("Удалить операцию с принтером?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Runtime.DB.operations.Remove(op);
                    Runtime.DB.SaveChanges();
                    FillPrinterOperations();
                }
            }
        }

        private void добавитьКартриджToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvPrinters.SelectedItems.Count > 0)
            {
                printers pr = lvPrinters.SelectedItems[0].Tag as printers;
                cartridges cr = new cartridges();
                cr.id = Guid.NewGuid();
                cr.printer_id = pr.id;
                cr.number = "";
                cr.model = "";                
                cr.state = 0;
                CartridgeForm frm = new CartridgeForm(true, cr);
                frm.ShowDialog();
                FillCartridges();
            }
        }

        private void добавитьОперациюСКартриджемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvCartridges.SelectedItems.Count > 0)
            {
                cartridges cr = lvCartridges.SelectedItems[0].Tag as cartridges;
                operations op = new operations();
                op.id = Guid.NewGuid();
                op.object_id = cr.id;
                op.datetime = DateTime.Now;
                op.operation = 0;
                op.notes = "";
                CartridgeOperationForm frm = new CartridgeOperationForm(true, op);
                frm.ShowDialog();
                FillCartridgeOperations();
            }
        }

        private void lvCartridges_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCartridgeOperations();
        }

        private void статусыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatesForm frm = new StatesForm();
            frm.ShowDialog();
        }

        private void типыОперацийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationTypesForm frm = new OperationTypesForm();
            frm.ShowDialog();
        }

        private void lvCartridgeOps_DoubleClick(object sender, EventArgs e)
        {
            if (lvCartridgeOps.SelectedItems.Count > 0)
            {
                operations op = lvCartridgeOps.SelectedItems[0].Tag as operations;
                CartridgeOperationForm frm = new CartridgeOperationForm(false, op);
                frm.ShowDialog();
                FillCartridgeOperations();
            }
        }

    }
}
