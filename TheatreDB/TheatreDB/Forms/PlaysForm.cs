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
    public partial class PlaysForm : Form
    {
        TheatreDBConnection dbConnection;
        AdminForm adminForm;
        List<Play> playsList;
        Play selectedPlay;

        public PlaysForm(TheatreDBConnection _dbConnection, AdminForm _adminForm)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            adminForm = _adminForm;

            updatePlaysListBox();
            playsListBox.SelectedIndex = 0;
        }

        private void updatePlaysListBox()
        {
            playsList = dbConnection.getPlayList();

            playsListBox.Items.Clear();
            foreach (Play play in playsList)
            {
                playsListBox.Items.Add(play.name);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditPlayForm editPlayForm = new EditPlayForm(dbConnection, selectedPlay);
            editPlayForm.ShowDialog();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            NewPlayForm newPlayForm = new NewPlayForm(dbConnection);
            newPlayForm.ShowDialog();

            updatePlaysListBox();
        }

        private void PlaysForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminForm.Show();
        }

        private void playsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlayName = (string)playsListBox.SelectedItem;
            foreach (Play play in playsList)
            {
                if (play.name == selectedPlayName)
                {
                    selectedPlay = play;
                    break;
                }
            }
        }
    }
}
