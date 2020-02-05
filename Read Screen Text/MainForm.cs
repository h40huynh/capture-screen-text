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
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public Image SnipImage { get => pbImageCapture.Image; set => pbImageCapture.Image = value; }
        public string TextFromImage
        {
            get => rtTextFromImage.Text;
            set
            {
                rtTextFromImage.Clear();
                rtTextFromImage.AppendText(value);
            }
        }

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
                            SnipImage = image.Clone() as Image;
                        }
                    }

                    pbImageCapture.Width = bound.Width;
                    pbImageCapture.Height = bound.Height;
                    this.Width = Math.Max(bound.Width + 40, 600);
                    this.Height = bound.Height + 200;

                    var ReadTextThread = new Thread(() =>
                    {
                        var Orc = new AutoOcr();
                        var content = Orc.Read(SnipImage).Text;
                        if (string.IsNullOrWhiteSpace(content))
                            content = "Can't read anything";
                        TextFromImage = content;
                        btnCapture.Enabled = true;
                    });
                    ReadTextThread.Start();
                }
                this.Show();
            }
        }

        private void bwExtractText_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
