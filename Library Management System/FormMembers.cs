using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    public partial class FormMembers : Form
    {
        private readonly MemberRepository repo = new MemberRepository(new SqlConn().ConnectionString);

        public FormMembers()
        {
            InitializeComponent();
        }

        private void FormMembers_Load(object sender, EventArgs e)
        {
            txtMemberName.MaxLength = 25;
            txtPhone.MaxLength = 12;
            txtMemberName.PlaceholderText = "Student / Member Name";
            txtPhone.PlaceholderText = "Phone Number";

            // dateTimePicker1 = tblMember.RegisterDate (no future dates)
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(1).AddTicks(-1);
            dateTimePicker1.Value = DateTime.Today;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var member = ReadInput();
            if (member is null) return;

            Run(() =>
            {
                int memID = repo.Add(member);
                ClearInput();
                Info($"Member added (ID: {memID}).");
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var member = ReadInput();
            if (member is null) return;

            Run(() =>
            {
                // Update returns TRUE when a member was found and changed
                if (repo.Update(member))
                    Info("Member updated (name and gender).");
                else
                    Warn("Member not found. The phone number identifies the member, so it must match an existing one.");
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (phone.Length == 0)
            {
                Warn("Enter the phone number of the member to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete the member with phone {phone}?\nTheir borrow history will also be deleted.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            Run(() =>
            {
                // Delete returns TRUE when a member was found and deleted
                if (repo.Delete(phone))
                {
                    ClearInput();
                    Info("Member deleted.");
                }
                else
                {
                    Warn("Member not found.");
                }
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private MemberClass? ReadInput()
        {
            string name = txtMemberName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (name.Length == 0) { Warn("Name is required."); return null; }
            if (phone.Length == 0) { Warn("Phone is required."); return null; }
            if (cmbGender.SelectedIndex < 0) { Warn("Gender is required."); return null; }

            return new MemberClass
            {
                MemberName = name,
                Phone = phone,
                Gender = cmbGender.SelectedIndex == 0 ? 'M' : 'F',
                RegisterDate = dateTimePicker1.Value
            };
        }

        private void ClearInput()
        {
            txtMemberID.Clear();
            txtMemberName.Clear();
            txtPhone.Clear();
            cmbGender.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
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
            catch (InvalidOperationException ex)   // business rules: duplicate phone, member still has books
            {
                Warn(ex.Message);
            }
            catch (SqlException ex) when (ex.Number is 2627 or 2601)   // UNIQUE constraint on M_Phone
            {
                Warn("A member with this phone number already exists.");
            }
            catch (SqlException ex) when (ex.Number == 547)   // foreign key conflict
            {
                Warn("This member can't be changed or deleted because other records use it.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Library",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}