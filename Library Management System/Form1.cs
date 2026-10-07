using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> lsTotal = new List<int>();
            lsTotal = TotalEach();

            label3.Text = "Total Books: " + lsTotal[0].ToString();
            label2.Text = "Total Members: " + lsTotal[1].ToString();
            label4.Text = "Total Borrowed: " + lsTotal[2].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBooks F_books = new FormBooks();
            F_books.Show();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            FormMembers F_members = new FormMembers();
            F_members.Show();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            FormBorrowReturn F_Borrow = new FormBorrowReturn();
            F_Borrow.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static List<int> TotalEach()
        {
            List<int> lsTotal = new List<int>();
            SqlConn sqlconn = new SqlConn();
            SqlConnection conn = new SqlConnection(sqlconn.ConnectionString);
            try
            {
                conn.Open();
                var bookcmd = new SqlCommand("SELECT SUM(Quantity) FROM tblBook", conn);
                int bookTotal = Convert.ToInt32(bookcmd.ExecuteScalar());
                lsTotal.Add(bookTotal);

                var memcmd = new SqlCommand("SELECT COUNT(*) FROM tblMember", conn);
                int memTotal = Convert.ToInt32(memcmd.ExecuteScalar());
                lsTotal.Add(memTotal);

                var brwcmd = new SqlCommand("SELECT COUNT(*) FROM tblBorrow WHERE ReturnDate IS NULL", conn);
                int brwCurrent = Convert.ToInt32(brwcmd.ExecuteScalar());
                lsTotal.Add(brwCurrent);

                return lsTotal;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
                throw;
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }
    }
}
