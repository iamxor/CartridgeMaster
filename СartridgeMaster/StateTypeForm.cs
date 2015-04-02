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
    public partial class StateTypeForm : Form
    {
        state_types _st;
        bool _isnew;
        StateTypeDetails _std;

        public StateTypeForm(bool isnew, state_types st)
        {
            _isnew = isnew;
            _st = st;

            InitializeComponent();

            if (_isnew)
            {
                Text = "Добавить новый статус";
                btCmd.Text = "Добавить";
            }
            else
            {
                Text = "Изменить статус";
                btCmd.Text = "Изменить";
            }

            _std = new StateTypeDetails();
            _std.object_type = (ObjectType)_st.object_type.Value;
            _std.state_value = _st.state_value.Value;
            _std.name = _st.name;

            propertyGrid1.SelectedObject = _std;
        }

        private void btCmd_Click(object sender, EventArgs e)
        {
            _st.object_type = (int)_std.object_type;
            _st.state_value = _std.state_value;
            _st.name = _std.name;
            if (_isnew)
                Runtime.DB.state_types.Add(_st);
            Runtime.DB.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
