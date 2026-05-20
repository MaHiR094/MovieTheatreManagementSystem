namespace MovieTheatreManagementSystem
{
    partial class ShowManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblShowManagement = new System.Windows.Forms.Label();
            this.lblShowId = new System.Windows.Forms.Label();
            this.lblMovie = new System.Windows.Forms.Label();
            this.lblHall = new System.Windows.Forms.Label();
            this.lblTicketPrice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblShowTime = new System.Windows.Forms.Label();
            this.txtShowId = new System.Windows.Forms.TextBox();
            this.txtShowPrice = new System.Windows.Forms.TextBox();
            this.cmbHallNo = new System.Windows.Forms.ComboBox();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.dtpShowDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvShowInfo = new System.Windows.Forms.DataGridView();
            this.txtMovie = new System.Windows.Forms.TextBox();
            this.lbltheatre = new System.Windows.Forms.Label();
            this.cmbtheatre = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShowManagement
            // 
            this.lblShowManagement.AutoSize = true;
            this.lblShowManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowManagement.Location = new System.Drawing.Point(12, 9);
            this.lblShowManagement.Name = "lblShowManagement";
            this.lblShowManagement.Size = new System.Drawing.Size(246, 29);
            this.lblShowManagement.TabIndex = 28;
            this.lblShowManagement.Text = "Show Management";
            // 
            // lblShowId
            // 
            this.lblShowId.AutoSize = true;
            this.lblShowId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowId.Location = new System.Drawing.Point(60, 62);
            this.lblShowId.Name = "lblShowId";
            this.lblShowId.Size = new System.Drawing.Size(93, 24);
            this.lblShowId.TabIndex = 29;
            this.lblShowId.Text = "Show ID ";
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovie.Location = new System.Drawing.Point(87, 162);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(66, 24);
            this.lblMovie.TabIndex = 30;
            this.lblMovie.Text = "Movie";
            // 
            // lblHall
            // 
            this.lblHall.AutoSize = true;
            this.lblHall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHall.Location = new System.Drawing.Point(60, 212);
            this.lblHall.Name = "lblHall";
            this.lblHall.Size = new System.Drawing.Size(85, 24);
            this.lblHall.TabIndex = 31;
            this.lblHall.Text = "Hall No.";
            // 
            // lblTicketPrice
            // 
            this.lblTicketPrice.AutoSize = true;
            this.lblTicketPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketPrice.Location = new System.Drawing.Point(37, 261);
            this.lblTicketPrice.Name = "lblTicketPrice";
            this.lblTicketPrice.Size = new System.Drawing.Size(116, 24);
            this.lblTicketPrice.TabIndex = 32;
            this.lblTicketPrice.Text = "Show Price";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(524, 118);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 24);
            this.lblDate.TabIndex = 33;
            this.lblDate.Text = "Date";
            // 
            // lblShowTime
            // 
            this.lblShowTime.AutoSize = true;
            this.lblShowTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowTime.Location = new System.Drawing.Point(520, 177);
            this.lblShowTime.Name = "lblShowTime";
            this.lblShowTime.Size = new System.Drawing.Size(57, 24);
            this.lblShowTime.TabIndex = 34;
            this.lblShowTime.Text = "Time";
            // 
            // txtShowId
            // 
            this.txtShowId.Location = new System.Drawing.Point(163, 64);
            this.txtShowId.Name = "txtShowId";
            this.txtShowId.ReadOnly = true;
            this.txtShowId.Size = new System.Drawing.Size(113, 22);
            this.txtShowId.TabIndex = 36;
            this.txtShowId.Text = "Auto Generated ";
            // 
            // txtShowPrice
            // 
            this.txtShowPrice.Location = new System.Drawing.Point(163, 262);
            this.txtShowPrice.Name = "txtShowPrice";
            this.txtShowPrice.Size = new System.Drawing.Size(255, 22);
            this.txtShowPrice.TabIndex = 37;
            // 
            // cmbHallNo
            // 
            this.cmbHallNo.FormattingEnabled = true;
            this.cmbHallNo.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbHallNo.Location = new System.Drawing.Point(163, 214);
            this.cmbHallNo.Name = "cmbHallNo";
            this.cmbHallNo.Size = new System.Drawing.Size(255, 24);
            this.cmbHallNo.TabIndex = 39;
            this.cmbHallNo.SelectedIndexChanged += new System.EventHandler(this.cmbHallNo_SelectedIndexChanged);
            // 
            // cmbTime
            // 
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Items.AddRange(new object[] {
            "02:00 PM",
            "05:00 PM",
            "08:00 PM"});
            this.cmbTime.Location = new System.Drawing.Point(583, 178);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(271, 24);
            this.cmbTime.TabIndex = 40;
            // 
            // dtpShowDate
            // 
            this.dtpShowDate.Location = new System.Drawing.Point(583, 118);
            this.dtpShowDate.Name = "dtpShowDate";
            this.dtpShowDate.Size = new System.Drawing.Size(271, 22);
            this.dtpShowDate.TabIndex = 42;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAdd.Location = new System.Drawing.Point(95, 313);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(181, 43);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Blue;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.Location = new System.Drawing.Point(298, 313);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(181, 43);
            this.btnUpdate.TabIndex = 44;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Location = new System.Drawing.Point(501, 313);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(181, 43);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Purple;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClear.Location = new System.Drawing.Point(704, 313);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(181, 43);
            this.btnClear.TabIndex = 46;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(94, 380);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(795, 22);
            this.txtSearch.TabIndex = 47;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(33, 384);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 18);
            this.lblSearch.TabIndex = 48;
            this.lblSearch.Text = "Search";
            // 
            // dgvShowInfo
            // 
            this.dgvShowInfo.AllowUserToAddRows = false;
            this.dgvShowInfo.AllowUserToDeleteRows = false;
            this.dgvShowInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowInfo.Location = new System.Drawing.Point(36, 418);
            this.dgvShowInfo.Name = "dgvShowInfo";
            this.dgvShowInfo.ReadOnly = true;
            this.dgvShowInfo.RowHeadersWidth = 51;
            this.dgvShowInfo.RowTemplate.Height = 24;
            this.dgvShowInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowInfo.Size = new System.Drawing.Size(853, 315);
            this.dgvShowInfo.TabIndex = 49;
            // 
            // txtMovie
            // 
            this.txtMovie.Location = new System.Drawing.Point(163, 162);
            this.txtMovie.Name = "txtMovie";
            this.txtMovie.Size = new System.Drawing.Size(255, 22);
            this.txtMovie.TabIndex = 50;
            // 
            // lbltheatre
            // 
            this.lbltheatre.AutoSize = true;
            this.lbltheatre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheatre.Location = new System.Drawing.Point(60, 112);
            this.lbltheatre.Name = "lbltheatre";
            this.lbltheatre.Size = new System.Drawing.Size(82, 24);
            this.lbltheatre.TabIndex = 51;
            this.lbltheatre.Text = "Theatre";
            // 
            // cmbtheatre
            // 
            this.cmbtheatre.FormattingEnabled = true;
            this.cmbtheatre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbtheatre.Location = new System.Drawing.Point(163, 114);
            this.cmbtheatre.Name = "cmbtheatre";
            this.cmbtheatre.Size = new System.Drawing.Size(255, 24);
            this.cmbtheatre.TabIndex = 52;
            this.cmbtheatre.SelectedIndexChanged += new System.EventHandler(this.cmbtheatre_SelectedIndexChanged);
            // 
            // ShowManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 745);
            this.Controls.Add(this.cmbtheatre);
            this.Controls.Add(this.lbltheatre);
            this.Controls.Add(this.txtMovie);
            this.Controls.Add(this.dgvShowInfo);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpShowDate);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.cmbHallNo);
            this.Controls.Add(this.txtShowPrice);
            this.Controls.Add(this.txtShowId);
            this.Controls.Add(this.lblShowTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTicketPrice);
            this.Controls.Add(this.lblHall);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.lblShowId);
            this.Controls.Add(this.lblShowManagement);
            this.Name = "ShowManagement";
            this.Text = "ShowManagement";
            this.Load += new System.EventHandler(this.ShowManagement_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShowManagement;
        private System.Windows.Forms.Label lblShowId;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.Label lblHall;
        private System.Windows.Forms.Label lblTicketPrice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblShowTime;
        private System.Windows.Forms.TextBox txtShowId;
        private System.Windows.Forms.TextBox txtShowPrice;
        private System.Windows.Forms.ComboBox cmbHallNo;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.DateTimePicker dtpShowDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvShowInfo;
        private System.Windows.Forms.TextBox txtMovie;
        private System.Windows.Forms.Label lbltheatre;
        private System.Windows.Forms.ComboBox cmbtheatre;
    }
}