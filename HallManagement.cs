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

        // FORM LOAD
        private void HallManagement_Load(object sender, EventArgs e)
        {
            LoadHallData();
            LoadTheatre();
        }

        // LOAD HALL DATA
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

        // LOAD THEATRE (SHOW NAME, STORE ID)
        private void LoadTheatre()
        {
            try
            {
                string query =
                    "SELECT TheatreId, TheatreName FROM Theatre";

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

        // CLEAR
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

        // ADD
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

                int TotalSeat = 56;

                string query =
                    "INSERT INTO Hall(HallName, HallType, TotalSeat, TheatreId) " +
                    "VALUES('" + hallName + "', '" +
                    hallType + "', '" +
                    TotalSeat + "', '" +
                    theatreId + "')";

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

        // UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
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

        // DELETE
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

                string query =
                    "DELETE FROM Hall WHERE HallId = " + hallId;

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Deleted Successfully");

                ClearFields();
                LoadHallData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // GRID CLICK
        private void dgvHallInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvHallInfo.Rows[e.RowIndex];

                    txtHallId.Text = row.Cells["HallId"].Value.ToString();
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

        // SEARCH
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query =
                    "SELECT Hall.HallId, Hall.HallName, Hall.HallType, " +
                    "Theatre.TheatreName " +
                    "FROM Hall " +
                    "INNER JOIN Theatre " +
                    "ON Hall.TheatreId = Theatre.TheatreId " +
                    "WHERE Hall.HallName LIKE '%" + txtSearch.Text + "%'";

                ResultSet result = db.GetQueryData(query);

                if (!result.HasError)
                {
                    dgvHallInfo.DataSource = result.Data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}