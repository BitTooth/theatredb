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
    public partial class PlayInfoForm : Form
    {
        public PlayInfoForm(Play play)
        {
            InitializeComponent();

            this.Text = play.name;
            storyTextBox.Text = play.story;
            yearTextBox.Text = play.year.ToString();
            actsTextBox.Text = play.actorsNum.ToString();
            discountTextBox.Text = play.discount.ToString() + "%";
        }

        private void discountLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
