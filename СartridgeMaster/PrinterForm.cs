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
    public partial class PrinterForm : Form
    {
        printers _pr;
        bool _isnew;
        PrinterDetails _pd;

        public PrinterForm(bool isnew, printers pr)
        {
            _isnew = isnew;
            _pr = pr;

            InitializeComponent();

            if (_isnew)
            {
                Text = "Добавить новый принтер";
                btCmd.Text = "Добавить";
            }
            else
            {
                Text = "Изменить принтер";
                btCmd.Text = "Изменить";
            }

            _pd = new PrinterDetails();
            _pd.manufacturer = _pr.manufacturer;
            _pd.model = _pr.model;
            _pd.pages_count = _pr.pages_count.Value;
            _pd.number = _pr.number;
            _pd.state = _pr.state.Value;
            propertyGrid1.SelectedObject = _pd;
        }

        private void btCmd_Click(object sender, EventArgs e)
        {
            _pr.manufacturer = _pd.manufacturer;
            _pr.model = _pd.model;
            _pr.number = _pd.number;
            _pr.pages_count = _pd.pages_count;
            _pr.state = _pd.state;
            if (_isnew)
                Runtime.DB.printers.Add(_pr);
            Runtime.DB.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
