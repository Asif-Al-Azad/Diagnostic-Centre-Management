namespace DiagnosticCenterManagement
{
    partial class PatientMessages
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientMessages));
            this.dgvTestMessages = new System.Windows.Forms.DataGridView();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.dgvDoctorMessages = new System.Windows.Forms.DataGridView();
            this.btnClearDoctorHistory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTestMessages
            // 
            this.dgvTestMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestMessages.Location = new System.Drawing.Point(12, 245);
            this.dgvTestMessages.Name = "dgvTestMessages";
            this.dgvTestMessages.RowHeadersWidth = 51;
            this.dgvTestMessages.RowTemplate.Height = 24;
            this.dgvTestMessages.Size = new System.Drawing.Size(561, 271);
            this.dgvTestMessages.TabIndex = 0;
            this.dgvTestMessages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestMessages_CellContentClick);
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClearHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearHistory.Location = new System.Drawing.Point(148, 522);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(219, 41);
            this.btnClearHistory.TabIndex = 4;
            this.btnClearHistory.Text = "Clear Test History";
            this.btnClearHistory.UseVisualStyleBackColor = false;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // dgvDoctorMessages
            // 
            this.dgvDoctorMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctorMessages.Location = new System.Drawing.Point(581, 245);
            this.dgvDoctorMessages.Name = "dgvDoctorMessages";
            this.dgvDoctorMessages.RowHeadersWidth = 51;
            this.dgvDoctorMessages.RowTemplate.Height = 24;
            this.dgvDoctorMessages.Size = new System.Drawing.Size(561, 271);
            this.dgvDoctorMessages.TabIndex = 5;
            // 
            // btnClearDoctorHistory
            // 
            this.btnClearDoctorHistory.BackColor = System.Drawing.Color.SeaGreen;
            this.btnClearDoctorHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearDoctorHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClearDoctorHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearDoctorHistory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearDoctorHistory.Location = new System.Drawing.Point(742, 522);
            this.btnClearDoctorHistory.Name = "btnClearDoctorHistory";
            this.btnClearDoctorHistory.Size = new System.Drawing.Size(219, 41);
            this.btnClearDoctorHistory.TabIndex = 6;
            this.btnClearDoctorHistory.Text = "Clear Doctor History";
            this.btnClearDoctorHistory.UseVisualStyleBackColor = false;
            this.btnClearDoctorHistory.Click += new System.EventHandler(this.btnClearDrHistory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-311, -62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1760, 1209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 105);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 37);
            this.label3.TabIndex = 43;
            this.label3.Text = "Digital Diagnostic";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(11, 667);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Crimson;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(66, 667);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 41);
            this.btnBack.TabIndex = 45;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PatientMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 763);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClearDoctorHistory);
            this.Controls.Add(this.dgvDoctorMessages);
            this.Controls.Add(this.btnClearHistory);
            this.Controls.Add(this.dgvTestMessages);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PatientMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientMessages";
            this.Load += new System.EventHandler(this.PatientMessages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTestMessages;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.DataGridView dgvDoctorMessages;
        private System.Windows.Forms.Button btnClearDoctorHistory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnBack;
    }
}