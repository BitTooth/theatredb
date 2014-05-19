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
        string selectedCustomerName;

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
            selectedCustomerName = (string)customersListBox.SelectedItem;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            dbConnection.deleteCustomer(selectedCustomerName);
            updateCustomersListBox();
        }

        private void feedbacksButton_Click(object sender, EventArgs e)
        {
            CustomerFeedbacksForm customerFeedbacksForm = new CustomerFeedbacksForm(dbConnection, selectedCustomerName);
            customerFeedbacksForm.ShowDialog();
        }
    }
}
