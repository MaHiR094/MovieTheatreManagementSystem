namespace MovieTheatreManagementSystem
{
    partial class TheatreForm
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
            this.lblTheatreId = new System.Windows.Forms.Label();
            this.lblTheatreName = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtTheatreName = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtTheatreId = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTheatreManagement = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dgvTheatreInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheatreInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTheatreId
            // 
            this.lblTheatreId.AutoSize = true;
            this.lblTheatreId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheatreId.Location = new System.Drawing.Point(36, 101);
            this.lblTheatreId.Name = "lblTheatreId";
            this.lblTheatreId.Size = new System.Drawing.Size(113, 24);
            this.lblTheatreId.TabIndex = 0;
            this.lblTheatreId.Text = "Theatre ID ";
            // 
            // lblTheatreName
            // 
            this.lblTheatreName.AutoSize = true;
            this.lblTheatreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheatreName.Location = new System.Drawing.Point(36, 160);
            this.lblTheatreName.Name = "lblTheatreName";
            this.lblTheatreName.Size = new System.Drawing.Size(143, 24);
            this.lblTheatreName.TabIndex = 1;
            this.lblTheatreName.Text = "Theatre Name";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(531, 102);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(80, 24);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "Contact";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(531, 165);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(89, 24);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Location";
            // 
            // txtTheatreName
            // 
            this.txtTheatreName.Location = new System.Drawing.Point(191, 162);
            this.txtTheatreName.Name = "txtTheatreName";
            this.txtTheatreName.Size = new System.Drawing.Size(255, 22);
            this.txtTheatreName.TabIndex = 6;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(626, 102);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(255, 22);
            this.txtContact.TabIndex = 8;
            // 
            // txtTheatreId
            // 
            this.txtTheatreId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTheatreId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheatreId.Location = new System.Drawing.Point(191, 102);
            this.txtTheatreId.Name = "txtTheatreId";
            this.txtTheatreId.ReadOnly = true;
            this.txtTheatreId.Size = new System.Drawing.Size(129, 26);
            this.txtTheatreId.TabIndex = 10;
            this.txtTheatreId.Text = "Auto Generated";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAdd.Location = new System.Drawing.Point(18, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(189, 43);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Blue;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.Location = new System.Drawing.Point(247, 268);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(189, 43);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Location = new System.Drawing.Point(476, 268);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(189, 43);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Purple;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClear.Location = new System.Drawing.Point(705, 268);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(189, 43);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTheatreManagement
            // 
            this.lblTheatreManagement.AutoSize = true;
            this.lblTheatreManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheatreManagement.Location = new System.Drawing.Point(33, 28);
            this.lblTheatreManagement.Name = "lblTheatreManagement";
            this.lblTheatreManagement.Size = new System.Drawing.Size(359, 39);
            this.lblTheatreManagement.TabIndex = 26;
            this.lblTheatreManagement.Text = "Theatre Management";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(99, 342);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(796, 22);
            this.txtSearch.TabIndex = 27;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(28, 346);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 18);
            this.lblSearch.TabIndex = 28;
            this.lblSearch.Text = "Search";
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Items.AddRange(new object[] {
            "Dhaka",
            "Mymensingh",
            "Barisal",
            "Rajshahi",
            "Sylhet",
            "Rangpur"});
            this.cmbLocation.Location = new System.Drawing.Point(626, 166);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(255, 24);
            this.cmbLocation.TabIndex = 29;
            // 
            // dgvTheatreInfo
            // 
            this.dgvTheatreInfo.AllowUserToAddRows = false;
            this.dgvTheatreInfo.AllowUserToDeleteRows = false;
            this.dgvTheatreInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheatreInfo.Location = new System.Drawing.Point(31, 379);
            this.dgvTheatreInfo.Name = "dgvTheatreInfo";
            this.dgvTheatreInfo.ReadOnly = true;
            this.dgvTheatreInfo.RowHeadersWidth = 51;
            this.dgvTheatreInfo.RowTemplate.Height = 24;
            this.dgvTheatreInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTheatreInfo.Size = new System.Drawing.Size(863, 357);
            this.dgvTheatreInfo.TabIndex = 30;
            this.dgvTheatreInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTheatreInfo_CellContentClick);
            // 
            // TheatreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 745);
            this.Controls.Add(this.dgvTheatreInfo);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblTheatreManagement);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTheatreId);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtTheatreName);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblTheatreName);
            this.Controls.Add(this.lblTheatreId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TheatreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheatreForm";
            this.Load += new System.EventHandler(this.TheatreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheatreInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTheatreId;
        private System.Windows.Forms.Label lblTheatreName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtTheatreName;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtTheatreId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTheatreManagement;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.DataGridView dgvTheatreInfo;
    }
}