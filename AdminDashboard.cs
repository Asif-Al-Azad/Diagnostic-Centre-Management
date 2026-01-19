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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnManagePatients_Click(object sender, EventArgs e)
        {
            ManagePatients mp = new ManagePatients();
            mp.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBookedPatients_Click(object sender, EventArgs e)
        {
            BookedPatients bp = new BookedPatients();
            bp.Show();
        }

        private void btnManageDoctors_Click(object sender, EventArgs e)
        {
            ManageDoctor md = new ManageDoctor();
            md.Show();
        }

        private void btnManageTests_Click(object sender, EventArgs e)
        {
            ManageTests frm = new ManageTests();
            frm.ShowDialog();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
