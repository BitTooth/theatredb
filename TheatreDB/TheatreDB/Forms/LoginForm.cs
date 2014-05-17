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

namespace TheatreDB.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            admin = new LoginPassPair("root", "123");
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            LoginPassPair loginPassPair = new LoginPassPair(loginTextBox.Text, passwordTextBox.Text);

            if (loginPassPair == admin)
            {
                
            }
            else
            {

            }
        }

        struct LoginPassPair
        {
            public LoginPassPair(string l, string p)
            {
                login = l;
                password = p;
            }

            public static bool operator ==(LoginPassPair a, LoginPassPair b)
            {
                if (a.login == b.login && a.password == b.password)
                    return true;

                return false;
            }

            public static bool operator !=(LoginPassPair a, LoginPassPair b)
            {
                return !(a == b);
            }

            string login, password;
        }
        private LoginPassPair admin; 
    }
}
