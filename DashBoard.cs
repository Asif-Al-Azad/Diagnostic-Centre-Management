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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            if (PatientSession.IsLoggedIn)
            {
                button5.Visible = false;
                lblWelcome.Text = "Welcome, " + PatientSession.PatientName;

            }
            if (PatientSession.IsLoggedIn)
            {

                btnLogout.Visible = true;


            }
            else
            {
                btnLogout.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AvailableTests at = new AvailableTests();
            at.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginOption lo = new LoginOption();
            lo.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchDoctor at = new SearchDoctor();
            at.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PatientSession.IsLoggedIn == false)
            {
                MessageBox.Show("Please login first to book");

                return; 
            }

            PatientMessages pm = new PatientMessages();
            pm.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            PatientSession.Logout();
           

            MessageBox.Show("Logged out successfully");

            DashBoard d = new DashBoard();
            d.Show();
            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
