using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace QRCodeDemo
{
    public partial class FormMain : Form
    {
        SqlConnection tublecon = new SqlConnection(Class.tublecon);
        Timer t;

        private Form activeForm;

        public FormMain()
        {
            InitializeComponent();

            t = new Timer();
            t.Tick += T_Tick;
            t.Interval = 1;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            LoadDateTime();
        }


        private void FormDashboard_Load(object sender, EventArgs e)
        {
            t.Start();
            labelTitle.Text = "";
            LoadDataUser();
        }

        void LoadDateTime() {
            string []tubs = new string[5];
            tubs[0] = DateTime.Today.Date.ToLongDateString();
            tubs[1] = DateTime.Now.ToLongTimeString();

            labelDateTimeShow.Text = tubs[0] + " " + tubs[1];
        }

        private void OpenChildForm(Form childForm, object btnSender) 
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        void LoadDataUser() {
            SqlCommand cmd = new SqlCommand("SELECT Picture, UserName, EmployeeID FROM tblLogin WHERE EmployeeID = @EmployeeID AND Password = @EmployeePassword", tublecon);
            cmd.Parameters.AddWithValue("@EmployeeID", Class.EmployeeID);
            cmd.Parameters.AddWithValue("@EmployeePassword", Class.EmployeePassword);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //For PictureBox
            MemoryStream mem = new MemoryStream((Byte[])(ds.Tables[0].Rows[0][0]));
            pictureBox1.Image = Image.FromStream(mem);

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 10, pictureBox1.Height - 10);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            //For View UserName
            labelUsername.Text = ds.Tables[0].Rows[0][1].ToString();
            labelUserID.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        void Logout()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    //MessageBox.Show(DateTime.Now.ToLongTimeString());
                    tublecon.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblEmployeeTemp SET LoggedOutDate = @LoggedOutDate,LoggedOutTime = @LoggedOutTime WHERE EmployeeID = @EmployeeID", tublecon);
                    cmd.Parameters.AddWithValue("@EmployeeID", Class.EmployeeID);
                    cmd.Parameters.AddWithValue("@LoggedOutDate", DateTime.Today.Date.ToShortDateString());
                    cmd.Parameters.AddWithValue("@LoggedOutTime", DateTime.Now.ToLongTimeString());
                    cmd.ExecuteNonQuery();
                    tublecon.Close();
                    //do something
                    FormLogin FL = new FormLogin();
                    this.Hide();
                    FL.ShowDialog();
                }
                catch
                {
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        void SoundHover() {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "../../Sound/338229__fachii__button-hover.wav";
            sp.Play();
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            SoundHover();
            OpenChildForm(new FormDashboard(), sender);
            labelTitle.Text = "Dashboard";
        }

        private void buttonAttendance_Click(object sender, EventArgs e)
        {
            SoundHover();
            OpenChildForm(new FormAttendance(), sender);
            labelTitle.Text = "Attendance";
        }

        private void buttonWorkers_Click(object sender, EventArgs e)
        {
            SoundHover();
            OpenChildForm(new FormWorker(), sender);
            labelTitle.Text = "Workers";
        }
    }
}
