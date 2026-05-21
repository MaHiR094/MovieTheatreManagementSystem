using System;
using System.Data;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class Ticket : Form
    {
        private DBAccessHelper db = new DBAccessHelper();

        public Ticket()
        {
            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a Ticket ID.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ticketId = textBox1.Text.Trim();

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

                DataRow row = result.Data.Rows[0];

                textBox2.Text = row["BookingId"].ToString();
                textBox4.Text = row["HallName"].ToString();
                textBox3.Text = row["SeatNumber"].ToString();
                textBox8.Text = row["MovieName"].ToString();
                textBox7.Text = row["TicketPrice"].ToString();
                textBox5.Text = row["TicketStatus"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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