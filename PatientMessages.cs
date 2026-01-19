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
    public partial class PatientMessages : Form
    {

        string connStr =
@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=|DataDirectory|\DiagnosticCentreDB.mdf;
Integrated Security=True";
        public PatientMessages()
        {
            InitializeComponent();
        }



        void ApplyCustomGridDesign(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 127, 84);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 241);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }


        private void PatientMessages_Load(object sender, EventArgs e)
        {

            ApplyCustomGridDesign(dgvTestMessages);

            ApplyCustomGridDesign(dgvDoctorMessages);

            LoadTestMessages();
            LoadDoctorMessages();

        }

        void LoadTestMessages()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        SELECT TestName, Status
        FROM TestBookings
        WHERE PatientName = @pname
        AND Status <> 'Pending'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pname", PatientSession.PatientName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTestMessages.DataSource = dt;
            }
        }

        void LoadDoctorMessages()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT DoctorName, BookingDate, Status
            FROM DoctorBookings
            WHERE PatientName = @pname
            AND Status <> 'Pending'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pname", PatientSession.PatientName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDoctorMessages.DataSource = dt;
            }
        }

       

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
       "Are you sure you want to clear message history?",
       "Confirm",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            DELETE FROM TestBookings
            WHERE PatientName = @pname
            AND Status <> 'Pending'";


                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pname", PatientSession.PatientName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadTestMessages();
            MessageBox.Show("Message history cleared");
        }

        private void dgvTestMessages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClearDrHistory_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
        "Are you sure you want to clear doctor booking history?",
        "Confirm",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            DELETE FROM DoctorBookings
            WHERE PatientName = @pname
            AND Status <> 'Pending'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pname", PatientSession.PatientName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDoctorMessages();
            MessageBox.Show("Doctor booking history cleared");

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
