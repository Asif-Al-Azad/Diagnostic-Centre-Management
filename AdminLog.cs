using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DiagnosticCenterManagement
{
    public class AdminLog : UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        string connStr =
       @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=|DataDirectory|\DiagnosticCentreDB.mdf;
Integrated Security=True";
        public override bool Login()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT COUNT(*) FROM Admins
            WHERE Username = @u AND Password = @p";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", Username);
                cmd.Parameters.AddWithValue("@p", Password);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
