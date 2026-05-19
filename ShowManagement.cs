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
            LoadHalls();
            LoadShows();
        }

        private void LoadHalls()
        {
            cmbHallNo.Items.Clear();

            cmbHallNo.Items.Add("Hall A");
            cmbHallNo.Items.Add("Hall B");
        }

        private void cmbHallNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice();
        }

        private void SetPrice()
        {
            if (cmbHallNo.SelectedItem == null)
                return;

            if (cmbHallNo.Text == "Hall A")
                txtShowPrice.Text = "650";

            else if (cmbHallNo.Text == "Hall B")
                txtShowPrice.Text = "1000";

            else
                txtShowPrice.Text = "";
        }

        private void LoadShows()
        {
            string query =
                "SELECT s.ShowId, s.MovieName, h.HallName, " +
                "s.ShowDate, s.ShowTime, s.ShowPrice " +
                "FROM Shows s " +
                "INNER JOIN Hall h ON s.HallId = h.HallId " +
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
                MessageBox.Show(
                    result.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMovie.Text) ||
                cmbHallNo.SelectedItem == null ||
                cmbTime.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please fill all fields.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int hallId = (cmbHallNo.Text == "Hall A") ? 1 : 2;

            string checkQuery =
                "SELECT * FROM Shows WHERE " +
                "HallId=" + hallId + " AND " +
                "ShowDate='" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "' AND " +
                "ShowTime='" + cmbTime.Text + "'";

            ResultSet checkResult = db.GetQueryData(checkQuery);

            if (checkResult.Data.Rows.Count > 0)
            {
                MessageBox.Show(
                    "A show already exists in this hall at this time.",
                    "Schedule Conflict",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string query =
                "INSERT INTO Shows " +
                "(ShowDate, ShowTime, ShowPrice, HallId, MovieName) " +
                "VALUES (" +
                "'" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "', " +
                "'" + cmbTime.Text + "', " +
                "'" + txtShowPrice.Text + "', " +
                hallId + ", " +
                "'" + txtMovie.Text + "')";

            ResultSet result = db.ExecuteNonQuery(query);

            if (result.HasError)
            {
                MessageBox.Show(
                    result.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Show Added Successfully",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadShows();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShowId.Text))
            {
                MessageBox.Show(
                    "Select a show first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtMovie.Text) ||
                cmbHallNo.SelectedItem == null ||
                cmbTime.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please fill all fields.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int hallId = (cmbHallNo.Text == "Hall A") ? 1 : 2;

            int showId = Convert.ToInt32(txtShowId.Text);

            string checkQuery =
                "SELECT * FROM Shows WHERE " +
                "HallId=" + hallId + " AND " +
                "ShowDate='" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "' AND " +
                "ShowTime='" + cmbTime.Text + "' AND " +
                "ShowId!=" + showId;

            ResultSet checkResult = db.GetQueryData(checkQuery);

            if (checkResult.Data.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Another show already exists at this time.",
                    "Schedule Conflict",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // =========================
            // UPDATE QUERY
            // =========================
            string query =
                "UPDATE Shows SET " +
                "MovieName='" + txtMovie.Text + "', " +
                "ShowDate='" + dtpShowDate.Value.ToString("yyyy-MM-dd") + "', " +
                "ShowTime='" + cmbTime.Text + "', " +
                "ShowPrice='" + txtShowPrice.Text + "', " +
                "HallId=" + hallId + " " +
                "WHERE ShowId=" + showId;

            ResultSet result = db.ExecuteNonQuery(query);

            if (result.HasError)
            {
                MessageBox.Show(
                    result.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Show Updated Successfully",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadShows();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShowInfo.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a show to delete.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string movieName =
                dgvShowInfo.CurrentRow.Cells["MovieName"]
                .Value?.ToString();

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete the show for '" +
                movieName + "' ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            int showId =
                Convert.ToInt32(
                    dgvShowInfo.CurrentRow.Cells["ShowId"].Value);

            string deleteTickets =
                "DELETE FROM Ticket WHERE ShowId=" + showId;

            db.ExecuteNonQuery(deleteTickets);

            string deleteShow =
                "DELETE FROM Shows WHERE ShowId=" + showId;

            ResultSet result = db.ExecuteNonQuery(deleteShow);

            if (result.HasError)
            {
                MessageBox.Show(
                    result.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Show Deleted Successfully",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadShows();
            ClearFields();
        }

        private void dgvShowInfo_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvShowInfo.Rows[e.RowIndex];

            txtShowId.Text =
                row.Cells["ShowId"].Value?.ToString();

            txtMovie.Text =
                row.Cells["MovieName"].Value?.ToString();

            cmbHallNo.Text =
                row.Cells["HallName"].Value?.ToString();

            dtpShowDate.Value =
                Convert.ToDateTime(
                    row.Cells["ShowDate"].Value);

            cmbTime.Text =
                row.Cells["ShowTime"].Value?.ToString();

            txtShowPrice.Text =
                row.Cells["ShowPrice"].Value?.ToString();
        }

        private void ClearFields()
        {
            txtShowId.Text = "Auto Generated";

            txtMovie.Clear();

            cmbHallNo.SelectedIndex = -1;

            cmbTime.SelectedIndex = -1;

            txtShowPrice.Clear();

            dtpShowDate.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtShowPrice_TextChanged(
            object sender,
            EventArgs e)
        {

        }
        private void dgvShowInfo_CellContentDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvShowInfo.Rows[e.RowIndex];

            txtShowId.Text =
                row.Cells["ShowId"].Value.ToString();

            txtMovie.Text =
                row.Cells["MovieName"].Value.ToString();

            cmbHallNo.Text =
                row.Cells["HallName"].Value.ToString();

            dtpShowDate.Value =
                Convert.ToDateTime(
                    row.Cells["ShowDate"].Value);

            cmbTime.Text =
                row.Cells["ShowTime"].Value.ToString();

            txtShowPrice.Text =
                row.Cells["ShowPrice"].Value.ToString();
        }

        private void dgvShowInfo_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

        }

        private void cmbTime_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }
    }
}
