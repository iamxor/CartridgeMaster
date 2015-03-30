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
    public partial class PrinterOperationForm : Form
    {
        operations _op;
        bool _isnew;
        PrinterOperationDetails _popd;

        public PrinterOperationForm(bool isnew, operations op)
        {
            _isnew = isnew;
            _op = op;

            InitializeComponent();

            if(_isnew)
            {
                Text = "Добавить новую операцию с принтером";
                btCmd.Text = "Добавить";
            }
            else
            {
                Text = "Изменить операцию с принтером";
                btCmd.Text = "Изменить";
            }

            _popd = new PrinterOperationDetails();
            _popd.datetime = _op.datetime.Value;
            _popd.operation = _op.operation.Value;
            _popd.notes = _op.notes;

            propertyGrid1.SelectedObject = _popd;
        }

        private void btCmd_Click(object sender, EventArgs e)
        {
            _op.datetime = _popd.datetime;
            _op.operation = _popd.operation;
            _op.notes = _popd.notes;
            if (_isnew)
                Runtime.DB.operations.Add(_op);
            Runtime.DB.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
