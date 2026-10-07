namespace Library_Management_System
{
    partial class FormMembers
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
            txtMemberID = new TextBox();
            txtMemberName = new TextBox();
            txtPhone = new TextBox();
            dtpRegisterDate = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            cmbGender = new ComboBox();
            dtpRegisterDate.SuspendLayout();
            SuspendLayout();
            // 
            // txtMemberID
            // 
            txtMemberID.BackColor = Color.FromArgb(241, 245, 249);
            txtMemberID.BorderStyle = BorderStyle.FixedSingle;
            txtMemberID.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMemberID.ForeColor = Color.FromArgb(100, 116, 139);
            txtMemberID.Location = new Point(40, 40);
            txtMemberID.Name = "txtMemberID";
            txtMemberID.ReadOnly = true;
            txtMemberID.Size = new Size(360, 30);
            txtMemberID.TabIndex = 0;
            txtMemberID.Text = "Member ID (Auto Generated)";
            // 
            // txtMemberName
            // 
            txtMemberName.BackColor = Color.White;
            txtMemberName.BorderStyle = BorderStyle.FixedSingle;
            txtMemberName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMemberName.ForeColor = Color.FromArgb(30, 41, 59);
            txtMemberName.Location = new Point(40, 95);
            txtMemberName.Name = "txtMemberName";
            txtMemberName.Size = new Size(360, 30);
            txtMemberName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.White;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.ForeColor = Color.FromArgb(30, 41, 59);
            txtPhone.Location = new Point(40, 211);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(360, 30);
            txtPhone.TabIndex = 2;
            // 
            // dtpRegisterDate
            // 
            dtpRegisterDate.BackColor = Color.White;
            dtpRegisterDate.Controls.Add(dateTimePicker1);
            dtpRegisterDate.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpRegisterDate.ForeColor = Color.FromArgb(30, 41, 59);
            dtpRegisterDate.Location = new Point(450, 40);
            dtpRegisterDate.Name = "dtpRegisterDate";
            dtpRegisterDate.Size = new Size(365, 275);
            dtpRegisterDate.TabIndex = 3;
            dtpRegisterDate.TabStop = false;
            dtpRegisterDate.Text = " Registration Details ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(30, 50);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(305, 30);
            dateTimePicker1.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(22, 163, 74);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(40, 271);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 45);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Insert Member";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(37, 99, 235);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(230, 271);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(170, 45);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(40, 331);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(170, 45);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(100, 116, 139);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(230, 331);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(170, 45);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // cmbGender
            // 
            cmbGender.BackColor = Color.White;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGender.ForeColor = Color.FromArgb(30, 41, 59);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.Location = new Point(40, 153);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(360, 31);
            cmbGender.TabIndex = 11;
            // 
            // FormMembers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1226, 609);
            Controls.Add(cmbGender);
            Controls.Add(dtpRegisterDate);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtPhone);
            Controls.Add(txtMemberName);
            Controls.Add(txtMemberID);
            Name = "FormMembers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMembers";
            Load += FormMembers_Load;
            dtpRegisterDate.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMemberID;
        private TextBox txtMemberName;
        private TextBox txtPhone;
        private GroupBox dtpRegisterDate;
        private DateTimePicker dateTimePicker1;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private ComboBox cmbGender;
    }
}