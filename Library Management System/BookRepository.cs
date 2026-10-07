using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    public class BookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private const string SelectSql =
            "SELECT b.BookID, b.Title, b.Author, b.CategoryID, c.Category, b.Quantity " +
            "FROM tblBook b INNER JOIN tblCategories c ON b.CategoryID = c.CategoryID";

        // ---------- Read ----------

        public List<BookClass> GetAll()
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SelectSql + " ORDER BY b.Title;", conn);
            conn.Open();
            return ReadBooks(cmd);
        }

        /// Search by BookID (exact) or Title / Author / Category (contains).
        public List<BookClass> Search(string field, string value)
        {
            string? column = field.Trim().ToLowerInvariant() switch
            {
                "bookid" => "b.BookID",
                "title" => "b.Title",
                "author" => "b.Author",
                "category" => "c.Category",
                _ => null
            };

            if (column is null)
                throw new ArgumentException(
                    $"Unknown search field '{field.Trim()}'. Use BookID, Title, Author or Category.");

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand { Connection = conn };

            if (column == "b.BookID")
            {
                if (!int.TryParse(value.Trim(), out int id))
                    throw new ArgumentException("BookID must be a number.");

                cmd.CommandText = SelectSql + " WHERE b.BookID = @v ORDER BY b.Title;";
                cmd.Parameters.AddWithValue("@v", id);
            }
            else
            {
                // column comes from the switch above, only @v comes from the user
                cmd.CommandText = SelectSql + $" WHERE {column} LIKE @v ORDER BY b.Title;";
                cmd.Parameters.AddWithValue("@v", "%" + value.Trim() + "%");
            }

            conn.Open();
            return ReadBooks(cmd);
        }

        public List<CategoryClass> GetCategories()
        {
            var list = new List<CategoryClass>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT CategoryID, Category FROM tblCategories ORDER BY Category;", conn);
            conn.Open();
            using var r = cmd.ExecuteReader();
            while (r.Read())
                list.Add(new CategoryClass(ToInt(r, 0), ToStr(r, 1)));

            return list;
        }

        // ---------- Write ----------

        public int Add(BookClass book)
        {
            const string sql =
                "INSERT INTO tblBook (Title, Author, CategoryID, Quantity) " +
                "OUTPUT INSERTED.BookID " +
                "VALUES (@title, @author, @categoryId, @quantity);";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            AddBookParameters(cmd, book);
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public bool Update(BookClass book)
        {
            const string sql =
                "UPDATE tblBook " +
                "SET Title = @title, Author = @author, CategoryID = @categoryId, Quantity = @quantity " +
                "WHERE BookID = @bookId;";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            AddBookParameters(cmd, book);
            cmd.Parameters.AddWithValue("@bookId", book.BookID);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Delete(int bookId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM tblBook WHERE BookID = @bookId;", conn);
            cmd.Parameters.AddWithValue("@bookId", bookId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // ---------- Helpers ----------
        private static void AddBookParameters(SqlCommand cmd, BookClass book)
        {
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@categoryId", book.CategoryID);
            cmd.Parameters.AddWithValue("@quantity", book.Quantity);
        }

        private static List<BookClass> ReadBooks(SqlCommand cmd)
        {
            var list = new List<BookClass>();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new BookClass(
                    bookID: ToInt(r, 0),
                    title: ToStr(r, 1),
                    author: ToStr(r, 2),
                    categoryID: ToInt(r, 3),
                    quantity: ToInt(r, 5),
                    categoryName: ToStr(r, 4)));
            }
            return list;
        }

        // tblBook.CategoryID and Quantity are SMALLINT, and most columns allow NULL.
        // GetInt32 / GetString would throw on those, so read through these helpers.
        private static int ToInt(SqlDataReader r, int i) =>
            r.IsDBNull(i) ? 0 : Convert.ToInt32(r.GetValue(i));

        private static string ToStr(SqlDataReader r, int i) =>
            r.IsDBNull(i) ? "" : r.GetString(i);
    }
}