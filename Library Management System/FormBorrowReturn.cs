using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    public partial class FormBorrowReturn : Form
    {
        // Created in Load (inside try/catch) so a connection/config problem shows a message
        // instead of crashing while the form opens.
        private BorrowRepository borrowRepo = null!;
        private BookRepository bookRepo = null!;
        private MemberRepository memberRepo = null!;

        private int? searchId;   // current search filter (BorrowID or MemberID), null = show everything

        public FormBorrowReturn()
        {
            InitializeComponent();

            // The designer doesn't wire any events for this form, so wire them here.
            Load += FormBorrowReturn_Load;
            btnBorrow.Click += btnBorrow_Click;
            btnReturn.Click += btnReturn_Click;
            btnSearchBorrow.Click += btnSearchBorrow_Click;
            txtSearchBorrowID.KeyDown += txtSearchBorrowID_KeyDown;
            dtpBorrowDate.ValueChanged += (s, e) => UpdateDueDate();
            dgvBorrowList.DataBindingComplete += Grid_DataBindingComplete;
            dgvReturnHistory.DataBindingComplete += Grid_DataBindingComplete;
        }

        private bool Ready => borrowRepo != null;

        // ---------- Load ----------

        private void FormBorrowReturn_Load(object? sender, EventArgs e)
        {
            txtSearchBorrowID.Text = "";
            txtSearchBorrowID.PlaceholderText = "Enter Borrow ID or Member ID...";

            // No future dates for borrowing or returning
            DateTime endOfToday = DateTime.Today.AddDays(1).AddTicks(-1);
            dtpBorrowDate.MaxDate = endOfToday;
            dtpReturnDate.MaxDate = endOfToday;

            // The database has no DueDate column, so it is always borrow date + LoanDays (display only)
            dtpDueDate.Enabled = false;
            UpdateDueDate();

            dgvBorrowList.AutoGenerateColumns = true;
            dgvReturnHistory.AutoGenerateColumns = true;

            Run(() =>
            {
                string cs = new SqlConn().ConnectionString;
                borrowRepo = new BorrowRepository(cs);
                bookRepo = new BookRepository(cs);
                memberRepo = new MemberRepository(cs);

                LoadCombos();
                LoadGrids();
            });
        }

        // ---------- Buttons ----------

        private void btnBorrow_Click(object? sender, EventArgs e)
        {
            if (!Ready) { Warn("Not connected to the database."); return; }
            if (cmbMember.SelectedValue is not int memberId) { Warn("Choose a member."); return; }
            if (cmbBook.SelectedValue is not int bookId) { Warn("Choose a book."); return; }

            DateTime borrowDate = dtpBorrowDate.Value.Date + DateTime.Now.TimeOfDay;
            DateTime due = borrowDate.Date.AddDays(BorrowClass.LoanDays);

            Run(() =>
            {
                int id = borrowRepo.Borrow(memberId, bookId, borrowDate);
                LoadCombos();   // the book may now be out of stock
                LoadGrids();
                Info($"Borrow #{id} recorded.\nDue back on {due:yyyy-MM-dd}.");
            });
        }

        private void btnReturn_Click(object? sender, EventArgs e)
        {
            if (!Ready) { Warn("Not connected to the database."); return; }

            if (dgvBorrowList.CurrentRow?.DataBoundItem is not BorrowClass loan)
            {
                Warn("Click a borrowed book in the left list first.");
                return;
            }

            if (dtpReturnDate.Value.Date < loan.BorrowDate.Date)
            {
                Warn($"The return date can't be before the borrow date ({loan.BorrowDate:yyyy-MM-dd}).");
                return;
            }

            DateTime returnDate = dtpReturnDate.Value.Date + DateTime.Now.TimeOfDay;
            if (returnDate < loan.BorrowDate) returnDate = loan.BorrowDate;   // same-day return earlier in the day

            int daysLate = Math.Max(0, (returnDate.Date - loan.DueDate).Days);

            Run(() =>
            {
                borrowRepo.Return(loan.BorrowID, returnDate);
                LoadCombos();   // the book is back in stock
                LoadGrids();

                Info(daysLate > 0
                    ? $"\"{loan.BookTitle}\" returned by {loan.MemberName}.\nIt was {daysLate} day(s) late."
                    : $"\"{loan.BookTitle}\" returned by {loan.MemberName}, on time.");
            });
        }

        private void btnSearchBorrow_Click(object? sender, EventArgs e)
        {
            if (!Ready) { Warn("Not connected to the database."); return; }

            string text = txtSearchBorrowID.Text.Trim();

            if (text.Length == 0)
            {
                searchId = null;   // empty box = show everything again
            }
            else if (int.TryParse(text, out int id))
            {
                searchId = id;
            }
            else
            {
                Warn("Enter a number: a Borrow ID or a Member ID.");
                return;
            }

            Run(LoadGrids);
        }

        private void txtSearchBorrowID_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // no "ding"
                btnSearchBorrow.PerformClick();
            }
        }

        // ---------- Helpers ----------

        private void UpdateDueDate()
        {
            dtpDueDate.Value = dtpBorrowDate.Value.Date.AddDays(BorrowClass.LoanDays);
        }

        private void LoadCombos()
        {
            cmbMember.DisplayMember = nameof(MemberClass.MemberName);
            cmbMember.ValueMember = nameof(MemberClass.MemberID);
            cmbMember.DataSource = memberRepo.GetAll();
            cmbMember.SelectedIndex = -1;

            // Only books with at least one copy on the shelf can be borrowed
            cmbBook.DisplayMember = nameof(BookClass.Title);
            cmbBook.ValueMember = nameof(BookClass.BookID);
            cmbBook.DataSource = bookRepo.GetAll().Where(b => b.Quantity > 0).ToList();
            cmbBook.SelectedIndex = -1;
        }

        private void LoadGrids()
        {
            dgvBorrowList.DataSource = borrowRepo.GetActive(searchId);       // still out
            dgvReturnHistory.DataSource = borrowRepo.GetReturned(searchId);  // already returned
        }

        /// <summary>Date formats, and overdue loans in red.</summary>
        private void Grid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is not DataGridView grid) return;

            if (grid == dgvBorrowList && grid.Columns.Contains(nameof(BorrowClass.ReturnDate)))
                grid.Columns[nameof(BorrowClass.ReturnDate)].Visible = false;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                switch (col.Name)
                {
                    case nameof(BorrowClass.BorrowDate):
                    case nameof(BorrowClass.ReturnDate):
                        col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                        break;
                    case nameof(BorrowClass.DueDate):
                        col.DefaultCellStyle.Format = "yyyy-MM-dd";
                        break;
                }
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.DataBoundItem is BorrowClass { IsOverdue: true })
                    row.DefaultCellStyle.ForeColor = Color.Firebrick;
            }
        }

        private static void Info(string message) =>
            MessageBox.Show(message, "Library", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static void Warn(string message) =>
            MessageBox.Show(message, "Library", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        /// <summary>Runs a database action and shows a friendly message instead of crashing.</summary>
        private void Run(Action action)
        {
            try
            {
                action();
            }
            catch (InvalidOperationException ex)   // rules: out of stock, already returned, config problems
            {
                Warn(ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)   // foreign key conflict
            {
                Warn("That member or book no longer exists.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Library",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}