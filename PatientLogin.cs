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
    public partial class PatientLogin : Form
    {

        public PatientLogin()
        {
            InitializeComponent();
        }

        private void btnPatientLogin_Click(object sender, EventArgs e)
        {
            UserLogin patient = new PatientLog()
            {
                Phone = txtPhone.Text,
                Password = txtPassword.Text
            };

            if (patient.Login())
            {
                MessageBox.Show("Login successful!");

                DashBoard d = new DashBoard();
                d.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid phone or password");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
