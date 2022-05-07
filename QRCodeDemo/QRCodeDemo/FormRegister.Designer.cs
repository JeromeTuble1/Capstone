namespace QRCodeDemo
{
    partial class FormRegister
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
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonVisitor = new System.Windows.Forms.RadioButton();
            this.radioButtonEmployee = new System.Windows.Forms.RadioButton();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonFileUpload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownAge = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.LightBlue;
            this.buttonRegister.FlatAppearance.BorderSize = 0;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.ForeColor = System.Drawing.Color.Black;
            this.buttonRegister.Location = new System.Drawing.Point(413, 510);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(135, 41);
            this.buttonRegister.TabIndex = 0;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(141, 347);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(154, 20);
            this.textBoxConfirmPassword.TabIndex = 1;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(141, 295);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(154, 20);
            this.textBoxUserName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(141, 321);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(154, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirm Password";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightBlue;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.ForeColor = System.Drawing.Color.Black;
            this.buttonBack.Location = new System.Drawing.Point(30, 510);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 41);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "<< Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonFemale);
            this.groupBox1.Controls.Add(this.radioButtonMale);
            this.groupBox1.Location = new System.Drawing.Point(582, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 66);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gender";
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(114, 29);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFemale.TabIndex = 10;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            this.radioButtonFemale.CheckedChanged += new System.EventHandler(this.radioButtonFemale_CheckedChanged);
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Location = new System.Drawing.Point(23, 29);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMale.TabIndex = 9;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.CheckedChanged += new System.EventHandler(this.radioButtonMale_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(-46, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 100);
            this.panel1.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(351, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(337, 46);
            this.label7.TabIndex = 19;
            this.label7.Text = "Registration Form";
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Location = new System.Drawing.Point(6, 19);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(73, 21);
            this.comboBoxDay.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxYear);
            this.groupBox2.Controls.Add(this.comboBoxMonth);
            this.groupBox2.Controls.Add(this.comboBoxDay);
            this.groupBox2.Location = new System.Drawing.Point(59, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 66);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Birthdate";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(164, 19);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(73, 21);
            this.comboBoxYear.TabIndex = 12;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(85, 19);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(73, 21);
            this.comboBoxMonth.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonVisitor);
            this.groupBox3.Controls.Add(this.radioButtonEmployee);
            this.groupBox3.Location = new System.Drawing.Point(582, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 66);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mode";
            // 
            // radioButtonVisitor
            // 
            this.radioButtonVisitor.AutoSize = true;
            this.radioButtonVisitor.Location = new System.Drawing.Point(114, 29);
            this.radioButtonVisitor.Name = "radioButtonVisitor";
            this.radioButtonVisitor.Size = new System.Drawing.Size(53, 17);
            this.radioButtonVisitor.TabIndex = 10;
            this.radioButtonVisitor.TabStop = true;
            this.radioButtonVisitor.Text = "Visitor";
            this.radioButtonVisitor.UseVisualStyleBackColor = true;
            this.radioButtonVisitor.CheckedChanged += new System.EventHandler(this.radioButtonVisitor_CheckedChanged);
            // 
            // radioButtonEmployee
            // 
            this.radioButtonEmployee.AutoSize = true;
            this.radioButtonEmployee.Location = new System.Drawing.Point(23, 29);
            this.radioButtonEmployee.Name = "radioButtonEmployee";
            this.radioButtonEmployee.Size = new System.Drawing.Size(71, 17);
            this.radioButtonEmployee.TabIndex = 9;
            this.radioButtonEmployee.TabStop = true;
            this.radioButtonEmployee.Text = "Employee";
            this.radioButtonEmployee.UseVisualStyleBackColor = true;
            this.radioButtonEmployee.CheckedChanged += new System.EventHandler(this.radioButtonEmployee_CheckedChanged);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(582, 432);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(276, 20);
            this.textBoxAddress.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Address";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(413, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 101);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // buttonFileUpload
            // 
            this.buttonFileUpload.BackColor = System.Drawing.Color.LightBlue;
            this.buttonFileUpload.FlatAppearance.BorderSize = 0;
            this.buttonFileUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFileUpload.ForeColor = System.Drawing.Color.Black;
            this.buttonFileUpload.Location = new System.Drawing.Point(436, 225);
            this.buttonFileUpload.Name = "buttonFileUpload";
            this.buttonFileUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonFileUpload.TabIndex = 16;
            this.buttonFileUpload.Text = "Upload";
            this.buttonFileUpload.UseVisualStyleBackColor = false;
            this.buttonFileUpload.Click += new System.EventHandler(this.buttonFileUpload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "User ID";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Enabled = false;
            this.textBoxUserID.Location = new System.Drawing.Point(141, 269);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(154, 20);
            this.textBoxUserID.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Age";
            // 
            // numericUpDownAge
            // 
            this.numericUpDownAge.Location = new System.Drawing.Point(141, 445);
            this.numericUpDownAge.Name = "numericUpDownAge";
            this.numericUpDownAge.Size = new System.Drawing.Size(154, 20);
            this.numericUpDownAge.TabIndex = 20;
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 577);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDownAge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.buttonFileUpload);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.buttonRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonVisitor;
        private System.Windows.Forms.RadioButton radioButtonEmployee;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonFileUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownAge;
        private System.Windows.Forms.Label label7;
    }
}