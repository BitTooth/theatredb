using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheatreDB.Database;
using TheatreDB.Objects;

namespace TheatreDB.Forms
{
    public partial class ClientForm : Form
    {
        public ClientForm(TheatreDBConnection _dbConnection, LoginForm _loginForm)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            loginForm = _loginForm;

            genresList = dbConnection.getGenreList();
            genresСomboBox.Items.Add("любой");
            foreach (Genre genre in genresList)
            {
                genresСomboBox.Items.Add(genre.name);
            }
            genresСomboBox.SelectedIndex = 0;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Show();
        }

        TheatreDBConnection dbConnection;
        LoginForm loginForm;

        List<Genre> genresList;

        private void genresСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenreName = (string)genresСomboBox.SelectedItem;

            uint selectedGenreID = 0;
            foreach (Genre genre in genresList)
            {
                if (selectedGenreName == genre.name)
                {
                    selectedGenreID = genre.ID;
                    break;
                }
            }
        }
    }
}
