using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosticCenterManagement
{
    public partial class LoginOption : Form
    {
        public LoginOption()
        {
            InitializeComponent();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            AdminLogin al = new AdminLogin();
            al.Show();
        }

        private void btnPatientLogin_Click(object sender, EventArgs e)
        {
            PatientLogin pl = new PatientLogin();
            pl.Show();

        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            PatientRegistration pr = new PatientRegistration();
            pr.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DashBoard d = new DashBoard();
            d.Show();
            this.Close();
        }

        private void LoginOption_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
