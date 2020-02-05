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
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private Image snipImage;

        private string textFromImage;
        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnCapture.Enabled = false;
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
                            pbImageCapture.Image = snipImage;
                        }
                    }

                    pbImageCapture.Width = bound.Width;
                    pbImageCapture.Height = bound.Height;
                    this.Width = Math.Max(bound.Width + 40, 600);
                    this.Height = bound.Height + 300;

                    bwExtractText.RunWorkerAsync();
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
            progressMain.Value = e.ProgressPercentage;
            lblProgress.Text = $"Loading {e.ProgressPercentage}% ...";

            if(e.ProgressPercentage == 90)
            {
                rtTextFromImage.Text = textFromImage;
            }
        }

        private void bwExtractText_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Text = "Completed";
            btnCapture.Enabled = true;
        }
    }
}
