namespace QRCodeDemo
{
    partial class FormWorker
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
            this.comboBoxSelectCategory = new System.Windows.Forms.ComboBox();
            this.buttonAddWorkers = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewAttendance = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).BeginInit();
            this.SuspendLayout();
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
            this.comboBoxSelectCategory.Location = new System.Drawing.Point(201, 13);
            this.comboBoxSelectCategory.Name = "comboBoxSelectCategory";
            this.comboBoxSelectCategory.Size = new System.Drawing.Size(196, 28);
            this.comboBoxSelectCategory.TabIndex = 17;
            this.comboBoxSelectCategory.Text = "(Selection)";
            // 
            // buttonAddWorkers
            // 
            this.buttonAddWorkers.BackColor = System.Drawing.Color.LightBlue;
            this.buttonAddWorkers.FlatAppearance.BorderSize = 0;
            this.buttonAddWorkers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddWorkers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddWorkers.Location = new System.Drawing.Point(403, 316);
            this.buttonAddWorkers.Name = "buttonAddWorkers";
            this.buttonAddWorkers.Size = new System.Drawing.Size(243, 44);
            this.buttonAddWorkers.TabIndex = 16;
            this.buttonAddWorkers.Text = "Add Worker";
            this.buttonAddWorkers.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(403, 13);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(243, 26);
            this.textBoxSearch.TabIndex = 15;
            // 
            // dataGridViewAttendance
            // 
            this.dataGridViewAttendance.AllowUserToAddRows = false;
            this.dataGridViewAttendance.AllowUserToDeleteRows = false;
            this.dataGridViewAttendance.AllowUserToResizeColumns = false;
            this.dataGridViewAttendance.AllowUserToResizeRows = false;
            this.dataGridViewAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttendance.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewAttendance.Name = "dataGridViewAttendance";
            this.dataGridViewAttendance.ReadOnly = true;
            this.dataGridViewAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAttendance.Size = new System.Drawing.Size(634, 229);
            this.dataGridViewAttendance.TabIndex = 14;
            // 
            // FormWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 374);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxSelectCategory);
            this.Controls.Add(this.buttonAddWorkers);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewAttendance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWorker";
            this.Text = "FormWorker";
            this.Load += new System.EventHandler(this.FormWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelectCategory;
        private System.Windows.Forms.Button buttonAddWorkers;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewAttendance;

    }
}