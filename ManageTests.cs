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
    public partial class ManageTests : Form
    {
        public ManageTests()
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



        void LoadTests()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        SELECT TestId, TestName, Price
        FROM Tests";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTests.DataSource = dt;
                dgvTests.Columns["TestId"].Visible = false;
                dgvTests.ReadOnly = true;
                dgvTests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void ManageTests_Load(object sender, EventArgs e)
        {
            ApplyCustomGridDesign(dgvTests);
            LoadTests();
        }

        void ClearFields()
        {
            txtTestName.Clear();
            txtPrice.Clear();
            selectedTestId = 0;
        }



        private void btnAddTest_Click(object sender, EventArgs e)
        {
            if (txtTestName.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Enter test name and price");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        INSERT INTO Tests (TestName, Price)
        VALUES (@name, @price)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtTestName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Test added successfully");
            LoadTests();
            ClearFields();
        }


        int selectedTestId = 0;
        private void dgvTests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedTestId = Convert.ToInt32(
                dgvTests.Rows[e.RowIndex].Cells["TestId"].Value);

            txtTestName.Text =
                dgvTests.Rows[e.RowIndex].Cells["TestName"].Value.ToString();

            txtPrice.Text =
                dgvTests.Rows[e.RowIndex].Cells["Price"].Value.ToString();
        }

        private void btnUpdateTest_Click(object sender, EventArgs e)
        {
            if (selectedTestId == 0)
            {
                MessageBox.Show("Select a test first");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        UPDATE Tests
        SET TestName = @name,
            Price = @price
        WHERE TestId = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtTestName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@id", selectedTestId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Test updated successfully");
            LoadTests();
            ClearFields();
        }

        private void btnDeleteTest_Click(object sender, EventArgs e)
        {
            if (selectedTestId == 0)
            {
                MessageBox.Show("Select a test first");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete this test?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Tests WHERE TestId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedTestId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Test deleted");
            LoadTests();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
