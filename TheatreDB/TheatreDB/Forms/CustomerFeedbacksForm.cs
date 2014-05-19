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
    public partial class CustomerFeedbacksForm : Form
    {
        TheatreDBConnection dbConnection;
        string customerName;

        List<Review> reviewsList;
        int selectedIndex;

        public CustomerFeedbacksForm(TheatreDBConnection _dbConnection, string _customerName)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            customerName = _customerName;

            reviewsList = dbConnection.getReviewListByCustomer(customerName);
            selectedIndex = 0;

            updateForm();
        }

        private void updateForm()
        {
            if (selectedIndex == 0)
                prevButton.Enabled = false;

            if (selectedIndex == Math.Max(reviewsList.Count - 1, 0))
                nextButton.Enabled = false;

            if (reviewsList.Count == 0)
                deleteButton.Enabled = false;

            feedbackRichTextBox.Clear();

            if (reviewsList.Count > 0)
            {
                string feedback = reviewsList[selectedIndex].playName + ":\n" + reviewsList[selectedIndex].review + "\n\n";
                feedbackRichTextBox.AppendText(feedback);
            }
        }

        private void CustomerFeedbacksForm_Load(object sender, EventArgs e)
        {

        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (selectedIndex > 0)
            {
                --selectedIndex;
                nextButton.Enabled = true;
            }

            updateForm();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (selectedIndex < reviewsList.Count - 1)
            {
                ++selectedIndex;
                prevButton.Enabled = true;
            }

            updateForm();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            dbConnection.deleteReview(reviewsList[selectedIndex].ID);
            reviewsList.RemoveAt(selectedIndex);

            if (selectedIndex > 0)
            {
                --selectedIndex;
                if (reviewsList.Count > 0)
                    nextButton.Enabled = true;

            }
            
            updateForm();
        }
    }
}
