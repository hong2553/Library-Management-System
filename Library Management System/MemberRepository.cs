using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    /// <summary>
    /// All database access for tblMember.
    /// Members are identified by phone number (M_Phone is UNIQUE in the database).
    /// </summary>
    public class MemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<MemberClass> GetAll()
        {
            var list = new List<MemberClass>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT MemberID, M_Name, M_Gender, M_Phone, RegisterDate " +
                "FROM tblMember ORDER BY M_Name;", conn);
            conn.Open();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new MemberClass(
                    memberID: DbRead.Int(r, 0),
                    memberName: DbRead.Str(r, 1),
                    gender: DbRead.Chr(r, 2),
                    phone: DbRead.Str(r, 3),
                    registerDate: DbRead.Date(r, 4)));
            }
            return list;
        }

        /// <summary>
        /// Inserts a member and returns the new MemberID.
        /// Throws InvalidOperationException if the phone number is already used.
        /// </summary>
        public int Add(MemberClass member)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            // Friendly pre-check. The UNIQUE constraint is still the real guarantee.
            using (var dup = new SqlCommand(
                "SELECT COUNT(*) FROM tblMember WHERE M_Phone = @phone;", conn))
            {
                dup.Parameters.AddWithValue("@phone", member.Phone);
                if (Convert.ToInt32(dup.ExecuteScalar()) > 0)
                    throw new InvalidOperationException("A member with this phone number already exists.");
            }

            using var cmd = new SqlCommand(
                "INSERT INTO tblMember (M_Name, M_Gender, M_Phone, RegisterDate) " +
                "OUTPUT INSERTED.MemberID " +
                "VALUES (@name, @gender, @phone, @registerDate);", conn);
            AddParameters(cmd, member);
            cmd.Parameters.AddWithValue("@registerDate", member.RegisterDate);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        /// <summary>
        /// Updates the name and gender of the member with this phone number.
        /// (The phone number is the key, so it can't be changed here.)
        /// Returns true if a member was found and updated, false if none matched.
        /// </summary>
        public bool Update(MemberClass member)
        {
            const string sql =
                "UPDATE tblMember SET M_Name = @name, M_Gender = @gender " +
                "WHERE M_Phone = @phone;";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            AddParameters(cmd, member);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Deletes the member with this phone number.
        /// Refuses if they still have unreturned books, because the foreign key
        /// would cascade-delete the loans without giving the stock back.
        /// Returns true if a member was deleted, false if none matched.
        /// </summary>
        public bool Delete(string phone)
        {
            phone = phone.Trim();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            // tblBorrow has no phone column, so JOIN to tblMember to filter by phone.
            using (var check = new SqlCommand(
                "SELECT COUNT(*) FROM tblBorrow br " +
                "INNER JOIN tblMember m ON br.MemberID = m.MemberID " +
                "WHERE m.M_Phone = @phone AND br.ReturnDate IS NULL;", conn))
            {
                check.Parameters.AddWithValue("@phone", phone);
                if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                    throw new InvalidOperationException(
                        "This member still has borrowed books. Return them before deleting the member.");
            }

            using var cmd = new SqlCommand("DELETE FROM tblMember WHERE M_Phone = @phone;", conn);
            cmd.Parameters.AddWithValue("@phone", phone);
            return cmd.ExecuteNonQuery() > 0;
        }

        private static void AddParameters(SqlCommand cmd, MemberClass m)
        {
            cmd.Parameters.AddWithValue("@name", m.MemberName);
            cmd.Parameters.AddWithValue("@gender", m.Gender.ToString());
            cmd.Parameters.AddWithValue("@phone", m.Phone);
        }
    }
}