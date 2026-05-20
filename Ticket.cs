using System;
using System.Data;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class Ticket : Form
    {
        // =====================================================
        // FIELDS
        // =====================================================

        private DBAccessHelper db = new DBAccessHelper();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public Ticket()
        {
            InitializeComponent();
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void Ticket_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        // =====================================================
        // SEARCH BUTTON — looks up by Ticket ID
        // =====================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a Ticket ID.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ticketId = textBox1.Text.Trim();

            // ---------------------------------------------------
            // Query joins Ticket → Booking → Shows → Hall
            // to get all details in one shot
            // ---------------------------------------------------

            string query = "SELECT t.TicketId, t.BookingId, t.TicketPrice, t.TicketStatus, "
                         + "t.SeatNumber, s.MovieName, h.HallName "
                         + "FROM Ticket t "
                         + "INNER JOIN Booking b ON t.BookingId = b.BookingId "
                         + "INNER JOIN Shows s ON t.ShowId = s.ShowId "
                         + "INNER JOIN Hall h ON s.HallId = h.HallId "
                         + "WHERE t.TicketId = '" + ticketId + "'";

            ResultSet result = db.GetQueryData(query);

            if (result.HasError)
            {
                MessageBox.Show("Error searching ticket: " + result.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.Data == null || result.Data.Rows.Count == 0)
            {
                MessageBox.Show("No ticket found with ID: " + ticketId,
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                return;
            }

            // ---------------------------------------------------
            // Fill in the fields
            // ---------------------------------------------------

            DataRow row = result.Data.Rows[0];

            // textBox1 = Ticket ID (already filled by user, keep it)
            textBox2.Text = row["BookingId"].ToString();      // Booking ID
            textBox4.Text = row["HallName"].ToString();       // Hall
            textBox3.Text = row["SeatNumber"].ToString();     // Seat No.
            textBox8.Text = row["MovieName"].ToString();      // Movie
            textBox7.Text = row["TicketPrice"].ToString();    // Total Amount
            textBox5.Text = row["TicketStatus"].ToString();   // Ticket Status
        }


        private void ClearFields()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}
