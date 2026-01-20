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
    public partial class BookedPatients : Form
    {
        string connStr =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\DiagnosticCenterManagement\DiagnosticCentreDB.mdf;Integrated Security=True";

        public BookedPatients()
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


       

        private void BookedPatients_Load(object sender, EventArgs e)
        {
            ApplyCustomGridDesign(dgvDoctorBookings);

            ApplyCustomGridDesign(dgvTestBookings);

            LoadPendingTestBookings();   
            LoadPendingDoctorBookings();
            SetupTestBookingGrid();      
            SetupDocotorBookingGrid();

            dgvTestBookings.CellContentClick += dgvTestBookings_CellContentClick;
            dgvDoctorBookings.CellContentClick += dgvDoctorBookings_CellContentClick;


        }

        void LoadPendingTestBookings()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        SELECT BookingId, PatientName, TestName, BookingDate
        FROM TestBookings
        WHERE Status = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTestBookings.AutoGenerateColumns = true;
                dgvTestBookings.DataSource = dt;

                if (dgvTestBookings.Columns.Contains("BookingId"))
                    dgvTestBookings.Columns["BookingId"].Visible = false;
                dgvTestBookings.ReadOnly = true;
            }
        }

        void LoadPendingDoctorBookings()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT BookingId, PatientName, DoctorName, BookingDate
            FROM DoctorBookings
            WHERE Status = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDoctorBookings.DataSource = dt;
                dgvDoctorBookings.Columns["BookingId"].Visible = false;
                dgvDoctorBookings.ReadOnly = true;
            }
        }

        void SetupTestBookingGrid()
        {
            if (!dgvTestBookings.Columns.Contains("colApprove"))
            {
                DataGridViewButtonColumn approveBtn = new DataGridViewButtonColumn();
                approveBtn.Name = "colApprove";
                approveBtn.HeaderText = "Approve";
                approveBtn.Text = "Approve";
                approveBtn.UseColumnTextForButtonValue = true;
                dgvTestBookings.Columns.Add(approveBtn);
            }

            if (!dgvTestBookings.Columns.Contains("colDecline"))
            {
                DataGridViewButtonColumn declineBtn = new DataGridViewButtonColumn();
                declineBtn.Name = "colDecline";
                declineBtn.HeaderText = "Decline";
                declineBtn.Text = "Decline";
                declineBtn.UseColumnTextForButtonValue = true;
                dgvTestBookings.Columns.Add(declineBtn);
            }
        }

        void SetupDocotorBookingGrid()
        {
            if (!dgvDoctorBookings.Columns.Contains("colApprove"))
            {
                DataGridViewButtonColumn approveBtn = new DataGridViewButtonColumn();
                approveBtn.Name = "colApprove";
                approveBtn.HeaderText = "Approve";
                approveBtn.Text = "Approve";
                approveBtn.UseColumnTextForButtonValue = true;
                dgvDoctorBookings.Columns.Add(approveBtn);
            }

            if (!dgvDoctorBookings.Columns.Contains("colDecline"))
            {
                DataGridViewButtonColumn declineBtn = new DataGridViewButtonColumn();
                declineBtn.Name = "colDecline";
                declineBtn.HeaderText = "Decline";
                declineBtn.Text = "Decline";
                declineBtn.UseColumnTextForButtonValue = true;
                dgvDoctorBookings.Columns.Add(declineBtn);
            }
        }


        private void dgvTestBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTestBookings.Enabled = false;   

            try
            {
                if (e.RowIndex < 0) return;

                string colName = dgvTestBookings.Columns[e.ColumnIndex].Name;

                if (colName != "colApprove" && colName != "colDecline")
                    return;

                if (!dgvTestBookings.Columns.Contains("BookingId"))
                    return;

                int bookingId = Convert.ToInt32(
                    dgvTestBookings.Rows[e.RowIndex].Cells["BookingId"].Value);

                if (colName == "colApprove")
                    UpdateTestBookingStatus(bookingId, "Approved");
                else
                    UpdateTestBookingStatus(bookingId, "Declined");
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again");
            }
            finally
            {
                dgvTestBookings.Enabled = true; 
            }
        }

        void UpdateTestBookingStatus(int bookingId, string status)
        {
            if (bookingId <= 0) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"UPDATE TestBookings 
                         SET Status = @status 
                         WHERE BookingId = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", bookingId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPendingTestBookings();
            SetupTestBookingGrid();
        }


        private void dgvDoctorBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDoctorBookings.Enabled = false;  

            try
            {
                if (e.RowIndex < 0) return;

                string colName = dgvDoctorBookings.Columns[e.ColumnIndex].Name;

                if (colName != "colApprove" && colName != "colDecline")
                    return;

                if (!dgvDoctorBookings.Columns.Contains("BookingId"))
                    return;

                int bookingId = Convert.ToInt32(
                    dgvDoctorBookings.Rows[e.RowIndex].Cells["BookingId"].Value);

                if (colName == "colApprove")
                    UpdateDoctorBookingStatus(bookingId, "Approved");
                else
                    UpdateDoctorBookingStatus(bookingId, "Declined");
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again");
            }
            finally
            {
                dgvDoctorBookings.Enabled = true; 
            }
        }

        void UpdateDoctorBookingStatus(int bookingId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            UPDATE DoctorBookings
            SET Status = @status
            WHERE BookingId = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", bookingId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show($"Doctor booking {status}");
            LoadPendingDoctorBookings(); 
            SetupDocotorBookingGrid();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
