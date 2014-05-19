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
    public partial class NewPlayForm : Form
    {
        TheatreDBConnection dbConnection;
        List<Genre> genresList;
        uint selectedGenreId;

        public NewPlayForm(TheatreDBConnection _dbConnection)
        {
            InitializeComponent();

            dbConnection = _dbConnection;

            genresList = dbConnection.getGenreList();
            foreach (Genre genre in genresList)
            {
                genresComboBox.Items.Add(genre.name);
            }
            genresComboBox.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Play play = new Play();
            play.name = nameTextBox.Text;
            play.story = storyRichTextBox.Text;
            play.year = Convert.ToUInt32(yearNumericUpDown.Value);
            play.actorsNum = Convert.ToUInt32(actsNumericUpDown.Value);
            play.discount = Convert.ToUInt32(discountNumericUpDown.Value);

            play.ID = dbConnection.addPlay(play, selectedGenreId);

            Repetition repet = new Repetition();
            repet.playID = play.ID;
            repet.date = "01.01.2000 01:01:01";

            dbConnection.addRepetition(repet);

            PlayInstance playInstance = new PlayInstance();
            playInstance.playName = play.name;
            playInstance.date = "01.01.2000 01:01:01";
            playInstance.canceled = false;

            dbConnection.addPlayInstance(playInstance);

            this.Close();
        }

        private void genresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenreName = (string)genresComboBox.SelectedItem;

            Genre selectedGenre = null;
            foreach (Genre genre in genresList)
            {
                if (selectedGenreName == genre.name)
                {
                    selectedGenre = genre;
                    break;
                }
            }

            selectedGenreId = selectedGenre.ID;
        }
    }
}
