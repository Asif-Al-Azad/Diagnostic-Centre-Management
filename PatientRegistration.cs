using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosticCenterManagement
{
    public partial class PatientRegistration : Form
    {

        string connStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=|DataDirectory|\DiagnosticCentreDB.mdf;
Integrated Security=True";
        public PatientRegistration()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" ||
       txtPhone.Text == "" ||
       cmbGender.SelectedIndex == -1 ||
       txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO Patients
                    (Name, Phone, Gender, Password)
                    VALUES
                    (@Name, @Phone, @Gender, @Password)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }



            MessageBox.Show("Registration successful!");

            LoginOption lo = new LoginOption();
            lo.Show();

            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
