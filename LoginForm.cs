using Movie_Ticket_Management_System;
using MovieTicketBookingSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTheatreManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtemail.Text;
            string password = txtpassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            try
            {
                DBAccessHelper db = new DBAccessHelper();

                string query = "SELECT UserId, UserName, UserTypeId FROM Users WHERE UserName = '"
                             + username + "' AND Password = '" + password + "'";

                ResultSet result = db.GetQueryData(query);

                if (result.HasError)
                {
                    MessageBox.Show("Database error: " + result.Message);
                    return;
                }

                if (result.Data.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                SessionManager.UserId = Convert.ToInt32(result.Data.Rows[0]["UserId"]);
                SessionManager.UserName = result.Data.Rows[0]["UserName"].ToString();
                SessionManager.UserTypeId = Convert.ToInt32(result.Data.Rows[0]["UserTypeId"]);

                MessageBox.Show("Welcome, " + SessionManager.UserName + "!");

                Home form = new Home();
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message);
            }
        }

        private void btnnewuser_Click(object sender, EventArgs e)
        {
            UserManagementForm form = new UserManagementForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}