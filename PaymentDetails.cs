using System;
using System.Data;
using System.Windows.Forms;
using MovieTheatreManagementSystem;

namespace MovieTicketBookingSystem
{
    public partial class PaymentDetails : Form
    {
        // =====================================================
        // FIELDS
        // =====================================================

        private DBAccessHelper db = new DBAccessHelper();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public PaymentDetails()
        {
            InitializeComponent();

            // Wire up events
            this.txtTicket.Leave += new EventHandler(this.txtTicket_Leave);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void PaymentDetails_Load(object sender, EventArgs e)
        {
            LoadNextPaymentId();
            dtPaymentDate.Value = DateTime.Today;
            cmbPaymentStatus.SelectedIndex = 0; // Default: Paid
            textBox2.Text = "BDT.";
        }

        // =====================================================
        // AUTO-GENERATE NEXT PAYMENT ID
        // =====================================================

        private void LoadNextPaymentId()
        {
            string query = "SELECT MAX(PaymentId) AS LastId FROM Payment";

            ResultSet result = db.GetQueryData(query);

            if (!result.HasError && result.Data != null
                && result.Data.Rows.Count > 0
                && result.Data.Rows[0]["LastId"] != DBNull.Value)
            {
                int lastId = Convert.ToInt32(result.Data.Rows[0]["LastId"]);
                textBox4.Text = (lastId + 1).ToString();
            }
            else
            {
                textBox4.Text = "1";
            }
        }

        // =====================================================
        // TICKET NO. LEAVE — auto-fill all fields
        // =====================================================

        private void txtTicket_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTicket.Text)) return;

            string ticketId = txtTicket.Text.Trim();

            // Join Ticket → Booking to get price and booking ID
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

            // Auto-fill all read-only fields
            textBox4.Text = GenerateNextPaymentId();                          // Payment ID
            textBox2.Text = "BDT. " + Convert.ToDecimal(row["TicketPrice"])
                                              .ToString("F2");                // Amount
            textBox1.Text = row["BookingId"].ToString();                      // Transaction ID (re-used as booking ref)
        }

        // =====================================================
        // GENERATE PAYMENT ID AS STRING
        // =====================================================

        private string GenerateNextPaymentId()
        {
            string query = "SELECT MAX(PaymentId) AS LastId FROM Payment";

            ResultSet result = db.GetQueryData(query);

            if (!result.HasError && result.Data != null
                && result.Data.Rows.Count > 0
                && result.Data.Rows[0]["LastId"] != DBNull.Value)
            {
                int lastId = Convert.ToInt32(result.Data.Rows[0]["LastId"]);
                return (lastId + 1).ToString();
            }

            return "1";
        }

        // =====================================================
        // LABEL PAYMENT ID CLICK — refresh Payment ID
        // =====================================================

        private void lblPaymentId_Click(object sender, EventArgs e)
        {
            LoadNextPaymentId();
        }

        // =====================================================
        // GET SELECTED PAYMENT METHOD
        // =====================================================

        private string GetSelectedPaymentMethod()
        {
            if (rbtnBkash.Checked) return "bKash";
            if (rbtnNagad.Checked) return "Nagad";
            if (rbtnCreditDebitCard.Checked) return "Credit/Debit Card";
            if (rbtnCash.Checked) return "Cash";
            return "";
        }

        // =====================================================
        // SAVE BUTTON
        // =====================================================

        private void btnSave_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------
            // VALIDATION
            // -------------------------------------------------

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

            // -------------------------------------------------
            // COLLECT VALUES
            // -------------------------------------------------

            string paymentId = textBox4.Text.Trim();
            string ticketId = txtTicket.Text.Trim();
            string amount = textBox2.Text.Replace("BDT.", "").Trim();
            string transactionId = textBox1.Text.Trim();
            string paymentMethod = GetSelectedPaymentMethod();
            string paymentDate = dtPaymentDate.Value.ToString("yyyy-MM-dd");
            string paymentStatus = cmbPaymentStatus.SelectedItem.ToString();

            // -------------------------------------------------
            // INSERT INTO Payment TABLE
            // -------------------------------------------------

            string query = "INSERT INTO Payment (PaymentId, TicketId, Amount, TransactionId, PaymentMethod, PaymentDate, PaymentStatus) "
                         + "VALUES ('" + paymentId + "', '" + ticketId + "', '" + amount + "', '"
                         + transactionId + "', '" + paymentMethod + "', '" + paymentDate + "', '" + paymentStatus + "')";

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

        // =====================================================
        // CANCEL BUTTON
        // =====================================================

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =====================================================
        // CLEAR BUTTON
        // =====================================================

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // =====================================================
        // CLEAR ALL FIELDS
        // =====================================================

        private void ClearFields()
        {
            txtTicket.Clear();
            textBox1.Clear();
            textBox2.Text = "BDT.";
            // textBox4 = Payment ID, keep it (auto-generated)

            rbtnBkash.Checked = false;
            rbtnNagad.Checked = false;
            rbtnCreditDebitCard.Checked = false;
            rbtnCash.Checked = false;

            dtPaymentDate.Value = DateTime.Today;
            cmbPaymentStatus.SelectedIndex = 0;
        }
    }
}
