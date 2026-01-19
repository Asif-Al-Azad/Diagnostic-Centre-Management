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
    public partial class AdminLogin : Form
    {

 

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            UserLogin admin = new AdminLog()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            if (admin.Login())
            {
                MessageBox.Show("Admin Login Successful");
                new AdminDashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Admin Login");
            }

        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
