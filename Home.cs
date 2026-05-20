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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            plhome.Visible = false;
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            int role = SessionManager.UserTypeId;
            

            if (role == 2) 
            {
                btnTRE.Visible = false; 
                btnHL.Visible = false;  
            }
            else if (role == 3)
            {
                btnTRE.Visible = false;  
                btnHL.Visible = false; 
                btnSH.Visible = false;  
            }
        }

        private void btnBK_Click(object sender, EventArgs e)
        {
            plhome.Visible = true;
            LoadForm(new Seat());
        }

        public void LoadForm(Form f)
        {
            plhome.Controls.Clear();

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            plhome.Controls.Add(f);
            f.Show();
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            plhome.Controls.Clear();
            plhome.Visible=false;
        }

        private void btnTRE_Click(object sender, EventArgs e)
        {
            plhome.Visible = true;
            LoadForm(new TheatreForm());
        }

        private void btnSH_Click(object sender, EventArgs e)
        {
            plhome.Visible = true;
            LoadForm(new ShowManagement());
        }

        private void btnHL_Click(object sender, EventArgs e)
        {
            plhome.Visible = true;
            LoadForm(new HallManagement());
        }

        private void btnPAY_Click(object sender, EventArgs e)
        {
            plhome.Visible = true;
            LoadForm(new PaymentDetails());
        }

        private void btnLOG_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTIk_Click(object sender, EventArgs e)
        {
            plhome.Visible = true;
            LoadForm(new Ticket());
        }

        private void plhome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUserinfo_Click(object sender, EventArgs e)
        {
            AddUserForm form = new AddUserForm();
            form.Show();
        }
    }
}
