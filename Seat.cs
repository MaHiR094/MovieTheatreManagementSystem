using Movie_Ticket_Management_System;
using MovieTicketBookingSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class Seat : Form
    {
        public Seat()
        {
            InitializeComponent();
        }

        private void Seat_Load(object sender, EventArgs e)
        {

        }

        private void btanA1_Click(object sender, EventArgs e)
        {
            lblsele.Text = "A1 - ";
        }

        private void btanA2_Click(object sender, EventArgs e)
        {
            lblsele.Text += "A2 - ";
        }
    }
}
