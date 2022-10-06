namespace QRCodeDemo
{
    partial class FormAttendance
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
            this.dataGridViewAttendance = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonAddAttendance = new System.Windows.Forms.Button();
            this.comboBoxSelectCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAttendance
            // 
            this.dataGridViewAttendance.AllowUserToAddRows = false;
            this.dataGridViewAttendance.AllowUserToDeleteRows = false;
            this.dataGridViewAttendance.AllowUserToResizeColumns = false;
            this.dataGridViewAttendance.AllowUserToResizeRows = false;
            this.dataGridViewAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttendance.Location = new System.Drawing.Point(49, 88);
            this.dataGridViewAttendance.Name = "dataGridViewAttendance";
            this.dataGridViewAttendance.ReadOnly = true;
            this.dataGridViewAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAttendance.Size = new System.Drawing.Size(634, 229);
            this.dataGridViewAttendance.TabIndex = 0;
            this.dataGridViewAttendance.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttendance_CellContentDoubleClick);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(440, 29);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(243, 26);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // buttonAddAttendance
            // 
            this.buttonAddAttendance.BackColor = System.Drawing.Color.LightBlue;
            this.buttonAddAttendance.FlatAppearance.BorderSize = 0;
            this.buttonAddAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddAttendance.Location = new System.Drawing.Point(440, 332);
            this.buttonAddAttendance.Name = "buttonAddAttendance";
            this.buttonAddAttendance.Size = new System.Drawing.Size(243, 44);
            this.buttonAddAttendance.TabIndex = 12;
            this.buttonAddAttendance.Text = "Add Attendance";
            this.buttonAddAttendance.UseVisualStyleBackColor = false;
            this.buttonAddAttendance.Click += new System.EventHandler(this.buttonAddWorkers_Click);
            // 
            // comboBoxSelectCategory
            // 
            this.comboBoxSelectCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectCategory.FormattingEnabled = true;
            this.comboBoxSelectCategory.Items.AddRange(new object[] {
            "WorkersID",
            "Schedule",
            "CheckIn",
            "ChackOut",
            "Duration",
            "Status",
            "Day",
            "Date",
            "AbsentCause"});
            this.comboBoxSelectCategory.Location = new System.Drawing.Point(238, 29);
            this.comboBoxSelectCategory.Name = "comboBoxSelectCategory";
            this.comboBoxSelectCategory.Size = new System.Drawing.Size(196, 28);
            this.comboBoxSelectCategory.TabIndex = 13;
            this.comboBoxSelectCategory.Text = "(Selection)";
            // 
            // FormAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 398);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxSelectCategory);
            this.Controls.Add(this.buttonAddAttendance);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewAttendance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAttendance";
            this.Load += new System.EventHandler(this.FormAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAttendance;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonAddAttendance;
        private System.Windows.Forms.ComboBox comboBoxSelectCategory;
    }
}