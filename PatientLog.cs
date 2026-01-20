using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticCenterManagement
{
    public class PatientLog : UserLogin
    {
        public string Phone { get; set; }
        public string Password { get; set; }

        string connStr =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\DiagnosticCenterManagement\DiagnosticCentreDB.mdf;Integrated Security=True";

        public override bool Login()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT PatientId, Name, Phone 
            FROM Patients 
            WHERE Phone = @Phone AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Password", Password);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    PatientSession.PatientId = Convert.ToInt32(dr["PatientId"]);
                    PatientSession.PatientName = dr["Name"].ToString();
                    PatientSession.Phone = dr["Phone"].ToString();
                    PatientSession.IsLoggedIn = true;

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
