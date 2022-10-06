using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRCodeDemo
{
    public partial class FormGenerateQRCode : Form
    {
        public FormGenerateQRCode()
        {
            InitializeComponent();
        }

        private void FormGenerateQRCode_Load(object sender, EventArgs e)
        {
            if (Class.GenerateRegister.Equals(true))
            {
                textBoxGenerate.Visible = false;
                QRCodeGenerator QG = new QRCodeGenerator();
                var TubleData = QG.CreateQrCode(Class.GenerateQRCode, QRCodeGenerator.ECCLevel.H);
                var Tublecode = new QRCode(TubleData);
                pictureBoxGenerate.Image = Tublecode.GetGraphic(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                QRCodeGenerator QG = new QRCodeGenerator();
                var TubleData = QG.CreateQrCode(textBoxGenerate.Text, QRCodeGenerator.ECCLevel.H);
                var Tublecode = new QRCode(TubleData);
                pictureBoxGenerate.Image = Tublecode.GetGraphic(50);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (Class.GenerateRegister.Equals(true))
            {
                if (Class.GenerateRegister.Equals(true))
                {
                    textBoxGenerate.Visible = true;
                }
                this.Hide();
            }
            else
            {
                this.Hide();
                FormMain fd = new FormMain();
                fd.ShowDialog();
            }
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxGenerate.Image.Save(saveFileDialog.FileName);
                }
            }

        }
    }
}
