namespace Library_Management_System
{
    partial class FormBooks
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
            components = new System.ComponentModel.Container();
            txtBookID = new TextBox();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            cmbCategory = new ComboBox();
            CategorySource = new BindingSource(components);
            BookSource = new BindingSource(components);
            numQuantity = new NumericUpDown();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvBooks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)CategorySource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BookSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // txtBookID
            // 
            txtBookID.BackColor = Color.FromArgb(241, 245, 249);
            txtBookID.BorderStyle = BorderStyle.FixedSingle;
            txtBookID.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookID.ForeColor = Color.FromArgb(100, 116, 139);
            txtBookID.Location = new Point(40, 40);
            txtBookID.Name = "txtBookID";
            txtBookID.ReadOnly = true;
            txtBookID.Size = new Size(360, 30);
            txtBookID.TabIndex = 0;
            txtBookID.Text = "Book ID (Auto Generated)";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.White;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.ForeColor = Color.FromArgb(30, 41, 59);
            txtTitle.Location = new Point(40, 95);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(360, 30);
            txtTitle.TabIndex = 1;
            txtTitle.Text = "Book Title";
            // 
            // txtAuthor
            // 
            txtAuthor.BackColor = Color.White;
            txtAuthor.BorderStyle = BorderStyle.FixedSingle;
            txtAuthor.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAuthor.ForeColor = Color.FromArgb(30, 41, 59);
            txtAuthor.Location = new Point(40, 150);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(360, 30);
            txtAuthor.TabIndex = 2;
            txtAuthor.Text = "Author Name";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.White;
            cmbCategory.DataSource = CategorySource;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategory.ForeColor = Color.FromArgb(30, 41, 59);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(40, 205);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(360, 31);
            cmbCategory.TabIndex = 3;
            // 
            // BookSource
            // 
            BookSource.DataSource = typeof(BookClass);
            // 
            // numQuantity
            // 
            numQuantity.BackColor = Color.White;
            numQuantity.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numQuantity.ForeColor = Color.FromArgb(30, 41, 59);
            numQuantity.Location = new Point(40, 260);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(360, 30);
            numQuantity.TabIndex = 5;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(22, 163, 74);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(40, 320);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 45);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Insert";
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
            btnUpdate.Location = new Point(230, 320);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(170, 45);
            btnUpdate.TabIndex = 7;
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
            btnDelete.Location = new Point(40, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(170, 45);
            btnDelete.TabIndex = 8;
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
            btnClear.Location = new Point(230, 380);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(170, 45);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear Inputs";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.FromArgb(30, 41, 59);
            txtSearch.Location = new Point(450, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(780, 30);
            txtSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(59, 130, 246);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1250, 38);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(160, 35);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.Fixed3D;
            dgvBooks.ColumnHeadersHeight = 40;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBooks.Location = new Point(450, 95);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(960, 535);
            dgvBooks.TabIndex = 12;
            dgvBooks.MouseClick += dgvBooks_MouseClick;
            // 
            // FormBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1465, 675);
            Controls.Add(dgvBooks);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(numQuantity);
            Controls.Add(cmbCategory);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(txtBookID);
            ForeColor = Color.FromArgb(30, 41, 59);
            Name = "FormBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBooks";
            Load += FormBooks_Load;
            ((System.ComponentModel.ISupportInitialize)CategorySource).EndInit();
            ((System.ComponentModel.ISupportInitialize)BookSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBookID;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private ComboBox cmbCategory;
        private NumericUpDown numQuantity;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvBooks;
        private BindingSource BookSource;
        private BindingSource CategorySource;
    }
}