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
    public partial class CartridgeOperationForm : Form
    {
        operations _op;
        bool _isnew;
        CartridgeOperationDetails _copd;

        public CartridgeOperationForm(bool isnew, operations op)
        {
            _isnew = isnew;
            _op = op;

            InitializeComponent();

            if (_isnew)
            {
                Text = "Добавить новую операцию с принтером";
                btCmd.Text = "Добавить";
            }
            else
            {
                Text = "Изменить операцию с принтером";
                btCmd.Text = "Изменить";
            }

            _copd = new CartridgeOperationDetails();
            _copd.datetime = _op.datetime.Value;
            _copd.operation = _op.operation.Value;
            _copd.notes = _op.notes;

            propertyGrid1.SelectedObject = _copd;
        }

        private void btCmd_Click(object sender, EventArgs e)
        {
            _op.datetime = _copd.datetime;
            _op.operation = _copd.operation;
            _op.notes = _copd.notes;
            if (_isnew)
                Runtime.DB.operations.Add(_op);
            Runtime.DB.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
