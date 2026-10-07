using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    public class BorrowRepository
    {
        private readonly string _connectionString;

        public BorrowRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private const string SelectSql =
            "SELECT br.BorrowID, br.MemberID, m.M_Name, br.BookID, b.Title, br.BorrowDate, br.ReturnDate " +
            "FROM tblBorrow br " +
            "INNER JOIN tblMember m ON br.MemberID = m.MemberID " +
            "INNER JOIN tblBook b ON br.BookID = b.BookID";

        // ---------- Read ----------

        /// <summary>Books currently out (ReturnDate is NULL). Optional filter: BorrowID or MemberID.</summary>
        public List<BorrowClass> GetActive(int? searchId = null) => Query(returned: false, searchId);

        /// <summary>Books already returned. Optional filter: BorrowID or MemberID.</summary>
        public List<BorrowClass> GetReturned(int? searchId = null) => Query(returned: true, searchId);

        private List<BorrowClass> Query(bool returned, int? searchId)
        {
            string sql = SelectSql + (returned
                ? " WHERE br.ReturnDate IS NOT NULL"
                : " WHERE br.ReturnDate IS NULL");

            if (searchId.HasValue)
                sql += " AND (br.BorrowID = @id OR br.MemberID = @id)";

            sql += returned
                ? " ORDER BY br.ReturnDate DESC;"
                : " ORDER BY br.BorrowDate DESC;";

            var list = new List<BorrowClass>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            if (searchId.HasValue)
                cmd.Parameters.AddWithValue("@id", searchId.Value);

            conn.Open();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new BorrowClass(
                    borrowID:   DbRead.Int(r, 0),
                    memberID:   DbRead.Int(r, 1),
                    bookID:     DbRead.Int(r, 3),
                    borrowDate: DbRead.Date(r, 5),
                    returnDate: DbRead.NullableDate(r, 6),
                    memberName: DbRead.Str(r, 2),
                    bookTitle:  DbRead.Str(r, 4)));
            }
            return list;
        }

        // ---------- Write ----------

        /// <summary>
        /// Takes one copy off the shelf and records the loan. Returns the new BorrowID.
        /// Throws InvalidOperationException if no copy is available.
        /// </summary>
        public int Borrow(int memberId, int bookId, DateTime borrowDate)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();   // not committed = rolled back on dispose

            // "Quantity > 0" inside the UPDATE makes the check-and-decrement atomic,
            // so two people can't borrow the last copy at the same time.
            using (var stock = new SqlCommand(
                "UPDATE tblBook SET Quantity = Quantity - 1 WHERE BookID = @book AND Quantity > 0;",
                conn, tx))
            {
                stock.Parameters.AddWithValue("@book", bookId);
                if (stock.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException("No copies of this book are available.");
            }

            int borrowId;
            using (var insert = new SqlCommand(
                "INSERT INTO tblBorrow (MemberID, BookID, BorrowDate) " +
                "OUTPUT INSERTED.BorrowID " +
                "VALUES (@member, @book, @date);",
                conn, tx))
            {
                insert.Parameters.AddWithValue("@member", memberId);
                insert.Parameters.AddWithValue("@book", bookId);
                insert.Parameters.AddWithValue("@date", borrowDate);
                borrowId = Convert.ToInt32(insert.ExecuteScalar());
            }

            tx.Commit();
            return borrowId;
        }

        /// <summary>
        /// Marks a loan returned and puts the copy back on the shelf.
        /// Throws InvalidOperationException if it was already returned or doesn't exist.
        /// </summary>
        public void Return(int borrowId, DateTime returnDate)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            using (var close = new SqlCommand(
                "UPDATE tblBorrow SET ReturnDate = @date WHERE BorrowID = @id AND ReturnDate IS NULL;",
                conn, tx))
            {
                close.Parameters.AddWithValue("@date", returnDate);
                close.Parameters.AddWithValue("@id", borrowId);
                if (close.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException(
                        "This book has already been returned, or the record no longer exists.");
            }

            using (var stock = new SqlCommand(
                "UPDATE tblBook SET Quantity = Quantity + 1 " +
                "WHERE BookID = (SELECT BookID FROM tblBorrow WHERE BorrowID = @id);",
                conn, tx))
            {
                stock.Parameters.AddWithValue("@id", borrowId);
                stock.ExecuteNonQuery();
            }

            tx.Commit();
        }
    }
}
