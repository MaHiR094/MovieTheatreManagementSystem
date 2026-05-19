namespace MovieTheatreManagementSystem
{
    partial class HallManagement
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
            this.lblHallId = new System.Windows.Forms.Label();
            this.lblTheatre = new System.Windows.Forms.Label();
            this.lblHallName = new System.Windows.Forms.Label();
            this.lblTotalSeats = new System.Windows.Forms.Label();
            this.lblHallManagement = new System.Windows.Forms.Label();
            this.txtHallId = new System.Windows.Forms.TextBox();
            this.cmbTheatre = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvHallInfo = new System.Windows.Forms.DataGridView();
            this.txtTotalSeats = new System.Windows.Forms.TextBox();
            this.cmbHallName = new System.Windows.Forms.ComboBox();
            this.cmbHallType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHallInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHallId
            // 
            this.lblHallId.AutoSize = true;
            this.lblHallId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHallId.Location = new System.Drawing.Point(61, 142);
            this.lblHallId.Name = "lblHallId";
            this.lblHallId.Size = new System.Drawing.Size(77, 24);
            this.lblHallId.TabIndex = 1;
            this.lblHallId.Text = "Hall ID ";
            // 
            // lblTheatre
            // 
            this.lblTheatre.AutoSize = true;
            this.lblTheatre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheatre.Location = new System.Drawing.Point(61, 195);
            this.lblTheatre.Name = "lblTheatre";
            this.lblTheatre.Size = new System.Drawing.Size(88, 24);
            this.lblTheatre.TabIndex = 2;
            this.lblTheatre.Text = "Theatre ";
            // 
            // lblHallName
            // 
            this.lblHallName.AutoSize = true;
            this.lblHallName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHallName.Location = new System.Drawing.Point(61, 252);
            this.lblHallName.Name = "lblHallName";
            this.lblHallName.Size = new System.Drawing.Size(107, 24);
            this.lblHallName.TabIndex = 3;
            this.lblHallName.Text = "Hall Name";
            // 
            // lblTotalSeats
            // 
            this.lblTotalSeats.AutoSize = true;
            this.lblTotalSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSeats.Location = new System.Drawing.Point(500, 226);
            this.lblTotalSeats.Name = "lblTotalSeats";
            this.lblTotalSeats.Size = new System.Drawing.Size(113, 24);
            this.lblTotalSeats.TabIndex = 5;
            this.lblTotalSeats.Text = "Total Seats";
            // 
            // lblHallManagement
            // 
            this.lblHallManagement.AutoSize = true;
            this.lblHallManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHallManagement.Location = new System.Drawing.Point(12, 65);
            this.lblHallManagement.Name = "lblHallManagement";
            this.lblHallManagement.Size = new System.Drawing.Size(227, 29);
            this.lblHallManagement.TabIndex = 27;
            this.lblHallManagement.Text = "Hall Management";
            // 
            // txtHallId
            // 
            this.txtHallId.Location = new System.Drawing.Point(194, 144);
            this.txtHallId.Name = "txtHallId";
            this.txtHallId.Size = new System.Drawing.Size(128, 22);
            this.txtHallId.TabIndex = 28;
            this.txtHallId.Text = "Auto Generated";
            this.txtHallId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbTheatre
            // 
            this.cmbTheatre.FormattingEnabled = true;
            this.cmbTheatre.Items.AddRange(new object[] {
            "Blockbuster Cinema",
            "Star Cineplex"});
            this.cmbTheatre.Location = new System.Drawing.Point(194, 195);
            this.cmbTheatre.Name = "cmbTheatre";
            this.cmbTheatre.Size = new System.Drawing.Size(255, 24);
            this.cmbTheatre.TabIndex = 32;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAdd.Location = new System.Drawing.Point(34, 313);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(171, 43);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Blue;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.Location = new System.Drawing.Point(247, 313);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(172, 43);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Location = new System.Drawing.Point(463, 313);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(167, 43);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Purple;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClear.Location = new System.Drawing.Point(673, 313);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 43);
            this.btnClear.TabIndex = 36;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(75, 395);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(837, 22);
            this.txtSearch.TabIndex = 37;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(14, 399);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 18);
            this.lblSearch.TabIndex = 38;
            this.lblSearch.Text = "Search";
            // 
            // dgvHallInfo
            // 
            this.dgvHallInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHallInfo.Location = new System.Drawing.Point(17, 433);
            this.dgvHallInfo.Name = "dgvHallInfo";
            this.dgvHallInfo.RowHeadersWidth = 51;
            this.dgvHallInfo.RowTemplate.Height = 24;
            this.dgvHallInfo.Size = new System.Drawing.Size(895, 300);
            this.dgvHallInfo.TabIndex = 39;
            this.dgvHallInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHallInfo_CellContentClick);
            // 
            // txtTotalSeats
            // 
            this.txtTotalSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSeats.Location = new System.Drawing.Point(620, 226);
            this.txtTotalSeats.Name = "txtTotalSeats";
            this.txtTotalSeats.ReadOnly = true;
            this.txtTotalSeats.Size = new System.Drawing.Size(30, 26);
            this.txtTotalSeats.TabIndex = 40;
            this.txtTotalSeats.Text = "56";
            // 
            // cmbHallName
            // 
            this.cmbHallName.FormattingEnabled = true;
            this.cmbHallName.Items.AddRange(new object[] {
            "Hall A",
            "Hall B"});
            this.cmbHallName.Location = new System.Drawing.Point(194, 254);
            this.cmbHallName.Name = "cmbHallName";
            this.cmbHallName.Size = new System.Drawing.Size(255, 24);
            this.cmbHallName.TabIndex = 41;
            // 
            // cmbHallType
            // 
            this.cmbHallType.FormattingEnabled = true;
            this.cmbHallType.Items.AddRange(new object[] {
            "2D",
            "3D",
            "IMAX"});
            this.cmbHallType.Location = new System.Drawing.Point(620, 144);
            this.cmbHallType.Name = "cmbHallType";
            this.cmbHallType.Size = new System.Drawing.Size(255, 24);
            this.cmbHallType.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(492, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "Hall Type";
            // 
            // HallManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 745);
            this.Controls.Add(this.cmbHallType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbHallName);
            this.Controls.Add(this.txtTotalSeats);
            this.Controls.Add(this.dgvHallInfo);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbTheatre);
            this.Controls.Add(this.txtHallId);
            this.Controls.Add(this.lblHallManagement);
            this.Controls.Add(this.lblTotalSeats);
            this.Controls.Add(this.lblHallName);
            this.Controls.Add(this.lblTheatre);
            this.Controls.Add(this.lblHallId);
            this.Name = "HallManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HallManagement";
            this.Load += new System.EventHandler(this.HallManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHallInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHallId;
        private System.Windows.Forms.Label lblTheatre;
        private System.Windows.Forms.Label lblHallName;
        private System.Windows.Forms.Label lblTotalSeats;
        private System.Windows.Forms.Label lblHallManagement;
        private System.Windows.Forms.TextBox txtHallId;
        private System.Windows.Forms.ComboBox cmbTheatre;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvHallInfo;
        private System.Windows.Forms.TextBox txtTotalSeats;
        private System.Windows.Forms.ComboBox cmbHallName;
        private System.Windows.Forms.ComboBox cmbHallType;
        private System.Windows.Forms.Label label1;
    }
}