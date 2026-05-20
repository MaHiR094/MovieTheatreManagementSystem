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
                HideButtonRow(btnTRE);
                HideButtonRow(btnHL);
            }
            else if (role == 3)
            {
                HideButtonRow(btnTRE);
                HideButtonRow(btnHL);
                HideButtonRow(btnSH);
                HideButtonRow(btnUserinfo);
            }
        }

        private void HideButtonRow(Button button)
        {
            if (!tblpnlBtns.Controls.Contains(button)) return;

            int row = tblpnlBtns.GetRow(button);
            if (row < 0) return;

            tblpnlBtns.Controls.Remove(button);

            if (tblpnlBtns.RowCount <= row) tblpnlBtns.RowCount = row + 1;
            while (tblpnlBtns.RowStyles.Count <= row)
                tblpnlBtns.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));

            tblpnlBtns.RowStyles[row].SizeType = SizeType.Absolute;
            tblpnlBtns.RowStyles[row].Height = 0F;

            tblpnlBtns.PerformLayout();
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
