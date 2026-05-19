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

            try
            {
                DBAccessHelper db = new DBAccessHelper();

                string query = "Select UserName, Password from Users where UserName = '"
                                + username + "' and Password = '" + password + "'";

                ResultSet result = db.GetQueryData(query);


                if (result.HasError)
                {
                    MessageBox.Show("Database Error");
                    return;
                }

                if (result.Data.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Login");
                    return;
                }

                MessageBox.Show("Welcome");

                Home form = new Home();
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Login Error");
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