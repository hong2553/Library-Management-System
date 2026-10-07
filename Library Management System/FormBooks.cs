using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    public partial class FormBooks : Form
    {
        private readonly BookRepository repo = new BookRepository(new SqlConn().ConnectionString);

        public FormBooks()
        {
            InitializeComponent();
        }

        private void FormBooks_Load(object sender, EventArgs e)
        {
            txtSearch.PlaceholderText = " Column : text   (Column = BookID, Title, Author or Category)";

            // Limits from tblBook: Title VARCHAR(50), Author VARCHAR(25), Quantity SMALLINT
            txtTitle.MaxLength = 50;
            txtAuthor.MaxLength = 25;
            numQuantity.Minimum = 0;
            numQuantity.Maximum = short.MaxValue;   // 32767

            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvBooks.AutoGenerateColumns = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Run(() =>
            {
                CategorySource.DataSource = repo.GetCategories();
                cmbCategory.DisplayMember = nameof(CategoryClass.Category);
                cmbCategory.ValueMember = nameof(CategoryClass.CategoryID);
                cmbCategory.SelectedIndex = -1;
                LoadBooks();
            });
        }

        // ---------- Grid ----------

        private void dgvBooks_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (dgvBooks.CurrentRow?.DataBoundItem is not BookClass book) return;

            txtBookID.Text = book.BookID.ToString();
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            cmbCategory.SelectedValue = book.CategoryID;
            numQuantity.Value = Math.Clamp(book.Quantity, (int)numQuantity.Minimum, (int)numQuantity.Maximum);
        }

        // ---------- Buttons ----------

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var book = ReadInputs();
            if (book is null) return;

            Run(() =>
            {
                int newId = repo.Add(book);
                LoadBooks();
                ClearInputs();
                MessageBox.Show($"Book added (ID {newId}).", "Library",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookID.Text, out int id))
            {
                Warn("Click a book in the list first.");
                return;
            }

            var book = ReadInputs();
            if (book is null) return;
            book.BookID = id;

            Run(() =>
            {
                if (!repo.Update(book))
                {
                    Warn("That book no longer exists.");
                    return;
                }
                LoadBooks();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookID.Text, out int id))
            {
                Warn("Click a book in the list first.");
                return;
            }

            var confirm = MessageBox.Show($"Delete \"{txtTitle.Text}\"?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            Run(() =>
            {
                if (!repo.Delete(id))
                {
                    Warn("That book no longer exists.");
                    return;
                }
                LoadBooks();
                ClearInputs();
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text.Trim();

            if (text.Length == 0)
            {
                Run(() => LoadBooks());
                return;
            }

            // "Title : harry"  ->  field = "Title", value = "harry"
            string[] parts = text.Split(':', 2);
            if (parts.Length < 2 || parts[1].Trim().Length == 0)
            {
                Warn("Type the search as  Column : text  (for example  Author : Orwell).");
                return;
            }

            Run(() => dgvBooks.DataSource = repo.Search(parts[0], parts[1]));
        }

        // ---------- Helpers ----------

        private void LoadBooks()
        {
            dgvBooks.DataSource = repo.GetAll();
        }
        private BookClass? ReadInputs()
        {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();

            if (title.Length == 0) { Warn("Title is required."); return null; }
            if (author.Length == 0) { Warn("Author is required."); return null; }
            if (cmbCategory.SelectedValue is not int categoryId) { Warn("Choose a category."); return null; }

            return new BookClass
            {
                Title = title,
                Author = author,
                CategoryID = categoryId,
                Quantity = (int)numQuantity.Value
            };
        }
        private void ClearInputs()
        {
            txtBookID.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            cmbCategory.SelectedIndex = -1;
            numQuantity.Value = 0;
        }

        private static void Warn(string message) =>
            MessageBox.Show(message, "Library", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void Run(Action action)
        {
            try
            {
                action();
            }
            catch (ArgumentException ex)   // bad search input
            {
                Warn(ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)   // foreign key conflict
            {
                Warn("This book can't be deleted or changed because other records (such as borrow records) use it.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Library",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}