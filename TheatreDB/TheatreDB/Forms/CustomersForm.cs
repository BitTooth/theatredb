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
    public partial class CustomersForm : Form
    {
        TheatreDBConnection dbConnection;
        AdminForm adminForm;
        List<Customer> customersLst;
        Customer selectedCustomer;

        public CustomersForm(TheatreDBConnection _dbConnection, AdminForm _adminForm)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            adminForm = _adminForm;

            updateCustomersListBox();
            customersListBox.SelectedIndex = 0;
        }

        private void updateCustomersListBox()
        {
            customersLst = dbConnection.getCustomersList();

            customersListBox.Items.Clear();
            foreach (Customer customer in customersLst)
            {
                customersListBox.Items.Add(customer.email);
            }
        }

        private void CustomersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminForm.Show();
        }

        private void customersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCustomerName = (string)customersListBox.SelectedItem;
            foreach (Customer customer in customersLst)
            {
                if (customer.email == selectedCustomerName)
                {
                    selectedCustomer = customer;
                    break;
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            List<Review> reviewsList = dbConnection.getReviewListByCustomer(selectedCustomer.email);
            foreach (Review review in reviewsList)
            {
                dbConnection.deleteReview(review.ID);
            }

            List<Ticket> ticketsList = dbConnection.getTicketListByLogin(selectedCustomer.email);
            foreach (Ticket ticket in ticketsList)
            {
                dbConnection.deleteCustomerTickets(selectedCustomer.ID);
            }

            dbConnection.deleteCustomer(selectedCustomer.email);
            updateCustomersListBox();
        }

        private void feedbacksButton_Click(object sender, EventArgs e)
        {
            CustomerFeedbacksForm customerFeedbacksForm = new CustomerFeedbacksForm(dbConnection, selectedCustomer.email);
            customerFeedbacksForm.ShowDialog();
        }
    }
}
