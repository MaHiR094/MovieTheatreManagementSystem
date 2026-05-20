using System;
using System.Data;
using System.Windows.Forms;
using MovieTheatreManagementSystem;

namespace MovieTicketBookingSystem
{
    public partial class PaymentDetails : Form
    {

        private DBAccessHelper db = new DBAccessHelper();

        public PaymentDetails()
        {
            InitializeComponent();

            this.txtTicket.Leave += new EventHandler(this.txtTicket_Leave);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
        }

        private void PaymentDetails_Load(object sender, EventArgs e)
        {
            LoadNextPaymentId();
            dtPaymentDate.Value = DateTime.Today;
            cmbPaymentStatus.SelectedIndex = 0;
            textBox2.Text = "BDT.";
        }

        private void LoadNextPaymentId()
        {
            string query = "SELECT MAX(PaymentId) AS LastId FROM Payment";

            ResultSet result = db.GetQueryData(query);

            if (!result.HasError && result.Data != null &&
              result.Data.Rows.Count > 0 &&
              result.Data.Rows[0]["LastId"] != DBNull.Value)
            {
                int lastId = Convert.ToInt32(result.Data.Rows[0]["LastId"]);
                textBox4.Text = (lastId + 1).ToString();
            }
            else
            {
                textBox4.Text = "1";
            }
        }

        private void txtTicket_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTicket.Text)) return;

            string ticketId = txtTicket.Text.Trim();

            string query = "SELECT t.TicketId, t.BookingId, t.TicketPrice, t.TicketStatus, " +
              "t.SeatNumber, s.MovieName, h.HallName " +
              "FROM Ticket t " +
              "INNER JOIN Booking b ON t.BookingId = b.BookingId " +
              "INNER JOIN Shows s ON t.ShowId = s.ShowId " +
              "INNER JOIN Hall h ON s.HallId = h.HallId " +
              "WHERE t.TicketId = '" + ticketId + "'";

            ResultSet result = db.GetQueryData(query);

            if (result.HasError)
            {
                MessageBox.Show("Error loading ticket: " + result.Message,
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.Data == null || result.Data.Rows.Count == 0)
            {
                MessageBox.Show("No ticket found with Ticket No: " + ticketId,
                  "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearFields();
                return;
            }

            DataRow row = result.Data.Rows[0];

            textBox4.Text = GenerateNextPaymentId();
            textBox2.Text = "BDT. " + row["TicketPrice"].ToString();
            textBox1.Text = row["BookingId"].ToString();
        }

        private string GenerateNextPaymentId()
        {
            string query = "SELECT MAX(PaymentId) AS LastId FROM Payment";

            ResultSet result = db.GetQueryData(query);

            if (!result.HasError && result.Data != null &&
              result.Data.Rows.Count > 0 &&
              result.Data.Rows[0]["LastId"] != DBNull.Value)
            {
                int lastId = Convert.ToInt32(result.Data.Rows[0]["LastId"]);
                return (lastId + 1).ToString();
            }

            return "1";
        }

        private void lblPaymentId_Click(object sender, EventArgs e)
        {
            LoadNextPaymentId();
        }

        private string GetSelectedPaymentMethod()
        {
            if (rbtnBkash.Checked) return "bKash";
            if (rbtnNagad.Checked) return "Nagad";
            if (rbtnCreditDebitCard.Checked) return "Credit/Debit Card";
            if (rbtnCash.Checked) return "Cash";
            return "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTicket.Text))
            {
                MessageBox.Show("Please enter a Ticket No.",
                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a Transaction ID.",
                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (GetSelectedPaymentMethod() == "")
            {
                MessageBox.Show("Please select a Payment Method.",
                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPaymentStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Payment Status.",
                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentId = textBox4.Text.Trim();
            string ticketId = txtTicket.Text.Trim();
            string amount = textBox2.Text.Replace("BDT.", "").Trim();
            string transactionId = textBox1.Text.Trim();
            string paymentMethod = GetSelectedPaymentMethod();
            string paymentDate = dtPaymentDate.Value.ToString("yyyy-MM-dd");
            string paymentStatus = cmbPaymentStatus.SelectedItem.ToString();

            string query = "INSERT INTO Payment (PaymentId, TicketId, Amount, TransactionId, PaymentMethod, PaymentDate, PaymentStatus) " +
              "VALUES ('" + paymentId + "', '" + ticketId + "', '" + amount + "', '" +
              transactionId + "', '" + paymentMethod + "', '" + paymentDate + "', '" + paymentStatus + "')";

            ResultSet result = db.ExecuteNonQuery(query);

            if (result.HasError)
            {
                MessageBox.Show("Error saving payment: " + result.Message,
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
              "Payment saved successfully!\n" +
              "Payment ID     : " + paymentId + "\n" +
              "Ticket No.     : " + ticketId + "\n" +
              "Amount         : BDT. " + amount + "\n" +
              "Method         : " + paymentMethod + "\n" +
              "Status         : " + paymentStatus,
              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
            LoadNextPaymentId();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtTicket.Clear();
            textBox1.Clear();
            textBox2.Text = "BDT.";

            rbtnBkash.Checked = false;
            rbtnNagad.Checked = false;
            rbtnCreditDebitCard.Checked = false;
            rbtnCash.Checked = false;

            dtPaymentDate.Value = DateTime.Now;
            cmbPaymentStatus.SelectedIndex = 0;
        }
    }
}
