namespace Library_Management_System
{
    partial class FormBorrowReturn
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
            cmbMember = new ComboBox();
            cmbBook = new ComboBox();
            dtpBorrowDate = new DateTimePicker();
            dtpDueDate = new DateTimePicker();
            btnBorrow = new Button();
            dgvBorrowList = new DataGridView();
            btnReturn = new Button();
            btnSearchBorrow = new Button();
            txtSearchBorrowID = new TextBox();
            dtpReturnDate = new DateTimePicker();
            dgvReturnHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReturnHistory).BeginInit();
            SuspendLayout();
            // 
            // cmbMember
            // 
            cmbMember.BackColor = Color.White;
            cmbMember.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMember.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMember.ForeColor = Color.FromArgb(30, 41, 59);
            cmbMember.FormattingEnabled = true;
            cmbMember.Location = new Point(40, 40);
            cmbMember.Name = "cmbMember";
            cmbMember.Size = new Size(300, 31);
            cmbMember.TabIndex = 0;
            // 
            // cmbBook
            // 
            cmbBook.BackColor = Color.White;
            cmbBook.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBook.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBook.ForeColor = Color.FromArgb(30, 41, 59);
            cmbBook.FormattingEnabled = true;
            cmbBook.Location = new Point(40, 90);
            cmbBook.Name = "cmbBook";
            cmbBook.Size = new Size(300, 31);
            cmbBook.TabIndex = 1;
            // 
            // dtpBorrowDate
            // 
            dtpBorrowDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpBorrowDate.Format = DateTimePickerFormat.Short;
            dtpBorrowDate.Location = new Point(360, 40);
            dtpBorrowDate.Name = "dtpBorrowDate";
            dtpBorrowDate.Size = new Size(300, 30);
            dtpBorrowDate.TabIndex = 2;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(360, 90);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(300, 30);
            dtpDueDate.TabIndex = 3;
            // 
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.FromArgb(22, 163, 74);
            btnBorrow.FlatAppearance.BorderSize = 0;
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBorrow.ForeColor = Color.White;
            btnBorrow.Location = new Point(40, 140);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(620, 42);
            btnBorrow.TabIndex = 4;
            btnBorrow.Text = "Confirm Borrow Book";
            btnBorrow.UseVisualStyleBackColor = false;
            // 
            // dgvBorrowList
            // 
            dgvBorrowList.AllowUserToAddRows = false;
            dgvBorrowList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBorrowList.BackgroundColor = Color.White;
            dgvBorrowList.BorderStyle = BorderStyle.Fixed3D;
            dgvBorrowList.ColumnHeadersHeight = 35;
            dgvBorrowList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBorrowList.Location = new Point(40, 200);
            dgvBorrowList.MultiSelect = false;
            dgvBorrowList.Name = "dgvBorrowList";
            dgvBorrowList.ReadOnly = true;
            dgvBorrowList.RowHeadersWidth = 51;
            dgvBorrowList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBorrowList.Size = new Size(620, 420);
            dgvBorrowList.TabIndex = 5;
            // 
            // txtSearchBorrowID
            // 
            txtSearchBorrowID.BackColor = Color.White;
            txtSearchBorrowID.BorderStyle = BorderStyle.FixedSingle;
            txtSearchBorrowID.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBorrowID.ForeColor = Color.FromArgb(30, 41, 59);
            txtSearchBorrowID.Location = new Point(700, 40);
            txtSearchBorrowID.Name = "txtSearchBorrowID";
            txtSearchBorrowID.Size = new Size(480, 30);
            txtSearchBorrowID.TabIndex = 8;
            txtSearchBorrowID.Text = "Enter Borrow ID or Member ID...";
            // 
            // btnSearchBorrow
            // 
            btnSearchBorrow.BackColor = Color.FromArgb(59, 130, 246);
            btnSearchBorrow.FlatAppearance.BorderSize = 0;
            btnSearchBorrow.FlatStyle = FlatStyle.Flat;
            btnSearchBorrow.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchBorrow.ForeColor = Color.White;
            btnSearchBorrow.Location = new Point(1190, 38);
            btnSearchBorrow.Name = "btnSearchBorrow";
            btnSearchBorrow.Size = new Size(190, 33);
            btnSearchBorrow.TabIndex = 7;
            btnSearchBorrow.Text = "Search Transaction";
            btnSearchBorrow.UseVisualStyleBackColor = false;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpReturnDate.Format = DateTimePickerFormat.Short;
            dtpReturnDate.Location = new Point(700, 90);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(480, 30);
            dtpReturnDate.TabIndex = 9;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(37, 99, 235);
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(1190, 88);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(190, 33);
            btnReturn.TabIndex = 6;
            btnReturn.Text = "Return Book";
            btnReturn.UseVisualStyleBackColor = false;
            // 
            // dgvReturnHistory
            // 
            dgvReturnHistory.AllowUserToAddRows = false;
            dgvReturnHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReturnHistory.BackgroundColor = Color.White;
            dgvReturnHistory.BorderStyle = BorderStyle.Fixed3D;
            dgvReturnHistory.ColumnHeadersHeight = 35;
            dgvReturnHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReturnHistory.Location = new Point(700, 140);
            dgvReturnHistory.MultiSelect = false;
            dgvReturnHistory.Name = "dgvReturnHistory";
            dgvReturnHistory.ReadOnly = true;
            dgvReturnHistory.RowHeadersWidth = 51;
            dgvReturnHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReturnHistory.Size = new Size(680, 480);
            dgvReturnHistory.TabIndex = 10;
            // 
            // FormBorrowReturn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1420, 660);
            Controls.Add(dgvReturnHistory);
            Controls.Add(dtpReturnDate);
            Controls.Add(txtSearchBorrowID);
            Controls.Add(btnSearchBorrow);
            Controls.Add(btnReturn);
            Controls.Add(dgvBorrowList);
            Controls.Add(btnBorrow);
            Controls.Add(dtpDueDate);
            Controls.Add(dtpBorrowDate);
            Controls.Add(cmbBook);
            Controls.Add(cmbMember);
            Name = "FormBorrowReturn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBorrowReturn";
            ((System.ComponentModel.ISupportInitialize)dgvBorrowList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReturnHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMember;
        private ComboBox cmbBook;
        private DateTimePicker dtpBorrowDate;
        private DateTimePicker dtpDueDate;
        private Button btnBorrow;
        private DataGridView dgvBorrowList;
        private Button btnReturn;
        private Button btnSearchBorrow;
        private TextBox txtSearchBorrowID;
        private DateTimePicker dtpReturnDate;
        private DataGridView dgvReturnHistory;
    }
}