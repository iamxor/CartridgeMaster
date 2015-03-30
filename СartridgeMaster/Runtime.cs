using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.Entity;

namespace СartridgeMaster
{    
    public static class Runtime
    {
        public static Entities DB;
        public static bool Connect(string hostname, string username, string password)
        {
            try
            {
                DB = new Entities("metadata=res://*/Model.csdl|res://*/Model.ssdl|res://*/Model.msl;provider=MySql.Data.MySqlClient;provider connection string=\"server=" + hostname + ";user id=" + username + ";persistsecurityinfo=True;database=cartridge_master;password=" + password + "\";");
                DB.Database.Connection.Open();
                return true;
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
                return false;
            }
        }
    }

    public partial class Entities : DbContext
    {
        public Entities(string connectionString):base(connectionString) { }
    }
}
