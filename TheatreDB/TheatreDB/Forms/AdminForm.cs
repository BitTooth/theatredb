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
    public partial class AdminForm : Form
    {
        TheatreDBConnection dbConnection;
        LoginForm loginForm;
        CustomersForm customersForm;
        PlaysForm playsForm;

        public AdminForm(TheatreDBConnection _dbConnection, LoginForm _loginForm)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            loginForm = _loginForm;
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Show();
        }

        private void playsButton_Click(object sender, EventArgs e)
        {
            playsForm = new PlaysForm(dbConnection, this);
            playsForm.Show();
            this.Hide();
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            customersForm = new CustomersForm(dbConnection, this);
            customersForm.Show();
            this.Hide();
        }
    }
}
