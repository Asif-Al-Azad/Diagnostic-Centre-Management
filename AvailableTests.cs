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
    public partial class AvailableTests : Form
    {
        public AvailableTests()
        {
            InitializeComponent();
        }

        string connStr =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\DiagnosticCenterManagement\DiagnosticCentreDB.mdf;Integrated Security=True";

        private void AvailableTests_Load(object sender, EventArgs e)
        {
            LoadTests();
            ApplyGridDesign();

            dgvTests.Columns[0].HeaderText = "Test Name";
            dgvTests.Columns[1].HeaderText = "Price (BDT)";


            if (!dgvTests.Columns.Contains("btnBook"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnBook";
                btn.HeaderText = "Action";
                btn.Text = "Book";
                btn.UseColumnTextForButtonValue = true;

                dgvTests.Columns.Add(btn);
            }
        }

        void LoadTests()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT TestName, Price FROM Tests", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTests.DataSource = dt;
                dgvTests.ReadOnly = true;

            }
        }

        void ApplyGridDesign()
        {
            dgvTests.RowHeadersVisible = false;
            dgvTests.AllowUserToAddRows = false;
            dgvTests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTests.BackgroundColor = Color.White;
            dgvTests.BorderStyle = BorderStyle.None;

            dgvTests.EnableHeadersVisualStyles = false;
            dgvTests.ColumnHeadersHeight = 45;
            dgvTests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 127, 84);
            dgvTests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvTests.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 241);
            dgvTests.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTests.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvTests.AllowUserToResizeColumns = false;
            dgvTests.AllowUserToResizeRows = false;
            dgvTests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void textTestSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = dgvTests.DataSource as DataTable;

            if (dt != null)
            {
                string filter = string.Format("[TestName] LIKE '%{0}%'", textTestSearch.Text);

                dt.DefaultView.RowFilter = filter;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvTests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvTests.Columns[e.ColumnIndex].Name == "btnBook")
            {
                if (PatientSession.IsLoggedIn == false)
                {
                    MessageBox.Show("Please login first to book test");

                    return;
                }

                string testName = dgvTests.Rows[e.RowIndex].Cells["TestName"].Value.ToString();
                decimal price = Convert.ToDecimal(
                    dgvTests.Rows[e.RowIndex].Cells["Price"].Value);

                DialogResult dr = MessageBox.Show(
    $"Confirm booking for {testName}?",
    "Confirm",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                SelectBookingDate frm = new SelectBookingDate();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DateTime bookingDate = frm.SelectedDate;
                    SaveTestBooking(testName, price, bookingDate);
                }



            }
        }


        void SaveTestBooking(string testName, decimal price, DateTime bookingDate)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        INSERT INTO TestBookings
        (PatientName, TestName, Price, BookingDate, Status)
        VALUES
        (@pname, @test, @price, @date, 'Pending')";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pname", PatientSession.PatientName);
                cmd.Parameters.AddWithValue("@test", testName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@date", bookingDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Test booking requested successfully");
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
