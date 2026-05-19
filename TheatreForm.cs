using Movie_Ticket_Management_System;
using MovieTicketBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class TheatreForm : Form
    {
        public TheatreForm()
        {
            InitializeComponent();
        }

        DBAccessHelper db = new DBAccessHelper();

        private void TheatreForm_Load(object sender, EventArgs e)
        {
            try
            {
                string showQuery = "SELECT * FROM Theatre";
                ResultSet data = db.GetQueryData(showQuery);

                if (!data.HasError)
                {
                    dgvTheatreInfo.DataSource = data.Data;
                }
                else
                {
                    MessageBox.Show(data.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Action()
        {
            txtTheatreName.Clear();
            txtContact.Clear();
            cmbLocation.SelectedIndex = -1;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
           Action();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string theatreName = txtTheatreName.Text;
                string contact = txtContact.Text;
                string location = cmbLocation.Text;

                if (string.IsNullOrWhiteSpace(theatreName) ||
                    string.IsNullOrWhiteSpace(contact))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }


                if (!contact.StartsWith("01") || contact.Length != 11)
                {
                    MessageBox.Show("Contact number must start with 01 and be 11 digits.");
                    return;
                }

                if (cmbLocation.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a location.");
                    return;
                }

                string query = "INSERT INTO Theatre " +
                               "(TheatreName, Location, Contact) " +
                               "VALUES " +
                               "('" + theatreName + "', '" + location + "', '" + contact + "')";

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Theatre added successfully!");
                Action();

                string showQuery = "SELECT * FROM Theatre";
                ResultSet data = db.GetQueryData(showQuery);

                if (!data.HasError)
                {
                    dgvTheatreInfo.DataSource = data.Data;
                }
                else
                {
                    MessageBox.Show(data.Message);
                }
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
                if (dgvTheatreInfo.CurrentRow == null)
                {
                    MessageBox.Show("Please select a row.");
                    return;
                }

                int theatreId = Convert.ToInt32(dgvTheatreInfo.CurrentRow.Cells["TheatreId"].Value);

                string query = "DELETE FROM Theatre WHERE TheatreId = '" + theatreId + "'";

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Deleted successfully!");

                string showQuery = "SELECT * FROM Theatre";
                dgvTheatreInfo.DataSource = db.GetQueryData(showQuery).Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTheatreInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvTheatreInfo.Rows[e.RowIndex];

                    txtTheatreName.Text = row.Cells["TheatreName"].Value.ToString();
                    txtContact.Text = row.Cells["Contact"].Value.ToString();
                    cmbLocation.Text = row.Cells["Location"].Value.ToString();
                }
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
                if (dgvTheatreInfo.CurrentRow == null)
                {
                    MessageBox.Show("Please select a theatre from the table.");
                    return;
                }

                int theatreId = Convert.ToInt32(dgvTheatreInfo.CurrentRow.Cells["TheatreId"].Value);

                string theatreName = txtTheatreName.Text;
                string contact = txtContact.Text;
                string location = cmbLocation.Text;

                if (string.IsNullOrWhiteSpace(theatreName) ||
                    string.IsNullOrWhiteSpace(contact))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                if (!contact.StartsWith("01") || contact.Length != 11)
                {
                    MessageBox.Show("Contact must start with 01 and be 11 digits.");
                    return;
                }

                if (cmbLocation.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a location.");
                    return;
                }

                string query = "UPDATE Theatre SET " +
                               "TheatreName = '" + theatreName + "', " +
                               "Location = '" + location + "', " +
                               "Contact = '" + contact + "' " +
                               "WHERE TheatreId = '" + theatreId + "'";

                ResultSet result = db.ExecuteNonQuery(query);

                if (result.HasError)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Updated successfully!");

                Action();

                string showQuery = "SELECT * FROM Theatre";
                ResultSet data = db.GetQueryData(showQuery);

                if (!data.HasError)
                {
                    dgvTheatreInfo.DataSource = data.Data;
                }
                else
                {
                    MessageBox.Show(data.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
