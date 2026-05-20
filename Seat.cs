using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class Seat : Form
    {
        

        private DBAccessHelper db = new DBAccessHelper();
        private List<string> selectedSeats = new List<string>();
        private decimal ticketPrice = 0;
        private int currentUserId = 1;
        private int currentBookingGroupId = 1;
        private int lastConfirmedBookingId = 0;


        public Seat()
        {
            InitializeComponent();
            this.btnCB.Click += new EventHandler(this.btnCB_Click);
            this.btnCAN.Click += new EventHandler(this.btnCAN_Click);

            // Move event hookup here
            cmbMovie.SelectedIndexChanged += cmbMovie_SelectedIndexChanged;
            cmbShow.SelectedIndexChanged += cmbShow_SelectedIndexChanged;
        }

        public Seat(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.btnCB.Click += new EventHandler(this.btnCB_Click);
            this.btnCAN.Click += new EventHandler(this.btnCAN_Click);

            // Move event hookup here
            cmbMovie.SelectedIndexChanged += cmbMovie_SelectedIndexChanged;
            cmbShow.SelectedIndexChanged += cmbShow_SelectedIndexChanged;
        }


        private void Seat_Load(object sender, EventArgs e)
        {
            LoadMovies();
            DisableAllSeats();
            AttachSeatClickEvents();
        }


        private void AttachSeatClickEvents()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("btan"))
                {
                    btn.Click -= SeatButton_Click;
                    btn.Click += SeatButton_Click;
                }
            }
        }

        private void LoadMovies()
        {
            cmbMovie.Items.Clear();
            cmbMovie.Items.Add("-- Select Movie --");
            cmbMovie.SelectedIndex = 0;

            string query = "SELECT DISTINCT MovieName FROM Shows";

            ResultSet result = db.GetQueryData(query);

            if (!result.HasError && result.Data != null)
            {
                foreach (DataRow row in result.Data.Rows)
                {
                    cmbMovie.Items.Add(row["MovieName"].ToString());
                }
            }
        }

        private void cmbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbShow.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            ticketPrice = 0;
            selectedSeats.Clear();
            UpdateSelectedSeatsDisplay();
            DisableAllSeats();

            if (cmbMovie.SelectedIndex <= 0) return;

            string movieName = cmbMovie.SelectedItem.ToString();

            cmbShow.Items.Add("-- Select Show --");
            cmbShow.SelectedIndex = 0;

            string query = "SELECT ShowId, ShowDate, ShowTime FROM Shows WHERE MovieName = '" + movieName + "'";

            ResultSet result = db.GetQueryData(query);

            if (!result.HasError && result.Data != null)
            {
                foreach (DataRow row in result.Data.Rows)
                {
                    string display = Convert.ToDateTime(row["ShowDate"]).ToString("dd-MMM-yyyy")
                                     + " " + row["ShowTime"].ToString();

                    cmbShow.Items.Add(new ShowItem
                    {
                        ShowId = Convert.ToInt32(row["ShowId"]),
                        Display = display
                    });
                }
            }
        }


        private void cmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            ticketPrice = 0;
            selectedSeats.Clear();
            UpdateSelectedSeatsDisplay();
            DisableAllSeats();

            if (cmbShow.SelectedIndex <= 0 || !(cmbShow.SelectedItem is ShowItem)) return;

            ShowItem selected = (ShowItem)cmbShow.SelectedItem;

            string query = "SELECT s.ShowPrice, h.HallName "
                         + "FROM Shows s "
                         + "INNER JOIN Hall h ON s.HallId = h.HallId "
                         + "WHERE s.ShowId = '" + selected.ShowId + "'";

            ResultSet result = db.GetQueryData(query);

            if (!result.HasError && result.Data != null && result.Data.Rows.Count > 0)
            {
                DataRow row = result.Data.Rows[0];
                textBox1.Text = row["HallName"].ToString();
                ticketPrice = Convert.ToDecimal(row["ShowPrice"]);
                textBox2.Text = ticketPrice.ToString("F2");
            }

            LoadSeatAvailability(selected.ShowId);
        }

       

        private void LoadSeatAvailability(int showId)
        {
            string query = "SELECT t.SeatNumber "
                         + "FROM Ticket t "
                         + "INNER JOIN Booking b ON t.BookingId = b.BookingId "
                         + "WHERE t.ShowId = '" + showId + "' "
                         + "AND b.BookingStatus = 'Booked'";

            ResultSet result = db.GetQueryData(query);

            HashSet<string> bookedSeats = new HashSet<string>();

            if (!result.HasError && result.Data != null)
            {
                foreach (DataRow row in result.Data.Rows)
                {
                    bookedSeats.Add(row["SeatNumber"].ToString().Trim().ToUpper());
                }
            }

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("btan"))
                {
                    string seatId = GetSeatIdFromButtonName(btn.Name);
                    btn.Enabled = true;

                    if (bookedSeats.Contains(seatId))
                    {
                        btn.BackColor = Color.Red;
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.BackColor = Color.Lime;
                    }
                }
            }
        }

      

        private void SeatButton_Click(object sender, EventArgs e)
        {
            if (cmbShow.SelectedIndex <= 0 || !(cmbShow.SelectedItem is ShowItem))
            {
                MessageBox.Show("Please select a movie and show first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btn = (Button)sender;
            string seatId = GetSeatIdFromButtonName(btn.Name);

            if (btn.BackColor == Color.Yellow)
            {
                btn.BackColor = Color.Lime;
                selectedSeats.Remove(seatId);
            }
            else if (btn.BackColor == Color.Lime)
            {
                btn.BackColor = Color.Yellow;
                selectedSeats.Add(seatId);
            }

            UpdateSelectedSeatsDisplay();
        }

  

        private void UpdateSelectedSeatsDisplay()
        {
            if (selectedSeats.Count == 0)
            {
                lblsele.Text = "";
                lblta.Text = "";
            }
            else
            {
                lblsele.Text = string.Join(", ", selectedSeats);
                decimal total = ticketPrice * selectedSeats.Count;
                lblta.Text = total.ToString("F2");
            }
        }



        private void btnCB_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                //MessageBox.Show("Please select at least one seat.",
                //    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cmbShow.SelectedItem is ShowItem selectedShow))
            {
                MessageBox.Show("Please select a show.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Confirm booking for seats: " + string.Join(", ", selectedSeats) + "\n" +
                "Total: BDT " + (ticketPrice * selectedSeats.Count).ToString("F2"),
                "Confirm Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;


            string bookingQuery = "INSERT INTO Booking (BookingStatus, UserId) "
                                + "VALUES ('Booked', '" + currentUserId + "')";

            ResultSet bookingResult = db.ExecuteNonQuery(bookingQuery);

            if (bookingResult.HasError)
            {
                MessageBox.Show("Error creating booking: " + bookingResult.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string idQuery = "SELECT MAX(BookingId) AS LastId FROM Booking";

            ResultSet idResult = db.GetQueryData(idQuery);

            if (idResult.HasError || idResult.Data == null || idResult.Data.Rows.Count == 0)
            {
                MessageBox.Show("Could not retrieve booking ID.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int bookingId = Convert.ToInt32(idResult.Data.Rows[0]["LastId"]);
            lastConfirmedBookingId = bookingId;



            bool allSuccess = true;

            foreach (string seat in selectedSeats)
            {
                string ticketQuery = "INSERT INTO Ticket (TicketPrice, TicketStatus, BookingId, ShowId, SeatNumber) "
                                   + "VALUES ('" + ticketPrice + "', 'Active', '" + bookingId + "', '" + selectedShow.ShowId + "', '" + seat + "')";

                ResultSet ticketResult = db.ExecuteNonQuery(ticketQuery);

                if (ticketResult.HasError)
                {
                    MessageBox.Show("Error creating ticket for seat " + seat + ": " + ticketResult.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allSuccess = false;
                    break;
                }
            }

            string getQuery =
    "SELECT Ticket.TicketId " +
    "FROM Ticket " +
    "WHERE Ticket.bookingId = " + bookingId;

            ResultSet res = db.GetQueryData(getQuery);

            int[] ticketIDs = new int[res.Data.Rows.Count];

            for (int i = 0; i < res.Data.Rows.Count; i++)
            {
                ticketIDs[i] = Convert.ToInt32(res.Data.Rows[i]["TicketId"]);
            }

            if (allSuccess)
            {
                MessageBox.Show(
                    "Booking confirmed!\n" +
                    "Booking ID : " + bookingId + "\n" +
                    "Ticket IDs : " + string.Join(", ", ticketIDs) + "\n" +
                    "Session    : #" + currentBookingGroupId + "\n" +
                    "Seats      : " + string.Join(", ", selectedSeats) + "\n" +
                    "Total      : BDT " + (ticketPrice * selectedSeats.Count).ToString("F2"),
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int currentShowId = selectedShow.ShowId;

                LoadSeatAvailability(currentShowId);

                selectedSeats.Clear();
                UpdateSelectedSeatsDisplay();
            }
        }

        private void btnCAN_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0 && lastConfirmedBookingId == 0)
            {
                this.Close();
                return;
            }

            currentBookingGroupId++;
            lastConfirmedBookingId = 0;

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("btan")
                    && btn.BackColor == Color.Yellow)
                {
                    btn.BackColor = Color.Lime;
                }
            }

            selectedSeats.Clear();
            UpdateSelectedSeatsDisplay();

            MessageBox.Show(
                "Session ended. New Booking Session.",
                "New Session", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("btan")
                    && btn.BackColor == Color.Yellow)
                {
                    btn.BackColor = Color.Lime;
                }
            }

            selectedSeats.Clear();
            UpdateSelectedSeatsDisplay();
        }

        private string GetSeatIdFromButtonName(string buttonName)
        {
            return buttonName.Replace("btan", "").ToUpper();
        }


        private void DisableAllSeats()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("btan"))
                {
                    btn.BackColor = Color.Lime;
                    btn.Enabled = false;
                }
            }
        }

        
    }

    public class ShowItem
    {
        public int ShowId { get; set; }
        public string Display { get; set; }

        public override string ToString() => Display;
    }
}
