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
        TheatreDBConnection dbConnection;
        LoginForm loginForm;

        List<Genre> genresList;
        List<Play> playList;

        Play selectedPlay;

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

        private void genresСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenreName = (string)genresСomboBox.SelectedItem;

            Genre selectedGenre = null;
            foreach (Genre genre in genresList)
            {
                if (selectedGenreName == genre.name)
                {
                    selectedGenre = genre;
                    break;
                }
            }

            if (selectedGenre != null)
                playList = dbConnection.getPlayListByGenre(selectedGenre);
            else
                playList = dbConnection.getPlayList();

            playsListBox.Items.Clear();
            foreach (Play play in playList)
            {
                playsListBox.Items.Add(play.name);
            }
            playsListBox.SelectedIndex = 0;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            PlayInfoForm playInfoForm = new PlayInfoForm(selectedPlay);
            playInfoForm.ShowDialog();
        }

        private void playsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPlay = playList[playsListBox.SelectedIndex];
        }

        private void feedbacksButton_Click(object sender, EventArgs e)
        {
            PlayFeedbacksForm feedbacksForm = new PlayFeedbacksForm(dbConnection, selectedPlay, loginForm.getLogin());
            feedbacksForm.ShowDialog();
        }
    }
}
