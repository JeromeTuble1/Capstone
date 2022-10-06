using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRCodeDemo
{
    public partial class FormRegister : Form
    {
        SqlConnection tublecon = new SqlConnection(Class.tublecon);
        MemoryStream ms;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            CreateNewID();
        }

        void CreateNewID() {
            textBoxEmployeeID.Text = "";
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLogin", tublecon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (Convert.ToInt16(dt.Rows[0][0]).Equals(0))
            {
                Class.EmployeeID = "1";
            }
            else
            {
                Class.EmployeeID = (Convert.ToInt16(dt.Rows[0][0]) + 1).ToString();
            }
            if (Convert.ToInt16(Class.EmployeeID) < 10)
            {
                Class.EmployeeID = "000" + Class.EmployeeID;
            }
            else if (Convert.ToInt16(Class.EmployeeID) < 100)
            {
                Class.EmployeeID = "00" + Class.EmployeeID;
            }
            else if (Convert.ToInt16(Class.EmployeeID) < 1000)
            {
                Class.EmployeeID = "0" + Class.EmployeeID;
            }
            textBoxEmployeeID.Text = DateTime.Now.Year + "-" + Class.EmployeeID + "-DJAAS";
        }

        void UserNameSearchPair() {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLogin WHERE FName = @FName AND LName = @LName AND MName = @MName", tublecon);
            cmd.Parameters.AddWithValue("@LName", textBoxLName.Text);
            cmd.Parameters.AddWithValue("@MName", textBoxMName.Text);
            cmd.Parameters.AddWithValue("@FName", textBoxFName.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Class.UserSearchPair = dt.Rows[0][0].ToString();
        }

        void PasswordSearchPair() {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLogin WHERE Password = @Password", tublecon);
            cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Class.PasswordSearchPair = dt.Rows[0][0].ToString();
        }

        void Register() {
            //byte[] photo = GetPhoto(photoFilePath); 
            if (radioButtonMale.Checked.Equals(true) || radioButtonFemale.Checked.Equals(true))
            {
                if (textBoxConfirmPassword.Text != string.Empty || textBoxPassword.Text != string.Empty || textBoxFName.Text != string.Empty || textBoxLName.Text != string.Empty || textBoxMName.Text != string.Empty)
                {
                    if (textBoxPassword.Text.Equals(textBoxConfirmPassword.Text))
                    {
                        if (Convert.ToInt16(Class.UserSearchPair) > 0)
                        {
                            MessageBox.Show("FullName Already exist please try another ");
                        }
                        if (Convert.ToInt16(Class.PasswordSearchPair) > 0)
                        {
                            MessageBox.Show("Password Already exist please try another ");
                        }
                        if (Convert.ToInt16(Class.UserSearchPair).Equals(0) && Convert.ToInt16(Class.PasswordSearchPair).Equals(0))
                        {
                            tublecon.Open();
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO tblLogin (EmployeeID, UserName, FName, LName, MName, Password, Gender, Birthdate, Address, DateCreated, ContactNumber, EmergencyContact, Picture)VALUES(@EmployeeID, @UserName, @FName, @LName, @MName, @Password, @Gender, @Birthdate, @Address, @DateCreated, @ContactNumber, @EmergencyContact, @Picture)", tublecon);
                            cmd1.Parameters.AddWithValue("@EmployeeID", textBoxEmployeeID.Text);
                            cmd1.Parameters.AddWithValue("@UserName", textBoxUserName.Text);
                            cmd1.Parameters.AddWithValue("@LName", textBoxLName.Text);
                            cmd1.Parameters.AddWithValue("@FName", textBoxFName.Text);
                            cmd1.Parameters.AddWithValue("@MName", textBoxMName.Text);
                            cmd1.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                            cmd1.Parameters.AddWithValue("@Gender", Class.Gender);

                            //############################################################

                            cmd1.Parameters.AddWithValue("@Birthdate", dateTimePickerBirthDate.Value.ToString());

                            //############################################################

                            cmd1.Parameters.AddWithValue("@Address", textBoxAddress.Text);

                            //############################################################


                            cmd1.Parameters.AddWithValue("@DateCreated", DateTime.Today.Date.ToShortDateString());

                            //############################################################

                            cmd1.Parameters.AddWithValue("@ContactNumber", Class.contfirstandfirsttuble[0] + Class.contsecondthirdtuble[0] + Class.contsecondthirdtuble[1]);

                            //############################################################

                            cmd1.Parameters.AddWithValue("@EmergencyContact", Class.emerfirstandfirsttuble[0] + Class.emersecondthirdtuble[0] + Class.emersecondthirdtuble[1]);

                            //############################################################

                            ms = new MemoryStream();
                            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                            byte[] photo_array = new byte[ms.Length];
                            ms.Position = 0;
                            ms.Read(photo_array, 0, photo_array.Length);

                            cmd1.Parameters.AddWithValue("@Picture", photo_array);
                            cmd1.ExecuteNonQuery();

                            Class.GenerateQRCode = textBoxEmployeeID.Text;
                            Class.GenerateRegister = true;

                            FormGenerateQRCode fgqrcode = new FormGenerateQRCode();
                            fgqrcode.ShowDialog();
                            Class.GenerateRegister = false;

                            //############################################################

                            MessageBox.Show("Your Account is created . Please login now.");
                            FormLogin FL = new FormLogin();
                            this.Hide();
                            FL.ShowDialog();
                            tublecon.Close();
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
            else
            {
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

        void FileUpload() 
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

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            SplitContacts();
            Register();
        }

        private void buttonFileUpload_Click(object sender, EventArgs e)
        {
            FileUpload();
        }

        void SplitContacts()
        {
            //Contact Number
            Class.contsplitspace = maskedTextBoxContactNum.Text;
            Class.contspittuble = Class.contsplitspace.Split(' ');
            Class.contfirsttuble = Class.contspittuble[0].Split('(');
            Class.contsecondthirdtuble = Class.contspittuble[1].Split('-');
            Class.contfirstandfirsttuble = Class.contfirsttuble[1].Split(')');

            //MessageBox.Show(Class.contfirstandfirsttuble[0] + Class.contsecondthirdtuble[0] + Class.contsecondthirdtuble[1]);

            //Emergency Contact
            Class.emersplitspace = maskedTextBoxEmergencyContact.Text;
            Class.emerspittuble = Class.emersplitspace.Split(' ');
            Class.emerfirsttuble = Class.emerspittuble[0].Split('(');
            Class.emersecondthirdtuble = Class.emerspittuble[1].Split('-');
            Class.emerfirstandfirsttuble = Class.emerfirsttuble[1].Split(')');

            //MessageBox.Show(Class.emerfirstandfirsttuble[0] + Class.emersecondthirdtuble[0] + Class.emersecondthirdtuble[1]);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormLogin FL = new FormLogin();
            this.Hide();
            FL.ShowDialog();
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            Class.Gender = "MALE";
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            Class.Gender = "FEMALE";
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked.Equals(true))
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else if (checkBoxShowPassword.Checked.Equals(false))
            {
                textBoxPassword.PasswordChar = '*';
            }
        }

        private void checkBoxShowConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowConfirmPassword.Checked.Equals(true))
            {
                textBoxConfirmPassword.PasswordChar = '\0';
            }
            else if (checkBoxShowConfirmPassword.Checked.Equals(false))
            {
                textBoxConfirmPassword.PasswordChar = '*';
            }
        }

        private void dateTimePickerBirthDate_ValueChanged(object sender, EventArgs e)
        {
            string splitdate = dateTimePickerBirthDate.Value.ToString();
            //Remove Month and Day
            string[] consplitdate = splitdate.Split('/');
            //Remove Time
            string[] getYear = consplitdate[2].Split(' ');
            //Subtract the Value
            numericUpDownAge.Value = Convert.ToInt16(DateTime.Now.Year.ToString()) - Convert.ToInt16(getYear[0]);
        }
    }
}
