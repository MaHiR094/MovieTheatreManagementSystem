using Movie_Ticket_Management_System;
using MovieTicketBookingSystem;
using System;
using System.Data;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class HallManagement : Form
    {
        DBAccessHelper db = new DBAccessHelper();

        public HallManagement()
        {
            InitializeComponent();
        }
        private void HallManagement_Load(object sender, EventArgs e)
        {
            LoadHallData();
            LoadTheatre();
        }
        private void LoadHallData()
        {
            try
            {
                string query =
                    "SELECT Hall.HallId, Hall.HallName, Hall.HallType, " +
                    "Theatre.TheatreName " +
                    "FROM Hall " +
                    "INNER JOIN Theatre " +
                    "ON Hall.TheatreId = Theatre.TheatreId";

                ResultSet result = db.GetQueryData(query);

                if (!result.HasError)
                {
                    dgvHallInfo.DataSource = result.Data;
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTheatre()
        {
            try
            {
                string query ="SELECT TheatreId, TheatreName FROM Theatre";

                ResultSet result = db.GetQueryData(query);

                if (!result.HasError)
                {
                    cmbTheatre.DataSource = result.Data;
                    cmbTheatre.DisplayMember = "TheatreName";
                    cmbTheatre.ValueMember = "TheatreId";
                    cmbTheatre.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearFields()
        {
            
            cmbHallName.SelectedIndex = -1;
            cmbHallType.SelectedIndex = -1;
            cmbTheatre.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbHallName.Text == "")
                {
                    MessageBox.Show("Please Select Hall Name");
                    return;
                }

                if (cmbHallType.Text == "")
                {
                    MessageBox.Show("Please Select Hall Type");
                    return;
                }

                if (cmbTheatre.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Theatre");
                    return;
                }

                string hallName = cmbHallName.Text;
                string hallType = cmbHallType.Text;
                string theatreId = cmbTheatre.SelectedValue.ToString();
                string countQuery = "SELECT COUNT(*) AS HallCount FROM Hall WHERE TheatreId = " + theatreId;

                ResultSet countResult = db.GetQueryData(countQuery);

                if (!countResult.HasError && countResult.Data != null && countResult.Data.Rows.Count > 0)
                {
                    int hallCount = Convert.ToInt32(countResult.Data.Rows[0]["HallCount"]);

                    if (hallCount >= 2)
                    {
                        MessageBox.Show(
                            "This theatre already has 2 halls.\nNo more halls can be added.",
                            "Limit Reached",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                string dupQuery = "SELECT COUNT(*) AS DupCount FROM Hall " +
                                 "WHERE TheatreId = " + theatreId + " " +
                                 "AND HallName = '" + hallName + "'";

                ResultSet dupResult = db.GetQueryData(dupQuery);

                if (!dupResult.HasError && dupResult.Data != null && dupResult.Data.Rows.Count > 0)
                {
                    int dupCount = Convert.ToInt32(dupResult.Data.Rows[0]["DupCount"]);

                    if (dupCount > 0)
                    {
                        MessageBox.Show(
                            "'" + hallName + "' already exists in this theatre.",
                            "Duplicate Hall",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                int totalSeat = 56;

                string query = "INSERT INTO Hall(HallName, HallType, TotalSeat, TheatreId) " +
                              "VALUES('" + hallName + "', '" + hallType + "', '" + totalSeat + "', '" + theatreId + "')";

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Hall Added Successfully");
                ClearFields();
                LoadHallData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHallInfo.CurrentRow == null)
                {
                    MessageBox.Show("Please Select A Row");
                    return;
                }

                int hallId = Convert.ToInt32(dgvHallInfo.CurrentRow.Cells["HallId"].Value);

                string hallName = cmbHallName.Text;
                string hallType = cmbHallType.Text;
                string theatreId = cmbTheatre.SelectedValue.ToString();

                string query =
                    "UPDATE Hall SET " +
                    "HallName = '" + hallName + "', " +
                    "HallType = '" + hallType + "', " +
                    "TheatreId = '" + theatreId + "' " +
                    "WHERE HallId = " + hallId;

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Updated Successfully");

                ClearFields();
                LoadHallData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHallInfo.CurrentRow == null)
                {
                    MessageBox.Show("Please Select A Row");
                    return;
                }

                int hallId = Convert.ToInt32(
                    dgvHallInfo.CurrentRow.Cells["HallId"].Value);

                DialogResult confirm = MessageBox.Show(
                    "Deleting this hall will also delete all its Shows, Tickets and Bookings.\nAre you sure?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                string getShows = "SELECT ShowId FROM Shows WHERE HallId = " + hallId;
                ResultSet showResult = db.GetQueryData(getShows);

                if (!showResult.HasError && showResult.Data != null)
                {
                    foreach (System.Data.DataRow showRow in showResult.Data.Rows)
                    {
                        int showId = Convert.ToInt32(showRow["ShowId"]);

                        string deletePayments =
                            "DELETE FROM Payment WHERE TicketId IN " +
                            "(SELECT TicketId FROM Ticket WHERE ShowId = " + showId + ")";
                        db.ExecuteNonQuery(deletePayments);

                        string deleteTickets =
                            "DELETE FROM Ticket WHERE ShowId = " + showId;
                        db.ExecuteNonQuery(deleteTickets);
                    }
                }

                string deleteBookings =
                    "DELETE FROM Booking WHERE BookingId NOT IN " +
                    "(SELECT DISTINCT BookingId FROM Ticket)";
                db.ExecuteNonQuery(deleteBookings);

                string deleteShows = "DELETE FROM Shows WHERE HallId = " + hallId;
                db.ExecuteNonQuery(deleteShows);

                string deleteHall = "DELETE FROM Hall WHERE HallId = " + hallId;
                ResultSet result = db.ExecuteNonQuery(deleteHall);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Hall and all related data deleted successfully!");
                ClearFields();
                LoadHallData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvHallInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvHallInfo.Rows[e.RowIndex];

                    cmbHallName.Text = row.Cells["HallName"].Value.ToString();
                    cmbHallType.Text = row.Cells["HallType"].Value.ToString();
                    cmbTheatre.Text = row.Cells["TheatreName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}