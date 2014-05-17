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
    public partial class ClientForm : Form
    {
        public ClientForm(TheatreDBConnection _dbConnection, LoginForm _loginForm)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            loginForm = _loginForm;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Show();
        }

        TheatreDBConnection dbConnection;
        LoginForm loginForm;
    }
}
