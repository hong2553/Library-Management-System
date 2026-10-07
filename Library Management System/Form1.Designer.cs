namespace Library_Management_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnDashboard = new Button();
            btnMembers = new Button();
            button4 = new Button();
            btnBorrow = new Button();
            btnLogout = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(15, 23, 42);
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(270, 80);
            label1.TabIndex = 0;
            label1.Text = "LIBRARY SYSTEM";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(59, 130, 246);
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(20, 100);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(15, 0, 0, 0);
            btnDashboard.Size = new Size(230, 48);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnMembers
            // 
            btnMembers.BackColor = Color.FromArgb(30, 41, 59);
            btnMembers.FlatAppearance.BorderSize = 0;
            btnMembers.FlatStyle = FlatStyle.Flat;
            btnMembers.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMembers.ForeColor = Color.FromArgb(226, 232, 240);
            btnMembers.Location = new Point(20, 220);
            btnMembers.Name = "btnMembers";
            btnMembers.Padding = new Padding(15, 0, 0, 0);
            btnMembers.Size = new Size(230, 48);
            btnMembers.TabIndex = 4;
            btnMembers.Text = "Member Management";
            btnMembers.TextAlign = ContentAlignment.MiddleLeft;
            btnMembers.UseVisualStyleBackColor = false;
            btnMembers.Click += btnMembers_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(30, 41, 59);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(226, 232, 240);
            button4.Location = new Point(20, 160);
            button4.Name = "button4";
            button4.Padding = new Padding(15, 0, 0, 0);
            button4.Size = new Size(230, 48);
            button4.TabIndex = 5;
            button4.Text = "Book Management";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.FromArgb(30, 41, 59);
            btnBorrow.FlatAppearance.BorderSize = 0;
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBorrow.ForeColor = Color.FromArgb(226, 232, 240);
            btnBorrow.Location = new Point(20, 280);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Padding = new Padding(15, 0, 0, 0);
            btnBorrow.Size = new Size(230, 48);
            btnBorrow.TabIndex = 6;
            btnBorrow.Text = "Borrow";
            btnBorrow.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrow.UseVisualStyleBackColor = false;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(225, 29, 72);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(20, 580);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(230, 48);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Exit";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.White;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(30, 41, 59);
            label2.Location = new Point(670, 100);
            label2.Name = "label2";
            label2.Size = new Size(330, 130);
            label2.TabIndex = 8;
            label2.Text = "\n  Total Members\n\n  0";
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(30, 41, 59);
            label3.Location = new Point(310, 100);
            label3.Name = "label3";
            label3.Size = new Size(330, 130);
            label3.TabIndex = 9;
            label3.Text = "\n  Total Books\n\n  0";
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(30, 41, 59);
            label4.Location = new Point(1030, 100);
            label4.Name = "label4";
            label4.Size = new Size(330, 130);
            label4.TabIndex = 10;
            label4.Text = "\n  Currently Borrowed\n\n  0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1422, 673);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnLogout);
            Controls.Add(btnBorrow);
            Controls.Add(btnMembers);
            Controls.Add(button4);
            Controls.Add(btnDashboard);
            Controls.Add(label1);
            ImeMode = ImeMode.Disable;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDashboard";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnDashboard;
        private Button btnMembers;
        private Button button4;
        private Button btnBorrow;
        private Button btnLogout;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}