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
    public partial class FormWorkersAdd : Form
    {
        SqlConnection tublecon = new SqlConnection(Class.tublecon);
        MemoryStream tubleMS;

        public FormWorkersAdd()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormAttendance FA = new FormAttendance();
            this.Hide();
            FA.ShowDialog();
        }

        private void buttonAddWorkers_Click(object sender, EventArgs e)
        {

        }

        private void FormAddWorkers_Load(object sender, EventArgs e)
        {
            CreateNewID();
            
            Date2();
            Year();
        }

        void Date2() {
           textBoxHireDate.Text = DateTime.Now.ToShortDateString();
        }

        void Year() 
        {
            for (int i = DateTime.Now.Year - 100; i <= DateTime.Now.Year; i++)
            {
                comboBoxMatricYearPassed.Items.Add(i);
                comboBoxYearHire.Items.Add(i);
                comboBoxIntermediateYearPassed.Items.Add(i);
                comboBoxGraduationYearPassed.Items.Add(i);
                comboBoxMasterYearPassed.Items.Add(i);
            }
        }

        void CreateNewID()
        {
            try
            {
                            string Workers = "";
            textBoxWorkerID.Text = "";
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWorkersBioData", tublecon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (Convert.ToInt16(dt.Rows[0][0]).Equals(0))
            {
                Workers = "1";
            }
            else
            {
                Workers = (Convert.ToInt16(dt.Rows[0][0]) + 1).ToString();
            }
            if (Convert.ToInt16(Workers) < 10)
            {
                Workers = "000" + Workers;
            }
            else if (Convert.ToInt16(Workers) < 100)
            {
                Workers = "00" + Workers;
            }
            else if (Convert.ToInt16(Workers) < 1000)
            {
                Workers = "0" + Workers;
            }
            textBoxWorkerID.Text = DateTime.Now.Year + "-" + Workers + "-Worker-DJAAS";
            }
            catch
            {
                MessageBox.Show("no internet");
            }
        }

        void AddWorker()
        {
            int SuccessBioData = 0, SuccessWorkExp = 0, SuccessErrorEduQual = 0;

            if (Class.AddWorkersCollectionError.Equals(0))
            {
                try
                {
                    try
                    {
                        if (SuccessBioData.Equals(0))
                        {
                            //Worker Biodata
                            tublecon.Open();
                            SqlCommand TubleBioData = new SqlCommand("INSERT INTO tblWorkersBioData (WorkersID, FName ,LName ,MName ,BirthDate ,HireDate ,FatherName ,MotherName ,MaritalStatus ,Religion ,NumberOfChildren ,Address ,ContactNumber ,EmergencyContact ,Picture) VALUES (@WorkersID ,@FName ,@LName ,@MName ,@BirthDate ,@HireDate ,@FatherName ,@MotherName ,@MaritalStatus ,@Religion ,@NumberOfChildren ,@Address ,@ContactNumber ,@EmergencyContact ,@Picture)", tublecon);
                            TubleBioData.Parameters.AddWithValue("@WorkersID", textBoxWorkerID.Text);
                            TubleBioData.Parameters.AddWithValue("@FName", textBoxFName.Text);
                            TubleBioData.Parameters.AddWithValue("@LName", textBoxLName.Text);
                            TubleBioData.Parameters.AddWithValue("@MName", textBoxMName.Text);
                            TubleBioData.Parameters.AddWithValue("@BirthDate", dateTimePickerbirthdate.Text);
                            TubleBioData.Parameters.AddWithValue("@HireDate", DateTime.Now.ToShortDateString());
                            TubleBioData.Parameters.AddWithValue("@FatherName", textBoxFatherLName.Text + " " + textBoxFatherFName.Text + " " + textBoxFatherMName.Text);
                            TubleBioData.Parameters.AddWithValue("@MotherName", textBoxMotherLName.Text + " " + textBoxMotherFName.Text + " " + textBoxMotherMName.Text);
                            TubleBioData.Parameters.AddWithValue("@MaritalStatus", Convert.ToString(comboBoxMartialStatus.SelectedItem));
                            TubleBioData.Parameters.AddWithValue("@Religion", Convert.ToString(comboBoxReligion.SelectedItem));
                            TubleBioData.Parameters.AddWithValue("@NumberOfChildren", numericUpDownNumofChil.Value);
                            TubleBioData.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                            TubleBioData.Parameters.AddWithValue("@ContactNumber", Class.contfirstandfirsttuble[0] + Class.contsecondthirdtuble[0] + Class.contsecondthirdtuble[1]);
                            TubleBioData.Parameters.AddWithValue("@EmergencyContact", Class.emerfirstandfirsttuble[0] + Class.emersecondthirdtuble[0] + Class.emersecondthirdtuble[1]);

                            tubleMS = new MemoryStream();
                            pictureBox1.Image.Save(tubleMS, ImageFormat.Jpeg);
                            byte[] photo_array = new byte[tubleMS.Length];
                            tubleMS.Position = 0;
                            tubleMS.Read(photo_array, 0, photo_array.Length);

                            TubleBioData.Parameters.AddWithValue("@Picture", photo_array);
                            TubleBioData.ExecuteNonQuery();

                            tublecon.Close();

                            panelBioData.Enabled = false;
                            panelImage.Enabled = false;
                            SuccessBioData++;
                            //END Biodata
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error in Worker Biodata");
                    }

                    try
                    {
                        if (SuccessWorkExp.Equals(0))
                        {
                            //Working Experience
                            tublecon.Open();
                            SqlCommand TubleWorkingExp = new SqlCommand("INSERT INTO tblWorkingExperience (WorkersID, NameOfCompany, Position, YearHire, Reference) VALUES (@WorkersID, @NameOfCompany, @Position, @YearHire, @Reference)", tublecon);
                            TubleWorkingExp.Parameters.AddWithValue("@WorkersID", textBoxWorkerID.Text);
                            TubleWorkingExp.Parameters.AddWithValue("@NameOfCompany", textBoxNameOfCompany.Text);
                            TubleWorkingExp.Parameters.AddWithValue("@Position", textBoxPosition.Text);
                            TubleWorkingExp.Parameters.AddWithValue("@YearHire", Convert.ToString(comboBoxYearHire.SelectedItem));
                            TubleWorkingExp.Parameters.AddWithValue("@Reference", textBoxReference.Text);
                            TubleWorkingExp.ExecuteNonQuery();
                            tublecon.Close();

                            panelWorkingExperience.Enabled = false;
                            SuccessWorkExp++;
                            //END WorkingExperience
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error in Working Experience");
                    }

                    try
                    {
                        if (SuccessErrorEduQual.Equals(0))
                        {
                            //Educational Qualification
                            tublecon.Open();
                            SqlCommand TubleEducationalQual = new SqlCommand("INSERT INTO tblEducationalQualification (WorkersID, Matric, YearMatric, GradeMatric, Intermediate, YearIntermediate, GradeIntermediate, Graduation, YearGraduation, GradeGraduation, Masters, YearMasters, GradeMasters) VALUES (@WorkersID, @Matric, @YearMatric, @GradeMatric, @Intermediate, @YearIntermediate, @GradeIntermediate, @Graduation, @YearGraduation, @GradeGraduation, @Masters, @YearMasters, @GradeMasters)", tublecon);
                            TubleEducationalQual.Parameters.AddWithValue("@WorkersID", textBoxWorkerID.Text);
                            TubleEducationalQual.Parameters.AddWithValue("@Matric", textBoxMatricName.Text);
                            TubleEducationalQual.Parameters.AddWithValue("@YearMatric", Convert.ToString(comboBoxMatricYearPassed.SelectedItem));
                            TubleEducationalQual.Parameters.AddWithValue("@GradeMatric", numericUpDownMatricGrade.Value.ToString());
                            TubleEducationalQual.Parameters.AddWithValue("@Intermediate", textBoxIntermediateName.Text);
                            TubleEducationalQual.Parameters.AddWithValue("@YearIntermediate", Convert.ToString(comboBoxIntermediateYearPassed.SelectedItem));
                            TubleEducationalQual.Parameters.AddWithValue("@GradeIntermediate", numericUpDownIntermediateGrade.Value.ToString());
                            TubleEducationalQual.Parameters.AddWithValue("@Graduation", textBoxGraduationName.Text);
                            TubleEducationalQual.Parameters.AddWithValue("@YearGraduation", Convert.ToString(comboBoxGraduationYearPassed.SelectedItem));
                            TubleEducationalQual.Parameters.AddWithValue("@GradeGraduation", numericUpDownGraduationGrade.Value.ToString());
                            TubleEducationalQual.Parameters.AddWithValue("@Masters", textBoxMasterName.Text);
                            TubleEducationalQual.Parameters.AddWithValue("@YearMasters", Convert.ToString(comboBoxMasterYearPassed.SelectedItem));
                            TubleEducationalQual.Parameters.AddWithValue("@GradeMasters", numericUpDownMasterGrade.Value.ToString());
                            TubleEducationalQual.ExecuteNonQuery();
                            tublecon.Close();

                            panelEducationalQualification.Enabled = false;
                            SuccessErrorEduQual++;
                            //END Educational Qualification
                        }
                        if (SuccessBioData != 0 && SuccessWorkExp != 0 && SuccessErrorEduQual != 0)
                        {
                            this.Hide();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error in Educational Qualification");
                    }
                }
                catch
                {
                    MessageBox.Show("no network");
                }
            }
            else 
            {
                MessageBox.Show(Class.AddWorkerCollectionStatusError);
            }
        }

        void DebuggingTubs () 
        {
            Class.AddWorkersCollectionError = 0;
            Class.AddWorkerCollectionStatusError = "";
            //Debug WorkerName
            if (textBoxFName.Text.Equals("") || textBoxLName.Text.Equals("") || textBoxMName.Text.Equals(""))
            {
                Class.AddWorkerCollectionStatusError = "Worker Name does not required to be empty";
                Class.AddWorkersCollectionError++;
            }
            //Debug Birth Date
            string splitdate = dateTimePickerbirthdate.Value.ToString();
                //Remove Month and Day
            string[] consplitdate = splitdate.Split('/');
                //Remove Time
            string[] getYear = consplitdate[2].Split(' ');
                //Subtract the Value
            int age = Convert.ToInt16(DateTime.Now.Year.ToString()) - Convert.ToInt16(getYear[0]);

            if (age < 18) { Class.AddWorkerCollectionStatusError += "\nCan't accept your age below 17"; Class.AddWorkersCollectionError++; }
            //Debug MartialStatus
            if (Convert.ToString(comboBoxMartialStatus.SelectedItem).Equals("(Selection)"))
            {
                Convert.ToString(comboBoxMartialStatus.SelectedItem);
                Class.AddWorkerCollectionStatusError += "\nSelect item in maritial status";
                Class.AddWorkersCollectionError++;
            }
            //Debug Religion
            if (Convert.ToString(comboBoxReligion.SelectedItem).Equals("(Selection)"))
            {
                Convert.ToString(comboBoxReligion.SelectedItem);
                Class.AddWorkerCollectionStatusError += "\nSelect item in religion";
                Class.AddWorkersCollectionError++;
            }

            if (textBoxFatherLName.Text.Equals("") || textBoxFatherFName.Text.Equals(""))
            {
                Class.AddWorkerCollectionStatusError += "\nFill the Father's Full Name";
                Class.AddWorkersCollectionError++;
            }

            if (textBoxMotherLName.Text.Equals("") || textBoxMotherFName.Text.Equals(""))
            {
                Class.AddWorkerCollectionStatusError += "\nFill the Mother's Full Name";
                Class.AddWorkersCollectionError++;
            }

            if (textBoxAddress.Text.Equals("")) 
            {
                Class.AddWorkerCollectionStatusError += "\nFill the Full Address";
                Class.AddWorkersCollectionError++;
            }
        }

        void SplitContacts() {
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
                if (openFileDialog1.ShowDialog().Equals(System.Windows.Forms.DialogResult.OK))
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            DebuggingTubs();
            SplitContacts();
            AddWorker();
        }

        private void comboBoxReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxMartialStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMartialStatus.SelectedItem.Equals("Single"))
            {
                numericUpDownNumofChil.ReadOnly = true;
                numericUpDownNumofChil.Value = 0;
            }
            else {
                numericUpDownNumofChil.ReadOnly = false;
            }
        }
    }
}
