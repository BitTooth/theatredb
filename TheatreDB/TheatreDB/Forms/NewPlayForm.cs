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

        public NewPlayForm(TheatreDBConnection _dbConnection)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Play play = new Play();
            play.name = nameTextBox.Text;
            play.story = storyRichTextBox.Text;
            play.year = Convert.ToUInt32(yearNumericUpDown.Value);
            play.actorsNum = Convert.ToUInt32(actsNumericUpDown.Value);
            play.discount = Convert.ToUInt32(discountNumericUpDown.Value);

            play.ID = dbConnection.addPlay(play);

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
    }
}
