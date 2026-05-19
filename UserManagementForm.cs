
using MovieTheatreManagementSystem;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Movie_Ticket_Management_System
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            txtID.Text = "Auto Generated";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string password = txtPassword.Text;
                
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Name is required");
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

                if (cmbut.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a role");
                    return;
                }

                int usertypeid = cmbut.SelectedIndex + 2;

                DBAccessHelper db = new DBAccessHelper();

                string query = "INSERT INTO Users " +
                "(UserName, Password, Email, Phone, UserTypeId) " +
                "VALUES " +
                "('" + name + "', '" + password + "', '" + email + "', '" + phone + "', " + usertypeid + ")";

                db.ExecuteNonQuery(query);

                MessageBox.Show("User Added Successfully");

                ResetForm();
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
    }
}