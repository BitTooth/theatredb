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
    public class TheatreDBConnection
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

        private Review readReviewData(MySqlDataReader rdr)
        {
            Review r = new Review();
            r.ID = rdr.GetUInt32(0);
            r.loginName = rdr.GetString(3);
            r.playName = rdr.GetString(2);
            r.review = rdr.GetString(1);
            return r;
        }

        private PlayInstance readPlayInstanceData(MySqlDataReader rdr)
        {
            PlayInstance pi = new PlayInstance();
            pi.date = rdr.GetString(0);
            pi.playName = rdr.GetString(1);
            pi.canceled = rdr.GetBoolean(2);
            pi.ID = rdr.GetUInt32(3);
            return pi;
        }

        private Hall readHallData(MySqlDataReader rdr)
        {
            Hall h = new Hall();
            h.name = rdr.GetString(0);
            h.ID = rdr.GetUInt32(1);
            return h;
        }

        private HallSeat readHallSeatData(MySqlDataReader rdr)
        {
            HallSeat hs = new HallSeat();
            hs.row = rdr.GetUInt32(0);
            hs.num = rdr.GetUInt32(1);
            hs.margin = rdr.GetString(2);
            hs.hall = rdr.GetString(3);
            hs.ID = rdr.GetUInt32(4);
            return hs;
        }

        /*  3) Посмотреть спектакли
         *     SELECT id_спектакля, название  FROM спектакль */
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

            rdr.Close();

            return list;
        }
        
        /*  4) Выбрать спектакли по жанру
         *     SELECT id_жанра,  название  FROM спектакль
         *          where id_спектакля = @id_жанра          */
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

            rdr.Close();

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

            rdr.Close();

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

                rdr.Close();
            }

            return customer;
        }

        public List<Review> getReviewList()
        {
            List<Review> list = new List<Review>();
            MySqlDataReader rdr = null;
            string stm = @"SELECT отзывы.`ID_отзыва`"+
                            ", отзывы.`отзыв`"+
                            ", спектакль.`Название`"+
                            ", посетители.email"+
                         " FROM"+
                            " (отзывы"+
                         " LEFT JOIN `посетители`"+
                         " ON отзывы.id_login = посетители.id_login)"+
                         " LEFT JOIN спектакль"+
                         " ON отзывы.`ID_Спектакля` = спектакль.`ID_спектакля`; ";
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readReviewData(rdr));
            }

            rdr.Close();

            return list;
        }

        public List<Review> getReviewListByName(string playName)
        {
            List<Review> list = new List<Review>();
            MySqlDataReader rdr = null;
            string stm = string.Format(@"SELECT отзывы.`ID_отзыва`" +
                                          ", отзывы.`отзыв`" +
                                          ", спектакль.`Название`" +
                                          ", посетители.email" +
                                       " FROM" +
                                          " (отзывы" +
                                       " LEFT JOIN `посетители`" +
                                       " ON отзывы.id_login = посетители.id_login)" +
                                       " LEFT JOIN спектакль" +
                                       " ON отзывы.`ID_Спектакля` = спектакль.`ID_спектакля`" +
                                       " WHERE спектакль.`Название` = '{0}'; ", playName);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readReviewData(rdr));
            }

            rdr.Close();

            return list;
        }

        /*  1) Написать отзыв 
         *     INSERT INTO `отзыв` (`отзыв`,`id_спектакля`,`id_login`) VALUES("Ваш спектакль ...","777","666");*/
        public void addReview(int id, string text, string loginName, string playName)
        {
            string stm = string.Format(@"INSERT INTO `отзывы` (`id_отзыва`, `отзыв`,`id_спектакля`,`id_login`) VALUES("+
                "{0}," +
                "'{1}',"+
                "(SELECT `спектакль`.`ID_спектакля` FROM `спектакль` WHERE `Название` = '{3}')," +
                "(SELECT `посетители`.`id_login` FROM `посетители` WHERE `email` = '{2}'));", id, text, loginName, playName);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public List<PlayInstance> getPlayInstanceListByName(string playName)
        {
            List<PlayInstance> list = new List<PlayInstance>();
            MySqlDataReader rdr = null;
            string stm = string.Format(@"SELECT `проведение_спектакля`.`дата_время`," +
                                 "`спектакль`.`название`," +
                                 "`проведение_спектакля`.`отменён`," +
                                 "`проведение_спектакля`.`ID`" +
                          " FROM `проведение_спектакля` LEFT JOIN `спектакль`" +
                          " ON `проведение_спектакля`.`id_спектакля`=`спектакль`.`id_спектакля`"+
                          " WHERE `спектакль`.`название` = '{0}';", playName);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readPlayInstanceData(rdr));
            }

            rdr.Close();

            return list;
        }

        public List<Hall> getHallList()
        {
            List<Hall> list = new List<Hall>();
            MySqlDataReader rdr = null;
            string stm = @"SELECT название, ID FROM зал";
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readHallData(rdr));
            }

            rdr.Close();

            return list;
        }

        public List<HallSeat> getHallSeatListByHallName(string hallName)
        {
            List<HallSeat> list = new List<HallSeat>();
            MySqlDataReader rdr = null;
            string stm = string.Format(@"SELECT `места_в_зале`.`ряд`,"+
                                               "`места_в_зале`.`номер_места`," +
                                               "`места_в_зале`.`наценка`," +
                                               "`зал`.`название`," +
                                               "`места_в_зале`.`ID_места`" +
                                        "FROM `места_в_зале` LEFT JOIN `зал`"+
                                          "ON `места_в_зале`.`зал` = `зал`.`ID`"+
                                        "WHERE `зал`.`название` = '{0}'", hallName);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readHallSeatData(rdr));
            }

            rdr.Close();

            return list;
        }

        //  1) INSERT INTO `посетители` (`email`, `пароль`) VALUES ('i.love@theatre.ru', 'password');- зарегистрироваться
        public void registerNewCunstomer(Customer customer)
        {
            string stm = string.Format(@"INSERT INTO `посетители` (`id_login`, `пароль`, email) VALUES(" +
                "{0}," +
                "'{1}'," +
                "'{2}');", customer.ID, customer.password, customer.email);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        
        // 2)   DELETE FROM `посетители` WHERE `id_login` = 100500;
        //      DELETE FROM `отзывы` WHERE `ID_отзыва` = 100500;
        public void deleteCustomer(string name)
        {
            string stm = string.Format(@"DELETE FROM `посетители` "+
                "WHERE email = '{0}';", name);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public void deleteCustomer(uint ID)
        {
            string stm = string.Format(@"DELETE FROM `посетители` " +
               "WHERE `id_login` = '{0}';", ID);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();  
        }

        public void deleteReview(uint ID)
        {
            string stm = string.Format(@"DELETE FROM `отзывы` " +
              "WHERE `ID_отзыва` = '{0}';", ID);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();    
        }

        // 4)   UPDATE `репетиции` SET `дата_время` = 'дата и время' WHERE `id_репетиции` = 100500;
        //      UPDATE `проведение_спектакля` SET `дата_время` = 'дата и время' WHERE `ID` = 100500;
        public void updateRepetition(uint ID, string date_time)
        {
            string stm = string.Format(@"UPDATE `репетиции` " +
              "SET `дата_время` = '{1}'" +
              "WHERE `id_репетиции` = '{0}';", ID, date_time);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public void updatePlayDate(uint ID, string date_time)
        {
            string stm = string.Format(@"UPDATE `проведение_спектакля` " +
              "SET `дата_время` = '{1}'" +
              "WHERE `ID` = '{0}';", ID, date_time);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public void updatePlayDate(string name, string date_time)
        {
            string stm = string.Format(@"UPDATE `проведение_спектакля` " +
              " SET `дата_время` = '{1}'" +
              " WHERE `Название` = '{0}';", name, date_time);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        // 5)   INSERT INTO `скидка` (`Название_скидки`, `%_скидки`) VALUES ('пенсионная', '20');
        public void addDiscount(string name, string value)
        {
            string stm = string.Format(@"INSERT INTO `скидка` " +
              " (`Название_скидки`, `%_скидки`)" +
              " VALUES ('{0}','{1}');", name, value);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        private MySqlConnection connection;
    }
}
