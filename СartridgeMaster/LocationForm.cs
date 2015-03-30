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
    public partial class LocationForm : Form
    {
        locations _lc;
        bool _isnew;
        LocationDetails _ld;

        public LocationForm(bool isnew, locations lc)
        {
            _isnew = isnew;
            _lc = lc;

            InitializeComponent();

            if(_isnew)
            {
                Text = "Добавить новое расположение";
                btCmd.Text = "Добавить";
            }
            else
            {
                Text = "Изменить расположение";
                btCmd.Text = "Изменить";
            }

            _ld = new LocationDetails();
            _ld.name = _lc.name;

            propertyGrid1.SelectedObject = _ld;
        }

        private void btCmd_Click(object sender, EventArgs e)
        {
            _lc.name = _ld.name;
            if(_isnew)
                Runtime.DB.locations.Add(_lc);
            Runtime.DB.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
