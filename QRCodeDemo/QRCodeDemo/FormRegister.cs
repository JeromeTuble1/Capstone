using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRCodeDemo
{
    public partial class FormRegister : Form
    {
        SqlConnection con = new SqlConnection(Class.con);

        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            Day();
            Month();
            Year();
        }

        void Day() {
            for (int i = 1; i <= 31; i++) {
                comboBoxDay.Items.Add(i);
            }
        }

        void Month() {
            for (int i = 1; i <= 12; i++) {
                comboBoxMonth.Items.Add(i);
            }
        }

        void Year() {
            for (int i = DateTime.Now.Year - 100; i <= DateTime.Now.Year; i++) {
                comboBoxYear.Items.Add(i);
            }
        }

        void Register() {
            //byte[] photo = GetPhoto(photoFilePath); 
            if (radioButtonMale.Checked == true || radioButtonFemale.Checked == true)
            {
                if (radioButtonEmployee.Checked == true || radioButtonVisitor.Checked == true)
                {
                    if (textBoxConfirmPassword.Text != string.Empty || textBoxPassword.Text != string.Empty || textBoxUserName.Text != string.Empty)
                    {
                        if (textBoxPassword.Text == textBoxConfirmPassword.Text)
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM tblLogin WHERE UserName = @Username OR Password = @Password", con);
                            cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
                            cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Username Already exist please try another ");
                            }
                            else
                            {
                                con.Close();
                                SqlCommand cmd1 = new SqlCommand();
                                cmd1.CommandText = "INSERT INTO tblLogin (UserID,UserName,Password,Gender,BirthDate,Employee,Address,Age,Image) VALUES (@UserID,@UserName,@Password,@Gender,@BirthDate,@Employee,@Address,@Age,@Image)";
                                cmd1.Parameters.AddWithValue("@UserID", Class.UserID);
                                cmd1.Parameters.AddWithValue("@UserName", textBoxUserName.Text);
                                cmd1.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                                cmd1.Parameters.AddWithValue("@Gender", Class.Gender);
                                cmd1.Parameters.AddWithValue("@BirthDate", comboBoxDay.SelectedItem.ToString() + "/" + comboBoxMonth.SelectedItem.ToString() + "/" + comboBoxYear.SelectedItem.ToString());
                                cmd1.Parameters.AddWithValue("@Employee", Class.Mode);
                                cmd1.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                                cmd1.Parameters.AddWithValue("@Age", numericUpDownAge.Value);
                                cmd1.Parameters.AddWithValue("@Image", Class.Picture);
                                cmd1.ExecuteNonQuery();

                                MessageBox.Show("Your Account is created . Please login now.");
                                FormLogin FL = new FormLogin();
                                this.Hide();
                                FL.ShowDialog();
                                con.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter both password same ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter value in all field.");
                    }
                }
                else {
                    MessageBox.Show("Please select one in Group Mode");
                }
            }
            else {
                MessageBox.Show("Please select one in Group Gender");
            }
        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
            //OR byte[] image = File.ReadAllBytes("D:\\11.jpg");
        } 

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void buttonFileUpload_Click(object sender, EventArgs e)
        {
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select image to be upload.";
            //which type image format you want to upload in database. just add them.
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        Class.Picture = GetPhoto(path);
                        pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormLogin FL = new FormLogin();
            this.Hide();
            FL.ShowDialog();
        }

        private void radioButtonEmployee_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUserID.Text = "";
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS COUNT FROM tblLogin");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if (Convert.ToInt16(dt.Rows[0][0]) < 10) {
                Class.UserID = "000" + dt.Rows[0][0].ToString();
            }
            if (Convert.ToInt16(dt.Rows[0][0]) < 100) {
                Class.UserID = "00" + dt.Rows[0][0].ToString();
            }
            if (Convert.ToInt16(dt.Rows[0][0]) < 1000) {
                Class.UserID = "0" + dt.Rows[0][0].ToString();
            }
            textBoxUserID.Text = DateTime.Now.Year + "-" + Class.UserID + "-DJAAS";
        }

        private void radioButtonVisitor_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUserID.Text = DateTime.Now.Year + "-VISITOR-DJAAS";
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            Class.Gender = "Male";
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            Class.Gender = "Female";
        }
    }
}
