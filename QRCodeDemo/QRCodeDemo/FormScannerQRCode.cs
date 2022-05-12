using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using BasselTech_CamCapture;

namespace QRCodeDemo
{
    public partial class FormScannerQRCode : Form
    {
        Camera cam;
        Timer t;
        BackgroundWorker worker;
        Bitmap CapImage;

        public FormScannerQRCode()
        {
            InitializeComponent();

            t = new Timer();
            cam = new Camera(pictureBoxWebCam);
            worker = new BackgroundWorker();

            worker.DoWork += worker_Dowork;
            t.Tick += T_Tick;
            t.Interval = 1;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            CapImage = cam.GetBitmap();
            if (CapImage != null && !worker.IsBusy) {
                worker.RunWorkerAsync();
            }
        }

        private void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            string DecodeValue;
            QRCodeDecoder DeCoder = new QRCodeDecoder();

            try
            {
                MessageBox.Show(DeCoder.decode(new QRCodeBitmapImage(CapImage)));
                DecodeValue = DeCoder.decode(new QRCodeBitmapImage(CapImage));

            }
            catch { }
        }

        private void FormScannerQRCode_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                cam.Start();
                t.Start();
                buttonStop.Enabled = true;
                buttonStart.Enabled = false;

            }
            catch
            {
                cam.Stop();
                MessageBox.Show("");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            cam.Stop();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }
    }
}
