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
    public partial class BuyTicketForm : Form
    {
        TheatreDBConnection dbConnection;
        string playName;
        uint loginID;

        List<PlayInstance> playsInstances;
        List<Hall> hallList;
        List<HallSeat> hallSeatsList;

        int selectedDateIndex;
        int selectedHallIndex;
        int selectedHallSeatIndex;

        public BuyTicketForm(TheatreDBConnection _dbConnection, string _playName, uint _loginID)
        {
            InitializeComponent();

            dbConnection = _dbConnection;
            playName = _playName;
            loginID = _loginID;

            playsInstances = dbConnection.getPlayInstanceListByName(playName);
            foreach (PlayInstance playInstance in playsInstances)
            {
                dateСomboBox.Items.Add(playInstance.date);
            }

            hallList = dbConnection.getHallList();
            foreach (Hall hall in hallList)
            {
                hallСomboBox.Items.Add(hall.name);
            }

            selectedDateIndex = 0;
            selectedHallIndex = 0;

            dateСomboBox.SelectedIndex = 0;
            hallСomboBox.SelectedIndex = 0;
        }

        private void updateHallSeats()
        {
            hallSeatsList = dbConnection.getHallSeatListByHallName(hallList[selectedHallIndex].name, playsInstances[selectedDateIndex].ID);

            hallSeatsComboBox.Items.Clear();
            foreach (HallSeat hallSeat in hallSeatsList)
            {
                hallSeatsComboBox.Items.Add("Ряд " + hallSeat.row.ToString() + ", место " + hallSeat.num.ToString());
            }

            if (hallSeatsComboBox.Items.Count > 0)
            {
                hallSeatsComboBox.SelectedIndex = 0;
                buyButton.Enabled = true;
            }
            else
                buyButton.Enabled = false;
        }

        private void dateСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDateIndex = dateСomboBox.SelectedIndex;
            updateHallSeats();
        }

        private void hallСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedHallIndex = hallСomboBox.SelectedIndex;
            updateHallSeats();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedHallSeatIndex = hallSeatsComboBox.SelectedIndex;
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.cost = 1000;
            ticket.discountName = "0";
            ticket.returned = false;
            ticket.placeID = hallSeatsList[selectedHallSeatIndex].ID;
            ticket.loginID = loginID;
            ticket.instanceID = playsInstances[selectedDateIndex].ID;

            dbConnection.addTicket(ticket);

            updateHallSeats();
        }
    }
}
