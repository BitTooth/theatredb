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

        private int readReviewID(MySqlDataReader rdr)
        {
            return (int)rdr.GetUInt32(0);
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

        private Repetition readRepetitionData(MySqlDataReader rdr)
        {
            Repetition r = new Repetition();
            r.date = rdr.GetString(0);
            r.ID = rdr.GetUInt32(1);
            r.playID = rdr.GetUInt32(2);
            return r;
        }

        private Customer readCustomerData(MySqlDataReader rdr)
        {
            Customer c = new Customer();
            c.ID = rdr.GetUInt32(0);
            c.password = rdr.GetString(1);
            c.email = rdr.GetString(2);
            return c;
        }

        private Ticket readTicketData(MySqlDataReader rdr)
        {
            Ticket t = new Ticket();
            t.ID = rdr.GetUInt32(0);
            t.cost = rdr.GetUInt32(1);
            t.discountName = rdr.GetString(2);
            t.returned = rdr.GetBoolean(3);
            t.placeID = rdr.GetUInt32(4);
            t.loginID = rdr.GetUInt32(5);
            t.instanceID = rdr.GetUInt32(6);
            return t;
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

                while (rdr.Read())
                {
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

        public List<Review> getReviewListByCustomer(string customerName)
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
                                       " WHERE посетители.`email` = '{0}'; ", customerName);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readReviewData(rdr));
            }

            rdr.Close();

            return list;
        }

        public List<Repetition> getRepetitionList()
        {
            List<Repetition> list = new List<Repetition>();
            MySqlDataReader rdr = null;
            string stm = @"SELECT `дата_время`" +
                            ", `id_репетиции`" +
                            ", `id_спектакля`" +
                         " FROM `репетиции`;" ;
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readRepetitionData(rdr));
            }

            rdr.Close();

            return list;
        }

        public List<Repetition> getRepetitionListByName(string name)
        {
            List<Repetition> list = new List<Repetition>();
            MySqlDataReader rdr = null;
            string stm = string.Format(@"SELECT `репетиции`.`дата_время`" +
                                           ", `репетиции`.`id_репетиции`" +
                                           ", `репетиции`.`id_спектакля`" +
                                       " FROM `репетиции`" +
                                       " LEFT JOIN `спектакль`" +
                                       " ON `репетиции`.`ID_Спектакля` = `спектакль`.`ID_спектакля`" +
                                       " WHERE `спектакль`.`Название` = '{0}'; ", name);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readRepetitionData(rdr));
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

        public void addReview(string text, string loginName, string playName)
        {
            string stm = @"(SELECT MAX(`id_отзыва`) FROM `отзывы`)";
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            int id = readReviewID(rdr) + 1;
            rdr.Close();

            addReview(id, text, loginName, playName);
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

        public List<Ticket> getTicketList()
        {
            List<Ticket> list = new List<Ticket>();
            MySqlDataReader rdr = null;
            string stm = @"SELECT id, `цена_билета`, `название_скидки`, `сдан`, `ID_места`, `login`, `id_провед_спект` FROM `билет`";
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readTicketData(rdr));
            }

            rdr.Close();

            return list;
        }

        public List<Ticket> getTicketListByLogin(string login)
        {
            List<Ticket> list = new List<Ticket>();
            MySqlDataReader rdr = null;
            string stm = string.Format(@"SELECT `билет`.id," +
                                               "`билет`.`цена_билета`," +
                                               "`билет`.`название_скидки`," +
                                               "`билет`.`сдан`," +
                                               "`билет`.`ID_места`," +
                                               "`билет`.`login`," +
                                               "`билет`.`id_провед_спект`," +
                                               "`посетители`.email " +
                                        "FROM `билет` LEFT JOIN `посетители` " +
                                          "ON `билет`.`login` = `посетители`.`id_login` " +
                                        "WHERE `посетители`.email = '{0}';", login);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readTicketData(rdr));
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
        public List<Customer> getCustomersList()
        {
            List<Customer> list = new List<Customer>();
            MySqlDataReader rdr = null;
            
            string stm = @"SELECT * FROM `посетители`;";
            
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(readCustomerData(rdr));
            }

            rdr.Close();

            return list;
        }

        public void deleteCustomerTickets(uint customerID)
        {
            string stm = string.Format(@"DELETE FROM `билет` " +
                "WHERE login = '{0}';", customerID);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

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
              "SET `дата_время` = STR_TO_DATE('{1}', '%d.%m.%Y %k:%i:%s') " +
              "WHERE `id_репетиции` = '{0}';", ID, date_time);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public void updatePlayDate(uint ID, string date_time)
        {
            string stm = string.Format(@"UPDATE `проведение_спектакля` " +
              "SET `дата_время` = STR_TO_DATE('{1}', '%d.%m.%Y %k:%i:%s') " +
              "WHERE `ID` = '{0}';", ID, date_time);
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

        public void addTicket(Ticket t)
        {
            string stm = string.Format(@"INSERT INTO `билет` " +
                " (`id`, `цена_билета`, `название_скидки`, `сдан`, `ID_места`, `login`, `id_провед_спект`)" +
                " VALUES ({0}, {1}, '{2}', {3}, {4}, {5}, {6});",
                t.ID, t.cost, t.discountName, t.returned, t.placeID, t.loginID, t.instanceID);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public void addPlay(Play p)
        {
            string stm = string.Format(@"INSERT INTO `спектакль` " +
                " (`название`, `сюжет`, `год_пост`, `кол-во_акт`, `скидка`, `ID_спектакля`)" +
                " VALUES ({0}, {1}, '{2}', {3}, {4}, {5});",
                p.name, p.story, p.year, p.actorsNum, p.discount, p.ID);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public void addRepetition(Repetition r)
        {
            string stm = string.Format(@"INSERT INTO `репетиции` " +
                " (`дата_время`, `id_репетиции`, `id_спектакля`)" +
                " VALUES (STR_TO_DATE('{0}', '%d.%m.%Y %k:%i:%s'), {1}, '{2}');",
                r.date, r.ID, r.playID);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public void addPlayInstance(PlayInstance pi)
        {
            string stm = string.Format(@"INSERT INTO `проведение_спектакля` " +
                " (`дата_время`, `id_спектакля`, `отменён`, `ID`)" +
                " VALUES (STR_TO_DATE('{0}', '%d.%m.%Y %k:%i:%s'), (SELECT `id_спектакля` FROM `спектакль` WHERE `название` = '{1}'), '{2}', {3});",
                pi.date, pi.playName, pi.canceled, pi.ID);
            MySqlCommand cmd = new MySqlCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        private MySqlConnection connection;
    }
}
