using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRCodeDemo
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            MemoryStream mem = new MemoryStream(Class.Picture);
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
