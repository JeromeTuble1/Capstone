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
            LoadDataUser();
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
            FormLogin FL = new FormLogin();
            this.Hide();
            FL.ShowDialog();
        }
    }
}
