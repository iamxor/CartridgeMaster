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
    public partial class OperationTypeForm : Form
    {
        operation_types _ot;
        bool _isnew;
        OperationTypeDetails _otd;

        public OperationTypeForm(bool isnew, operation_types ot)
        {
            _isnew = isnew;
            _ot = ot;

            InitializeComponent();

            if (_isnew)
            {
                Text = "Добавить новый тип операции";
                btCmd.Text = "Добавить";
            }
            else
            {
                Text = "Изменить тип операции";
                btCmd.Text = "Изменить";
            }

            _otd = new OperationTypeDetails();
            _otd.object_type = (ObjectType)_ot.object_type.Value;
            _otd.operation_value = _ot.operation_value.Value;
            _otd.name = _ot.name;
            _otd.state = _ot.state.Value;

            propertyGrid1.SelectedObject = _otd;
        }

        private void btCmd_Click(object sender, EventArgs e)
        {
            _ot.object_type = (int)_otd.object_type;
            _ot.operation_value = _otd.operation_value;
            _ot.name = _otd.name;
            _ot.state = _otd.state;

            if (_isnew)
                Runtime.DB.operation_types.Add(_ot);
            Runtime.DB.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
