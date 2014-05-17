using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheatreDB.Objects;
using MySql.Data.MySqlClient;

namespace TheatreDB.Database
{
    class TheatreDBConnection
    {
        public void connect()
        {
            string cs = @"server=localhost;charset=utf8;uid=root;pwd=123;database=theatre;";


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

        // To use this method you must use "SELECT * FROM спектакль ..."
        private Play readPlayData(MySqlDataReader rdr)
        {
            Play pl = new Play();
            pl.name = rdr.GetString(0);
            pl.story = rdr.GetString(1);
            pl.year = rdr.GetUInt32(2);
            pl.actorsNum = rdr.GetUInt32(3);
            pl.discount = rdr.GetUInt32(4);
            pl.ID = rdr.GetUInt32(5);
            return pl;
        }

        private Genre readGenreData(MySqlDataReader rdr)
        {
            Genre g = new Genre();
            g.ID = rdr.GetUInt32(0);
            g.name = rdr.GetString(1);
            return g;
        }

        public List<Play> getPlayList()
        {
            List<Play> list = new List<Play>();
            MySqlDataReader rdr = null;
            string stm = @"SELECT * FROM спектакль";
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readPlayData(rdr));
            }

            return list;
        }


        public List<Play> getPlayListByGenre(string name)
        {
            List<Play> list = new List<Play>();

            MySqlDataReader rdr = null;
            string stm = string.Format(@"SELECT *  FROM спектакль  where id_спектакля = (SELECT id_жанра FROM жанры WHERE название_жанра = '{0}')", name);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readPlayData(rdr));
            }

            return list;
        }

        public List<Play> getPlayListByGenre(Genre genre)
        {
            return getPlayListByGenre(genre.name);
        }

        public List<Genre> getGenreList()
        {
            List<Genre> list = new List<Genre>();
            MySqlDataReader rdr = null;
            string stm = @"SELECT * FROM жанры";
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readGenreData(rdr));
            }

            return list;
        }

        public Customer tryLogin(string name, string password)
        {
            Customer customer = null;
            if (name == "root" && password == "root")
            {
                customer = new Customer();
                customer.email = "root";
                customer.password = "root";
                customer.ID = 0;
            } 
            else
            {
                MySqlDataReader rdr = null;
                string stm = string.Format(@"SELECT * FROM посетители WHERE email = '{0}' and пароль = '{1}'", name, password);
                MySqlCommand cmd = new MySqlCommand(stm, connection);
                rdr = cmd.ExecuteReader();

                bool found = false;
                while (rdr.Read())
                {
                    found = true;
                    customer = new Customer();
                    customer.email = rdr.GetString(2);
                    customer.password = rdr.GetString(1);
                    customer.ID = rdr.GetUInt32(0);
                }
            }

            return customer;
        }

        private MySqlConnection connection;
    }
}
