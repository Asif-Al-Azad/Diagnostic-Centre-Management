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
    public partial class ManagePatients : Form
    {

        string connStr =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\DiagnosticCenterManagement\DiagnosticCentreDB.mdf;Integrated Security=True";

        public ManagePatients()
        {
            InitializeComponent();
        }

        void ApplyGridDesign()
        {
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;

            dgvPatients.EnableHeadersVisualStyles = false;
            dgvPatients.ColumnHeadersHeight = 45;
            dgvPatients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 127, 84);
            dgvPatients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvPatients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPatients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 241);
            dgvPatients.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPatients.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvPatients.AllowUserToResizeColumns = false;
            dgvPatients.AllowUserToResizeRows = false;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            if (dgvPatients.Columns["PatientId"] != null)
            {
                dgvPatients.Columns["PatientId"].Visible = false;
            }
        }

        void LoadPatients()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT PatientId, Name, Phone, Gender FROM Patients", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPatients.DataSource = dt;

                ApplyGridDesign();
                dgvPatients.ReadOnly = true;
            }
        }

        private void ManagePatients_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient");
                return;
            }

            int patientId = Convert.ToInt32(
                dgvPatients.SelectedRows[0].Cells["PatientId"].Value);

            DialogResult dr = MessageBox.Show(
                "Are you sure to delete?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Patients WHERE PatientId=@Id", conn);

                    cmd.Parameters.AddWithValue("@Id", patientId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadPatients(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
