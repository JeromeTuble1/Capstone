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
    public partial class FormDashboard : Form
    {
        SqlConnection con = new SqlConnection(Class.con);

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            //MemoryStream mem = new MemoryStream(Class.Picture);
            //pictureBox1.Image = Image.FromStream(mem);
            //LoadDataUser();
            ////////////////////////////////////

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 10, pictureBox1.Height - 10);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            //pictureBox1.ImageLocation = "f53443040.png";
        }

        void LoadDataUser() {
            SqlCommand cmd = new SqlCommand("SELECT Picture, Employee FROM tblLogin WHERE UserID = @UserID");
            cmd.Parameters.AddWithValue("@UserID", Class.UserID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MemoryStream mem = new MemoryStream((Byte[])(ds.Tables[0].Rows[0][0]));
            pictureBox1.Image = Image.FromStream(mem);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                FormLogin FL = new FormLogin();
                this.Hide();
                FL.ShowDialog();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        void SoundHover() {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "../../Sound/338229__fachii__button-hover.wav";
            sp.Play();
        }

        private void buttonHome_MouseHover(object sender, EventArgs e)
        {
            SoundHover();
        }

        private void buttonChanges_MouseHover(object sender, EventArgs e)
        {
            SoundHover();
        }

        private void buttonAdmin_MouseHover(object sender, EventArgs e)
        {
            SoundHover();
        }
    }
}
