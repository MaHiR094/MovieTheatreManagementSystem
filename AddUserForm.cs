using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class AddUserForm : Form
    {
        
        SqlConnection con = new SqlConnection("Data Source=MAHIR\\SQLEXPRESS;Initial Catalog=MovieTheatreManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        SqlDataAdapter adp;

        public AddUserForm()
        {
            InitializeComponent();
        }
        private void dbConnection(string query)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void dbloadConnection()
        {
            try
            {
                string query = "SELECT * FROM Users where userTypeId <> 1";

                adp = new SqlDataAdapter(query, con);

                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearScreen()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtEmail.Clear();
            txtPhone.Clear();

            cbRole.SelectedIndex = -1;

            txtId.Text = "Auto incremented";
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            dbloadConnection();

            dataGridView1.ClearSelection();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPass.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Username is required");
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password is required");
                    return;
                }

                if (password.Length <= 4)
                {
                    MessageBox.Show("Password must be more than 4 characters");
                    return;
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Email is required");
                    return;
                }

                if (!email.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Email must end with @gmail.com");
                    return;
                }

                if (string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("Phone is required");
                    return;
                }

                if (phone.Length != 11 || !phone.StartsWith("01") || !phone.All(char.IsDigit))
                {
                    MessageBox.Show("Phone must start with 01 and contain exactly 11 digits");
                    return;
                }

                if (cbRole.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a role");
                    return;
                }

                int roleId = cbRole.SelectedIndex + 2;

                string query = "";

                if (txtId.Text == "Auto incremented")
                {
                    query =
                        "INSERT INTO Users " +
                        "(UserName, Password, Email, Phone, UserTypeId) " +
                        "VALUES (" +
                        "'" + username.Replace("'", "''") + "'," +
                        "'" + password.Replace("'", "''") + "'," +
                        "'" + email.Replace("'", "''") + "'," +
                        "'" + phone + "'," +
                        roleId + ")";
                }

                else
                {
                    query =
                        "UPDATE Users SET " +
                        "UserName = '" + username.Replace("'", "''") + "', " +
                        "Password = '" + password.Replace("'", "''") + "', " +
                        "Email = '" + email.Replace("'", "''") + "', " +
                        "Phone = '" + phone + "', " +
                        "UserTypeId = " + roleId + " " +
                        "WHERE UserId = " + txtId.Text;
                }

                dbConnection(query);

                MessageBox.Show("User Saved Successfully");

                dbloadConnection();

                clearScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dbloadConnection();

            clearScreen();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "Auto incremented")
                {
                    MessageBox.Show("Please select a user first");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure to delete this user?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string query =
                        "DELETE FROM Users WHERE UserId = " + txtId.Text;

                    dbConnection(query);

                    MessageBox.Show("User Deleted Successfully");

                    dbloadConnection();

                    clearScreen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var row = dataGridView1.Rows[e.RowIndex];

                txtId.Text = row.Cells["UserId"].Value.ToString();
                txtUsername.Text = row.Cells["UserName"].Value.ToString();
                txtPass.Text = row.Cells["Password"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();

                int roleId = Convert.ToInt32(row.Cells["UserTypeId"].Value);

                cbRole.SelectedIndex = roleId - 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
