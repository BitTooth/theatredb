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
    public partial class LoginForm : Form
    {
        ClientForm clientForm;
        AdminForm adminForm;

        TheatreDBConnection dbConnection;
        Customer customer;

        public LoginForm()
        {
            InitializeComponent();

            dbConnection = new TheatreDBConnection();
            dbConnection.connect();
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            auth();
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                auth();
            }
        }

        private void auth()
        {
            customer = dbConnection.tryLogin(loginTextBox.Text, passwordTextBox.Text);

            if (customer == null)
            {
                MessageBox.Show("Неверная пара логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (customer.ID > 0)
            {
                clientForm = new ClientForm(dbConnection, this);
                clientForm.Show();
            }
            else
            {
                adminForm = new AdminForm(dbConnection, this);
                adminForm.Show();
            }

            this.Hide();
        }

        public string getLogin()
        {
            return customer.email;
        }
    }
}
