using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Library_Management_System
{
    internal class SqlConn
    {
        const string connectionLocal = "Server=DESKTOP-LK1HO70;Database=librarydb;" +
            "User Id=sa;Password=12345678;Encrypt=True;TrustServerCertificate=True;";

        const string connectionString = connectionLocal;
        public string ConnectionString
        {
            get { return connectionString; }
        }
    }
}
