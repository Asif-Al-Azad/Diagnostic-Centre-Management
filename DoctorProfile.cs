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
    public partial class DoctorProfile : Form
    {
        string connStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=|DataDirectory|\DiagnosticCentreDB.mdf;
Integrated Security=True";




        public string DoctorName { get; set; }
        public string BranchName { get; set; }
        public string Specialization { get; set; }
        public DoctorProfile()
        {
            InitializeComponent();
        }

        private void DoctorProfile_Load(object sender, EventArgs e)
        {
            lblName.Text = " " + DoctorName;
            lblBranch.Text = BranchName + " Branch ";
            lblSpeciality.Text = " " + Specialization;
        }

        void SaveDoctorBooking(DateTime bookingDate)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        INSERT INTO DoctorBookings
        (PatientName, DoctorName, BookingDate, Status)
        VALUES
        (@pname, @dname, @date, 'Pending')";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pname", PatientSession.PatientName);
                cmd.Parameters.AddWithValue("@dname", lblName.Text);
                cmd.Parameters.AddWithValue("@date", bookingDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Appointment requested successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (PatientSession.IsLoggedIn == false)
            {
                MessageBox.Show("Please login first to book");

                return; 
            }

            SelectBookingDate frm = new SelectBookingDate();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DateTime bookingDate = frm.SelectedDate;

                SaveDoctorBooking(bookingDate);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
