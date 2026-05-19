namespace MovieTicketBookingSystem
{
    partial class PaymentDetails
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
            this.lblPaymentId = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblTransactionId = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBookingId = new System.Windows.Forms.Label();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblPaymentDetails = new System.Windows.Forms.Label();
            this.lblPaymentMethods = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pnlPaymentMethods = new System.Windows.Forms.Panel();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            this.rbtnNagad = new System.Windows.Forms.RadioButton();
            this.rbtnCreditDebitCard = new System.Windows.Forms.RadioButton();
            this.rbtnBkash = new System.Windows.Forms.RadioButton();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlPaymentMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPaymentId
            // 
            this.lblPaymentId.AutoSize = true;
            this.lblPaymentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentId.Location = new System.Drawing.Point(93, 119);
            this.lblPaymentId.Name = "lblPaymentId";
            this.lblPaymentId.Size = new System.Drawing.Size(137, 26);
            this.lblPaymentId.TabIndex = 1;
            this.lblPaymentId.Text = "Payment ID";
            this.lblPaymentId.Click += new System.EventHandler(this.lblPaymentId_Click);
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.Location = new System.Drawing.Point(68, 408);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(163, 26);
            this.lblPaymentDate.TabIndex = 2;
            this.lblPaymentDate.Text = "Payment Date";
            // 
            // lblTransactionId
            // 
            this.lblTransactionId.AutoSize = true;
            this.lblTransactionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionId.Location = new System.Drawing.Point(61, 331);
            this.lblTransactionId.Name = "lblTransactionId";
            this.lblTransactionId.Size = new System.Drawing.Size(166, 26);
            this.lblTransactionId.TabIndex = 3;
            this.lblTransactionId.Text = "Transaction ID";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(130, 264);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(94, 26);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Amount";
            // 
            // lblBookingId
            // 
            this.lblBookingId.AutoSize = true;
            this.lblBookingId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingId.Location = new System.Drawing.Point(98, 196);
            this.lblBookingId.Name = "lblBookingId";
            this.lblBookingId.Size = new System.Drawing.Size(129, 26);
            this.lblBookingId.TabIndex = 5;
            this.lblBookingId.Text = "Booking ID";
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.Location = new System.Drawing.Point(52, 484);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(181, 26);
            this.lblPaymentStatus.TabIndex = 6;
            this.lblPaymentStatus.Text = "Payment Status";
            // 
            // lblPaymentDetails
            // 
            this.lblPaymentDetails.AutoSize = true;
            this.lblPaymentDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDetails.Location = new System.Drawing.Point(92, 44);
            this.lblPaymentDetails.Name = "lblPaymentDetails";
            this.lblPaymentDetails.Size = new System.Drawing.Size(243, 36);
            this.lblPaymentDetails.TabIndex = 7;
            this.lblPaymentDetails.Text = "Payment Details";
            // 
            // lblPaymentMethods
            // 
            this.lblPaymentMethods.AutoSize = true;
            this.lblPaymentMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethods.Location = new System.Drawing.Point(14, 5);
            this.lblPaymentMethods.Name = "lblPaymentMethods";
            this.lblPaymentMethods.Size = new System.Drawing.Size(203, 26);
            this.lblPaymentMethods.TabIndex = 8;
            this.lblPaymentMethods.Text = "Payment Methods";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(243, 331);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 32);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(243, 260);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(304, 32);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "BDT.";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(243, 191);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(304, 32);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(243, 119);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(304, 32);
            this.textBox4.TabIndex = 14;
            // 
            // pnlPaymentMethods
            // 
            this.pnlPaymentMethods.Controls.Add(this.rbtnCash);
            this.pnlPaymentMethods.Controls.Add(this.rbtnNagad);
            this.pnlPaymentMethods.Controls.Add(this.rbtnCreditDebitCard);
            this.pnlPaymentMethods.Controls.Add(this.lblPaymentMethods);
            this.pnlPaymentMethods.Controls.Add(this.rbtnBkash);
            this.pnlPaymentMethods.Location = new System.Drawing.Point(570, 119);
            this.pnlPaymentMethods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPaymentMethods.Name = "pnlPaymentMethods";
            this.pnlPaymentMethods.Size = new System.Drawing.Size(265, 322);
            this.pnlPaymentMethods.TabIndex = 15;
            // 
            // rbtnCash
            // 
            this.rbtnCash.AutoSize = true;
            this.rbtnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCash.Location = new System.Drawing.Point(30, 246);
            this.rbtnCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.Size = new System.Drawing.Size(92, 30);
            this.rbtnCash.TabIndex = 18;
            this.rbtnCash.TabStop = true;
            this.rbtnCash.Text = "Cash";
            this.rbtnCash.UseVisualStyleBackColor = true;
            // 
            // rbtnNagad
            // 
            this.rbtnNagad.AutoSize = true;
            this.rbtnNagad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNagad.Location = new System.Drawing.Point(30, 120);
            this.rbtnNagad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnNagad.Name = "rbtnNagad";
            this.rbtnNagad.Size = new System.Drawing.Size(106, 30);
            this.rbtnNagad.TabIndex = 17;
            this.rbtnNagad.TabStop = true;
            this.rbtnNagad.Text = "Nagad";
            this.rbtnNagad.UseVisualStyleBackColor = true;
            // 
            // rbtnCreditDebitCard
            // 
            this.rbtnCreditDebitCard.AutoSize = true;
            this.rbtnCreditDebitCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCreditDebitCard.Location = new System.Drawing.Point(30, 180);
            this.rbtnCreditDebitCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnCreditDebitCard.Name = "rbtnCreditDebitCard";
            this.rbtnCreditDebitCard.Size = new System.Drawing.Size(222, 30);
            this.rbtnCreditDebitCard.TabIndex = 17;
            this.rbtnCreditDebitCard.TabStop = true;
            this.rbtnCreditDebitCard.Text = "Credit/Debit Card";
            this.rbtnCreditDebitCard.UseVisualStyleBackColor = true;
            // 
            // rbtnBkash
            // 
            this.rbtnBkash.AutoSize = true;
            this.rbtnBkash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBkash.Location = new System.Drawing.Point(34, 59);
            this.rbtnBkash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnBkash.Name = "rbtnBkash";
            this.rbtnBkash.Size = new System.Drawing.Size(104, 30);
            this.rbtnBkash.TabIndex = 16;
            this.rbtnBkash.TabStop = true;
            this.rbtnBkash.Text = "bKash";
            this.rbtnBkash.UseVisualStyleBackColor = true;
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Items.AddRange(new object[] {
            "Paid",
            "Unpaid",
            "Pending"});
            this.cmbPaymentStatus.Location = new System.Drawing.Point(243, 486);
            this.cmbPaymentStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(304, 28);
            this.cmbPaymentStatus.TabIndex = 16;
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Location = new System.Drawing.Point(243, 410);
            this.dtPaymentDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(304, 26);
            this.dtPaymentDate.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.Location = new System.Drawing.Point(56, 580);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 62);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(223, 580);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(158, 62);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Purple;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClear.Location = new System.Drawing.Point(389, 580);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(158, 62);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // PaymentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 668);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtPaymentDate);
            this.Controls.Add(this.cmbPaymentStatus);
            this.Controls.Add(this.pnlPaymentMethods);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblPaymentDetails);
            this.Controls.Add(this.lblPaymentStatus);
            this.Controls.Add(this.lblBookingId);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTransactionId);
            this.Controls.Add(this.lblPaymentDate);
            this.Controls.Add(this.lblPaymentId);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PaymentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentDetails";
            this.pnlPaymentMethods.ResumeLayout(false);
            this.pnlPaymentMethods.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaymentId;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblTransactionId;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBookingId;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblPaymentDetails;
        private System.Windows.Forms.Label lblPaymentMethods;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel pnlPaymentMethods;
        private System.Windows.Forms.RadioButton rbtnCash;
        private System.Windows.Forms.RadioButton rbtnNagad;
        private System.Windows.Forms.RadioButton rbtnCreditDebitCard;
        private System.Windows.Forms.RadioButton rbtnBkash;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.DateTimePicker dtPaymentDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
    }
}