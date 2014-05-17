using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TheatreDB.Database
{
    class TheatreDB
    {
        public void connect()
        {
            string cs = @"server:localhost;userid=root;password=123;database='театр'";


            try
            {
                connection = new MySqlConnection(cs);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error connecting database\n Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MySqlConnection connection;
    }
}
