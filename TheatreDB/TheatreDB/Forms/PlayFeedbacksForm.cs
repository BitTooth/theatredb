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
    public partial class PlayFeedbacksForm : Form
    {
        TheatreDBConnection dbConnection;
        string loginName, playName;

        public PlayFeedbacksForm(TheatreDBConnection _dbConnection, Play play, string _loginName)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            loginName = _loginName;
            playName = play.name;

            updateFeedbacks();
        }

        private void leaveFeedbackButton_Click(object sender, EventArgs e)
        {
            dbConnection.addReview(myFeedbackRichTextBox.Text, loginName, playName);
            myFeedbackRichTextBox.Text = "";
            updateFeedbacks();
        }

        private void updateFeedbacks()
        {
            feedbackRichTextBox.Clear();

            List<Review> reviewsList = dbConnection.getReviewListByName(playName);
            foreach (Review review in reviewsList)
            {
                string feedback = review.loginName + ":\n" + review.review + "\n\n";
                feedbackRichTextBox.AppendText(feedback);
            }
        }
    }
}
