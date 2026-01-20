using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DiagnosticCenterManagement
{
    public partial class SearchDoctor : Form
    {
        public SearchDoctor()
        {
            InitializeComponent();
        }

        string connStr =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\DiagnosticCenterManagement\DiagnosticCentreDB.mdf;Integrated Security=True";
        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        private void SearchDoctor_Load(object sender, EventArgs e)
        {
            LoadBranch();
            LoadSpecializations();
            LoadDays();
            LoadAllDoctors();
            this.ActiveControl = panel2;

            if (!dgvDoctors.Columns.Contains("btnDetails"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnDetails";
                btn.HeaderText = "Action";
                btn.Text = "See Details";
                btn.UseColumnTextForButtonValue = true;

                dgvDoctors.Columns.Add(btn);
                dgvDoctors.ReadOnly = true;
            }
        }

            void LoadBranch()
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
            cmbDay.Items.Add("Friday");
            cmbDay.Items.Add("Saturday");
            cmbDay.Items.Add("Sunday");
            cmbDay.Items.Add("Monday");
            cmbDay.Items.Add("Tuesday");
            cmbDay.Items.Add("Wednesday");
            cmbDay.Items.Add("Thursday");

            cmbDay.SelectedIndex = 0;
        }

        void LoadAllDoctors()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
               
                string query = @"
            SELECT 
                d.DoctorName AS [Doctor Name], 
                s.SpecializationName AS [Speciality],
                b.BranchName AS [Branch]
            FROM Doctors d
            INNER JOIN Specializations s ON d.SpecializationId = s.SpecializationId
            INNER JOIN Branch b ON d.BranchId = b.BranchId";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDoctors.DataSource = dt;
                ApplyGridDesign();
                
            }
        }

        void LoadDoctors()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT 
                d.DoctorName AS [Doctor Name], 
                s.SpecializationName AS [Speciality],
                b.BranchName AS [Branch]
            FROM Doctors d
            INNER JOIN Specializations s ON d.SpecializationId = s.SpecializationId
            INNER JOIN Branch b ON d.BranchId = b.BranchId
            WHERE 
                d.BranchId = @BranchId
                AND d.SpecializationId = @SpecId
                AND d.AvailableDay = @Day";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BranchId", cmbBranch.SelectedValue);
                cmd.Parameters.AddWithValue("@SpecId", cmbSpecialization.SelectedValue);
                cmd.Parameters.AddWithValue("@Day", cmbDay.SelectedItem.ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDoctors.DataSource = dt;
                ApplyGridDesign();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a branch");
                return;
            }

            if (cmbSpecialization.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a specialization");
                return;
            }

            if (cmbDay.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a day");
                return;
            }

            LoadDoctors();
        }

        void ApplyGridDesign()
        {
            dgvDoctors.RowHeadersVisible = false; 
            dgvDoctors.AllowUserToAddRows = false; 
            dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            dgvDoctors.BackgroundColor = Color.White; 
            dgvDoctors.BorderStyle = BorderStyle.None;

            dgvDoctors.EnableHeadersVisualStyles = false;
            dgvDoctors.ColumnHeadersHeight = 45;
            dgvDoctors.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 127, 84); 
            dgvDoctors.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDoctors.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvDoctors.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDoctors.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 241); 
            dgvDoctors.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDoctors.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDoctors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; 


    dgvDoctors.AllowUserToResizeColumns = false;
            dgvDoctors.AllowUserToResizeRows = false;

            dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgvDoctors.Columns[e.ColumnIndex].Name == "btnDetails")
            {
                string name = dgvDoctors.Rows[e.RowIndex].Cells["Doctor Name"].Value.ToString();
                string spec = dgvDoctors.Rows[e.RowIndex].Cells["Speciality"].Value.ToString();
                string branch = dgvDoctors.Rows[e.RowIndex].Cells["Branch"].Value.ToString();

                DoctorProfile profile = new DoctorProfile();
                profile.DoctorName = name;
                profile.Specialization = spec;
                profile.BranchName = branch;
                profile.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cmbBranch.SelectedIndex = 0;
            cmbSpecialization.SelectedIndex = 0;
            cmbDay.SelectedIndex = 0;
  
            LoadAllDoctors();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = dgvDoctors.DataSource as DataTable;

            if (dt != null)
            {
                string filter = string.Format("[Doctor Name] LIKE '%{0}%' OR [Speciality] LIKE '%{0}%'", textSearch.Text);

                dt.DefaultView.RowFilter = filter;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
