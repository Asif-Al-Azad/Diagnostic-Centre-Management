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
    public partial class ManageDoctor : Form
    {
        public ManageDoctor()
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


        string connStr =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\DiagnosticCenterManagement\DiagnosticCentreDB.mdf;Integrated Security=True";

        int selectedDoctorId = 0;

        void LoadDoctors()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT 
               d.DoctorId,
               d.DoctorName,
               b.BranchName      AS Branch,
               s.SpecializationName AS Specialization,
               d.AvailableDay
            FROM Doctors d
           JOIN Branch b ON d.BranchId = b.BranchId
           JOIN Specializations s ON d.SpecializationId = s.SpecializationId";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDoctors.DataSource = dt;
                dgvDoctors.Columns["DoctorId"].Visible = false;
                dgvDoctors.ReadOnly = true;
            }
        }

        void LoadBranches()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT BranchId, BranchName FROM Branch", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow dr = dt.NewRow();
                dr["BranchId"] = 0;
                dr["BranchName"] = "Select Branch";
                dt.Rows.InsertAt(dr, 0);

                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.ValueMember = "BranchId";
                cmbBranch.DataSource = dt;
                cmbBranch.SelectedIndex = 0;
            }
        }

        void LoadSpecializations()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT SpecializationId, SpecializationName FROM Specializations", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow dr = dt.NewRow();
                dr["SpecializationId"] = 0;
                dr["SpecializationName"] = "Select Specialization";
                dt.Rows.InsertAt(dr, 0);

                cmbSpecialization.DisplayMember = "SpecializationName";
                cmbSpecialization.ValueMember = "SpecializationId";
                cmbSpecialization.DataSource = dt;
                cmbSpecialization.SelectedIndex = 0;
            }
        }

        void LoadDays()
        {
            cmbDay.Items.Clear();
            cmbDay.Items.Add("Select Day");
            cmbDay.Items.Add("Saturday");
            cmbDay.Items.Add("Sunday");
            cmbDay.Items.Add("Monday");
            cmbDay.Items.Add("Tuesday");
            cmbDay.Items.Add("Wednesday");
            cmbDay.Items.Add("Thursday");
            cmbDay.SelectedIndex = 0;
        }

        private void ManageDoctor_Load(object sender, EventArgs e)
        {
            ApplyCustomGridDesign(dgvDoctors);
            LoadDoctors();
            LoadBranches();
            LoadSpecializations();
            LoadDays();
        }

        void ClearFields()
        {
            txtDoctorName.Clear();
            cmbBranch.SelectedIndex = 0;
            cmbSpecialization.SelectedIndex = 0;
            cmbDay.SelectedIndex = 0;
            selectedDoctorId = 0;
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            if (txtDoctorName.Text == "")
            {
                MessageBox.Show("Enter doctor name");
                return;
            }

            if (cmbBranch.SelectedIndex == 0 ||
                cmbSpecialization.SelectedIndex == 0 ||
                cmbDay.SelectedIndex == 0)
            {
                MessageBox.Show("Please select all fields");
                return;
            }

           

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            INSERT INTO Doctors
            (DoctorName, BranchId, SpecializationId, AvailableDay)
            VALUES
            (@name, @branch, @spec, @day)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtDoctorName.Text);
                cmd.Parameters.AddWithValue("@branch", cmbBranch.SelectedValue);
                cmd.Parameters.AddWithValue("@spec", cmbSpecialization.SelectedValue);
                cmd.Parameters.AddWithValue("@day", cmbDay.Text);
                

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Doctor added successfully");
            LoadDoctors();
            ClearFields();
        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            selectedDoctorId = Convert.ToInt32(
                dgvDoctors.Rows[e.RowIndex].Cells["DoctorId"].Value);

            txtDoctorName.Text =
                dgvDoctors.Rows[e.RowIndex].Cells["DoctorName"].Value.ToString();

            cmbBranch.Text =
                dgvDoctors.Rows[e.RowIndex].Cells["Branch"].Value.ToString();

            cmbSpecialization.Text =
                dgvDoctors.Rows[e.RowIndex].Cells["Specialization"].Value.ToString();

            cmbDay.Text =
                dgvDoctors.Rows[e.RowIndex].Cells["AvailableDay"].Value.ToString();
        }

        private void btnUpdateDoctor_Click(object sender, EventArgs e)
        {
            if (selectedDoctorId == 0)
            {
                MessageBox.Show("Please select a doctor first");
                return;
            }

            if (txtDoctorName.Text == "" ||
                cmbBranch.SelectedIndex == 0 ||
                cmbSpecialization.SelectedIndex == 0 ||
                cmbDay.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                UPDATE Doctors
                SET DoctorName = @name,
                BranchId = @branch,
                SpecializationId = @spec,
                AvailableDay = @day
                WHERE DoctorId = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtDoctorName.Text);
                cmd.Parameters.AddWithValue("@branch", cmbBranch.SelectedValue);
                cmd.Parameters.AddWithValue("@spec", cmbSpecialization.SelectedValue);
                cmd.Parameters.AddWithValue("@day", cmbDay.Text);
                cmd.Parameters.AddWithValue("@id", selectedDoctorId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Doctor updated successfully");

            LoadDoctors();   
            ClearFields();
        }

        private void btnDeleteDoctor_Click(object sender, EventArgs e)
        {
            if (selectedDoctorId == 0)
            {
                MessageBox.Show("Please select a doctor first");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this doctor?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Doctors WHERE DoctorId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedDoctorId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Doctor deleted successfully");

            LoadDoctors();
            ClearFields();
        }

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
