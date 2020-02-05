using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Read_Screen_Text
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            lblProgress.Text = string.Empty;

            progressMain.Style = ProgressBarStyle.Continuous;
            progressMain.Value = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private Image snipImage;

        private string textFromImage;
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (btnCapture.Text == "Capture")
            {
                btnCapture.Text = "Cancel";
                SnipScreen();
                if (snipImage != null)
                {
                    progressMain.Style = ProgressBarStyle.Marquee;
                    progressMain.Value = 30;
                    bwExtractText.RunWorkerAsync();
                }
            }
            else
            {
                if (bwExtractText.IsBusy)
                    bwExtractText.CancelAsync();
                btnCapture.Text = "Capture";

                progressMain.Style = ProgressBarStyle.Continuous;
                progressMain.Value = 0;
                lblProgress.Text = "Cancel";
            }
        }

        private void SnipScreen()
        {
            using (SnippingForm form = new SnippingForm())
            {
                this.Hide();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Rectangle bound = form.BoundRectangle;

                    using (Image image = new Bitmap(bound.Width, bound.Height))
                    {
                        using (Graphics graphics = Graphics.FromImage(image))
                        {
                            graphics.CopyFromScreen(new Point(bound.Left, bound.Top), Point.Empty, bound.Size);
                            snipImage = image.Clone() as Image;
                            pbImageCapture.Image = image.Clone() as Image;
                        }
                    }

                    pbImageCapture.Width = bound.Width;
                    pbImageCapture.Height = bound.Height;
                    this.Width = Math.Max(bound.Width + 40, 600);
                    this.Height = bound.Height + 300;
                }
                this.Show();
            }
        }

        private void bwExtractText_DoWork(object sender, DoWorkEventArgs e)
        {
            bwExtractText.ReportProgress(0);
            var Orc = new AutoOcr();
            bwExtractText.ReportProgress(50);
            textFromImage = Orc.Read(snipImage).Text;
            bwExtractText.ReportProgress(90, textFromImage);
            if (string.IsNullOrWhiteSpace(textFromImage))
                textFromImage = "Can't read anything";
            bwExtractText.ReportProgress(100);
        }

        private void bwExtractText_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case 0:
                    lblProgress.Text = "Starting...";
                    break;
                case 50:
                    lblProgress.Text = "Reading text...";
                    break;
                case 90:
                    lblProgress.Text = "Updating...";
                    rtTextFromImage.Text = textFromImage;
                    break;
            }
        }

        private void bwExtractText_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Text = "Completed";
            btnCapture.Text = "Capture";

            progressMain.Style = ProgressBarStyle.Continuous;
            progressMain.Value = 0;
        }
    }
}
