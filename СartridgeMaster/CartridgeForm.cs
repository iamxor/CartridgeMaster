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
    public partial class CartridgeForm : Form
    {
        cartridges _cr;
        bool _isnew;
        CartridgeDetails _cd;

        public CartridgeForm(bool isnew, cartridges cr)
        {
            _isnew = isnew;
            _cr = cr;

            InitializeComponent();

            if (_isnew)
            {
                Text = "Добавить новый картридж";
                btCmd.Text = "Добавить";
            }
            else
            {
                Text = "Изменить картридж принтер";
                btCmd.Text = "Изменить";
            }

            _cd = new CartridgeDetails();
            _cd.number = _cr.number;
            _cd.model = _cr.model;
            _cd.state = _cr.state.Value;
            propertyGrid1.SelectedObject = _cd;
        }

        private void btCmd_Click(object sender, EventArgs e)
        {
            _cr.number = _cd.number;
            _cr.model = _cd.model;
            _cr.state = _cd.state;
            if (_isnew)
                Runtime.DB.cartridges.Add(_cr);
            Runtime.DB.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
