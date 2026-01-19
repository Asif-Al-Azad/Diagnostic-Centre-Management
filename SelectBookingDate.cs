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
    public partial class SelectBookingDate : Form
    {
        public DateTime SelectedDate { get; private set; }

        public SelectBookingDate()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            SelectedDate = dtpBookingDate.Value.Date;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
