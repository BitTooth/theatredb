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
    public partial class EditPlayForm : Form
    {
        TheatreDBConnection dbConnection;
        string playName;

        List<Repetition> repetitionList;
        List<PlayInstance> playInstanceList;

        int repetSelectedIndex;
        int instSelectedIndex;

        public EditPlayForm(TheatreDBConnection _dbConnection, string _playName)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            playName = _playName;

            repetitionList = dbConnection.getRepetitionListByName(playName);
            playInstanceList = dbConnection.getPlayInstanceListByName(playName);

            repetSelectedIndex = 0;
            instSelectedIndex = 0;
            updateForm();
        }

        private void updateForm()
        {
            if (repetSelectedIndex == 0)
                prevRepetButton.Enabled = false;
            
            if (repetSelectedIndex == Math.Max(repetitionList.Count - 1, 0))
                nextRepetButton.Enabled = false;

            if (repetitionList.Count > 0)
                repetTimePicker.Text = repetitionList[repetSelectedIndex].date;

            ////////////////////////////////////////////////////////////////////

            if (instSelectedIndex == 0)
                prevInstButton.Enabled = false;

            if (instSelectedIndex == Math.Max(playInstanceList.Count - 1, 0))
                nextInstButton.Enabled = false;

            if (playInstanceList.Count > 0)
                instanceTimePicker.Text = playInstanceList[instSelectedIndex].date;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (repetSelectedIndex > 0)
            {
                --repetSelectedIndex;
                nextRepetButton.Enabled = true;
            }

            updateForm();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (repetSelectedIndex < repetitionList.Count - 1)
            {
                ++repetSelectedIndex;
                prevRepetButton.Enabled = true;
            }

            updateForm();
        }

        private void prevInstButton_Click(object sender, EventArgs e)
        {
            if (instSelectedIndex > 0)
            {
                --instSelectedIndex;
                nextInstButton.Enabled = true;
            }

            updateForm();
        }

        private void nextInstButton_Click(object sender, EventArgs e)
        {
            if (instSelectedIndex < playInstanceList.Count - 1)
            {
                ++instSelectedIndex;
                prevInstButton.Enabled = true;
            }

            updateForm();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (repetitionList.Count > 0)
                dbConnection.updateRepetition(repetitionList[repetSelectedIndex].ID, repetTimePicker.Text);

            if (playInstanceList.Count > 0)
                dbConnection.updatePlayDate(playInstanceList[instSelectedIndex].ID, instanceTimePicker.Text);
        }
    }
}
