using System;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class TheatreForm : Form
    {
        DBAccessHelper db = new DBAccessHelper();

        public TheatreForm()
        {
            InitializeComponent();
        }
        private void LoadTheatres()
        {
            try
            {
                string query = "SELECT * FROM Theatre";
                ResultSet result = db.GetQueryData(query);

                if (!result.HasError)
                    dgvTheatreInfo.DataSource = result.Data;
                else
                    MessageBox.Show(result.Message, "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void ClearFields()
        {
            txtTheatreName.Clear();
            txtContact.Clear();
            cmbLocation.SelectedIndex = -1;
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTheatreName.Text))
            {
                MessageBox.Show("Please enter a Theatre Name.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContact.Text) ||
                !txtContact.Text.StartsWith("01") ||
                txtContact.Text.Length != 11)
            {
                MessageBox.Show("Contact must start with 01 and be 11 digits.");
                return false;
            }

            if (cmbLocation.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Location.");
                return false;
            }

            return true;
        }
        private void TheatreForm_Load(object sender, EventArgs e)
        {
            LoadTheatres();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                string query = "INSERT INTO Theatre (TheatreName, Location, Contact) " +
                               "VALUES ('" + txtTheatreName.Text + "', '" +
                               cmbLocation.Text + "', '" + txtContact.Text + "')";

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError) { MessageBox.Show(result.Message, "Error"); return; }

                MessageBox.Show("Theatre added successfully!");
                ClearFields();
                LoadTheatres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTheatreInfo.CurrentRow == null)
                {
                    MessageBox.Show("Please select a theatre from the table.");
                    return;
                }

                if (!ValidateInputs()) return;

                int theatreId = Convert.ToInt32(
                    dgvTheatreInfo.CurrentRow.Cells["TheatreId"].Value);

                string query = "UPDATE Theatre SET " +
                               "TheatreName = '" + txtTheatreName.Text + "', " +
                               "Location = '" + cmbLocation.Text + "', " +
                               "Contact = '" + txtContact.Text + "' " +
                               "WHERE TheatreId = " + theatreId;

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError) 
                { 
                    MessageBox.Show(result.Message, "Error"); return;
                }

                MessageBox.Show("Updated successfully!");
                ClearFields();
                LoadTheatres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTheatreInfo.CurrentRow == null)
                {
                    MessageBox.Show("Please select a row.");
                    return;
                }

                int theatreId = Convert.ToInt32(dgvTheatreInfo.CurrentRow.Cells["TheatreId"].Value);

                string theatreName = dgvTheatreInfo.CurrentRow.Cells["TheatreName"].Value.ToString();
                ResultSet halls = db.GetQueryData("SELECT HallId FROM Hall WHERE TheatreId = " + theatreId);

                if (!halls.HasError && halls.Data != null)
                {
                    foreach (System.Data.DataRow hallRow in halls.Data.Rows)
                    {
                        int hallId = Convert.ToInt32(hallRow["HallId"]);
                        ResultSet shows = db.GetQueryData("SELECT ShowId FROM Shows WHERE HallId = " + hallId);

                        if (!shows.HasError && shows.Data != null)
                        {
                            foreach (System.Data.DataRow showRow in shows.Data.Rows)
                            {
                                int showId = Convert.ToInt32(showRow["ShowId"]);

                                db.ExecuteNonQuery(
                                    "DELETE FROM Payment WHERE TicketId IN " +
                                    "(SELECT TicketId FROM Ticket WHERE ShowId = " + showId + ")");

                                db.ExecuteNonQuery("DELETE FROM Ticket WHERE ShowId = " + showId);
                            }
                        }

                        db.ExecuteNonQuery(
                            "DELETE FROM Booking WHERE BookingId NOT IN " +
                            "(SELECT DISTINCT BookingId FROM Ticket)");

                        db.ExecuteNonQuery("DELETE FROM Shows WHERE HallId = " + hallId);
                        db.ExecuteNonQuery("DELETE FROM Hall WHERE HallId = " + hallId);
                    }
                }
                ResultSet result = db.ExecuteNonQuery("DELETE FROM Theatre WHERE TheatreId = " + theatreId);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message, "Error"); return;
                }

                MessageBox.Show("Theatre and all related data deleted successfully!");
                ClearFields();
                LoadTheatres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        private void dgvTheatreInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTheatreInfo.Rows[e.RowIndex];
            txtTheatreName.Text = row.Cells["TheatreName"].Value.ToString();
            txtContact.Text = row.Cells["Contact"].Value.ToString();
            cmbLocation.Text = row.Cells["Location"].Value.ToString();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
