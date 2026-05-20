using Movie_Ticket_Management_System;
using MovieTicketBookingSystem;
using System;
using System.Data;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class ShowManagement : Form
    {
        DBAccessHelper db = new DBAccessHelper();

        public ShowManagement()
        {
            InitializeComponent();
        }
        private void ShowManagement_Load_1(object sender, EventArgs e)
        {
            LoadTheatres();
            LoadShows();
        }
        private void LoadTheatres()
        {
            try
            {
                cmbtheatre.SelectedIndexChanged -= cmbtheatre_SelectedIndexChanged;

                string query = "SELECT TheatreId, TheatreName FROM Theatre";

                ResultSet result = db.GetQueryData(query);

                if (!result.HasError && result.Data != null)
                {
                    cmbtheatre.DataSource = result.Data;
                    cmbtheatre.DisplayMember = "TheatreName";
                    cmbtheatre.ValueMember = "TheatreId";
                    cmbtheatre.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Error loading theatres: " + result.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmbtheatre.SelectedIndexChanged += cmbtheatre_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbtheatre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbHallNo.DataSource = null;
                cmbHallNo.Items.Clear();
                txtShowPrice.Clear();

                if (cmbtheatre.SelectedIndex < 0 || cmbtheatre.SelectedValue == null)
                    return;
                int theatreId;
                if (!int.TryParse(cmbtheatre.SelectedValue.ToString(), out theatreId))
                    return;

                string query = "SELECT HallId, HallName FROM Hall WHERE TheatreId = " + theatreId;

                ResultSet result = db.GetQueryData(query);

                if (!result.HasError && result.Data != null)
                {
                    cmbHallNo.SelectedIndexChanged -= cmbHallNo_SelectedIndexChanged;

                    cmbHallNo.DataSource = result.Data;
                    cmbHallNo.DisplayMember = "HallName";
                    cmbHallNo.ValueMember = "HallId";
                    cmbHallNo.SelectedIndex = -1;

                    cmbHallNo.SelectedIndexChanged += cmbHallNo_SelectedIndexChanged;
                }
                else
                {
                    MessageBox.Show("Error loading halls: " + result.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbHallNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice();
        }

        private void SetPrice()
        {
            if (cmbHallNo.SelectedItem == null) return;

            DataRowView row = cmbHallNo.SelectedItem as DataRowView;
            if (row == null) return;

            string hallName = row["HallName"].ToString();

            if (hallName == "Hall A")
                txtShowPrice.Text = "650";
            else if (hallName == "Hall B")
                txtShowPrice.Text = "1000";
            else
                txtShowPrice.Text = "";
        }
        private void LoadShows()
        {
            try
            {
                string query =
                    "SELECT s.ShowId, s.MovieName, t.TheatreName, h.HallName, " +
                    "s.ShowDate, s.ShowTime, s.ShowPrice " +
                    "FROM Shows s " +
                    "INNER JOIN Hall h ON s.HallId = h.HallId " +
                    "INNER JOIN Theatre t ON h.TheatreId = t.TheatreId " +
                    "ORDER BY s.ShowDate DESC, s.ShowTime";

                ResultSet result = db.GetQueryData(query);

                if (!result.HasError)
                {
                    dgvShowInfo.DataSource = result.Data;

                    if (dgvShowInfo.Columns.Contains("ShowId"))
                        dgvShowInfo.Columns["ShowId"].Visible = false;
                }
                else
                {
                    MessageBox.Show(result.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbtheatre.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a Theatre.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMovie.Text))
                {
                    MessageBox.Show("Please enter a Movie name.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbHallNo.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a Hall.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTime.SelectedItem == null)
                {
                    MessageBox.Show("Please select a Time.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int hallId = Convert.ToInt32(cmbHallNo.SelectedValue);

                string checkQuery =
                    "SELECT * FROM Shows WHERE " +
                    "HallId = " + hallId + " AND " +
                    "ShowDate = '" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "' AND " +
                    "ShowTime = '" + cmbTime.Text + "'";

                ResultSet checkResult = db.GetQueryData(checkQuery);

                if (checkResult.Data != null && checkResult.Data.Rows.Count > 0)
                {
                    MessageBox.Show("A show already exists in this hall at this time.",
                        "Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query =
                    "INSERT INTO Shows (ShowDate, ShowTime, ShowPrice, HallId, MovieName) " +
                    "VALUES (" +
                    "'" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "', " +
                    "'" + cmbTime.Text + "', " +
                    "'" + txtShowPrice.Text + "', " +
                    hallId + ", " +
                    "'" + txtMovie.Text + "')";

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Show Added Successfully",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadShows();
                ClearFields();
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
                if (string.IsNullOrWhiteSpace(txtShowId.Text) ||
                    txtShowId.Text == "Auto Generated")
                {
                    MessageBox.Show("Select a show from the grid first.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMovie.Text) ||
                    cmbHallNo.SelectedIndex < 0 ||
                    cmbTime.SelectedItem == null)
                {
                    MessageBox.Show("Please fill all fields.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int hallId = Convert.ToInt32(cmbHallNo.SelectedValue);
                int showId = Convert.ToInt32(txtShowId.Text);

                string checkQuery =
                    "SELECT * FROM Shows WHERE " +
                    "HallId = " + hallId + " AND " +
                    "ShowDate = '" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "' AND " +
                    "ShowTime = '" + cmbTime.Text + "' AND " +
                    "ShowId != " + showId;

                ResultSet checkResult = db.GetQueryData(checkQuery);

                if (checkResult.Data != null && checkResult.Data.Rows.Count > 0)
                {
                    MessageBox.Show("Another show already exists at this time.",
                        "Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query =
                    "UPDATE Shows SET " +
                    "MovieName = '" + txtMovie.Text + "', " +
                    "ShowDate = '" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "', " +
                    "ShowTime = '" + cmbTime.Text + "', " +
                    "ShowPrice = '" + txtShowPrice.Text + "', " +
                    "HallId = " + hallId + " " +
                    "WHERE ShowId = " + showId;

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Show Updated Successfully",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadShows();
                ClearFields();
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
                if (dgvShowInfo.CurrentRow == null)
                {
                    MessageBox.Show("Please select a show to delete.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string movieName = dgvShowInfo.CurrentRow.Cells["MovieName"].Value?.ToString();

                DialogResult confirm = MessageBox.Show(
                    "Delete show for '" + movieName + "'?\nAll related tickets will also be deleted.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                int showId = Convert.ToInt32(dgvShowInfo.CurrentRow.Cells["ShowId"].Value);

                string deletePayments =
                    "DELETE FROM Payment WHERE TicketId IN " +
                    "(SELECT TicketId FROM Ticket WHERE ShowId = " + showId + ")";
                db.ExecuteNonQuery(deletePayments);

                string deleteTickets = "DELETE FROM Ticket WHERE ShowId = " + showId;
                db.ExecuteNonQuery(deleteTickets);

                string deleteBookings =
                    "DELETE FROM Booking WHERE BookingId NOT IN " +
                    "(SELECT DISTINCT BookingId FROM Ticket)";
                db.ExecuteNonQuery(deleteBookings);

                string deleteShow = "DELETE FROM Shows WHERE ShowId = " + showId;
                ResultSet result = db.ExecuteNonQuery(deleteShow);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Show Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadShows();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvShowInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void ClearFields()
        {
            txtShowId.Text = "Auto Generated";
            txtMovie.Clear();
            txtShowPrice.Clear();
            dtpShowDate.Value = DateTime.Now;
            cmbtheatre.SelectedIndex = -1;
            cmbHallNo.DataSource = null;
            cmbHallNo.Items.Clear();
            cmbTime.SelectedIndex = -1;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvShowInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvShowInfo.Rows[e.RowIndex];

            txtShowId.Text = row.Cells["ShowId"].Value?.ToString();
            txtMovie.Text = row.Cells["MovieName"].Value?.ToString();
            dtpShowDate.Value = Convert.ToDateTime(row.Cells["ShowDate"].Value);
            cmbTime.Text = row.Cells["ShowTime"].Value?.ToString();
            txtShowPrice.Text = row.Cells["ShowPrice"].Value?.ToString();

            string theatreName = row.Cells["TheatreName"].Value?.ToString();
            foreach (DataRowView item in cmbtheatre.Items)
            {
                if (item["TheatreName"].ToString() == theatreName)
                {
                    cmbtheatre.SelectedItem = item;
                    break;
                }
            }

            string hallName = row.Cells["HallName"].Value?.ToString();
            foreach (DataRowView item in cmbHallNo.Items)
            {
                if (item["HallName"].ToString() == hallName)
                {
                    cmbHallNo.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
