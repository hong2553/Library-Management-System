using System.Data;
using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    /// <summary>
    /// Safe readers for columns that may be NULL or SMALLINT.
    /// (GetInt32 / GetString throw on those.)
    /// </summary>
    internal static class DbRead
    {
        public static int Int(SqlDataReader r, int i) =>
            r.IsDBNull(i) ? 0 : Convert.ToInt32(r.GetValue(i));

        public static string Str(SqlDataReader r, int i) =>
            r.IsDBNull(i) ? "" : r.GetString(i).Trim();

        public static DateTime Date(SqlDataReader r, int i) =>
            r.IsDBNull(i) ? DateTime.MinValue : r.GetDateTime(i);

        public static DateTime? NullableDate(SqlDataReader r, int i) =>
            r.IsDBNull(i) ? null : r.GetDateTime(i);

        public static char Chr(SqlDataReader r, int i)
        {
            if (r.IsDBNull(i)) return '?';
            string s = r.GetString(i).Trim();
            return s.Length > 0 ? s[0] : '?';
        }
    }
}
