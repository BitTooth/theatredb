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
        Play play;

        List<Repetition> repetitionList;
        List<PlayInstance> playInstanceList;

        int repetOriginalCount;
        int instOriginalCount;

        int repetSelectedIndex;
        int instSelectedIndex;

        public EditPlayForm(TheatreDBConnection _dbConnection, Play _play)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            play = _play;

            repetitionList = dbConnection.getRepetitionListByName(play.name);
            playInstanceList = dbConnection.getPlayInstanceListByName(play.name);

            repetOriginalCount = repetitionList.Count;
            instOriginalCount = playInstanceList.Count;

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
                repetitionList[repetSelectedIndex].date = repetTimePicker.Text;

                --repetSelectedIndex;
                nextRepetButton.Enabled = true;
            }

            updateForm();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (repetSelectedIndex < repetitionList.Count - 1)
            {
                repetitionList[repetSelectedIndex].date = repetTimePicker.Text;

                ++repetSelectedIndex;
                prevRepetButton.Enabled = true;
            }

            updateForm();
        }

        private void prevInstButton_Click(object sender, EventArgs e)
        {
            if (instSelectedIndex > 0)
            {
                playInstanceList[instSelectedIndex].date = instanceTimePicker.Text;

                --instSelectedIndex;
                nextInstButton.Enabled = true;
            }

            updateForm();
        }

        private void nextInstButton_Click(object sender, EventArgs e)
        {
            if (instSelectedIndex < playInstanceList.Count - 1)
            {
                playInstanceList[instSelectedIndex].date = instanceTimePicker.Text;

                ++instSelectedIndex;
                prevInstButton.Enabled = true;
            }

            updateForm();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            repetitionList[repetSelectedIndex].date = repetTimePicker.Text;

            for (int i = 0; i < repetOriginalCount; ++i)
                dbConnection.updateRepetition(repetitionList[i].ID, repetitionList[i].date);

            for (int i = repetOriginalCount; i < repetitionList.Count; ++i)
            {
                Repetition repet = new Repetition();
                repet.date = repetitionList[i].date;
                repet.playID = play.ID;

                dbConnection.addRepetition(repetitionList[i]);
            }

            if (repetOriginalCount < repetitionList.Count)
                repetOriginalCount = repetitionList.Count;

            //////////////////////////////////////////////////////////////////////////////////

            playInstanceList[instSelectedIndex].date = instanceTimePicker.Text;

            for (int i = 0; i < instOriginalCount; ++i)
                dbConnection.updatePlayDate(playInstanceList[i].ID, playInstanceList[i].date);

            for (int i = instOriginalCount; i < playInstanceList.Count; ++i)
            {
                PlayInstance playInstance = new PlayInstance();
                playInstance.canceled = false;
                playInstance.date = playInstanceList[i].date;
                playInstance.playName = playInstanceList[i].playName;

                dbConnection.addPlayInstance(playInstanceList[i]);
            }

            if (instOriginalCount < playInstanceList.Count)
                instOriginalCount = playInstanceList.Count;
        }

        private void repetAddButton_Click(object sender, EventArgs e)
        {
            Repetition repet = new Repetition();
            repet.date = "01.01.2014 01:01:01";
            repet.playID = play.ID;

            repetitionList.Add(repet);
            repetSelectedIndex = repetitionList.Count - 1;
            prevRepetButton.Enabled = true;
            nextRepetButton.Enabled = false;

            repetTimePicker.Text = "01.01.2000 01:01:01";
        }

        private void instAddButton_Click(object sender, EventArgs e)
        {
            PlayInstance playInstance = new PlayInstance();
            playInstance.canceled = false;
            playInstance.date = "01.01.2014 01:01:01";
            playInstance.playName = play.name;

            playInstanceList.Add(playInstance);
            instSelectedIndex = playInstanceList.Count - 1;
            prevInstButton.Enabled = true;
            nextInstButton.Enabled = false;

            instanceTimePicker.Text = "01.01.2000 01:01:01";
        }
    }
}
