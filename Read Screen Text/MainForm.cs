using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Read_Screen_Text
{
    public partial class MainForm : Form, IMain
    {
        Presenter presenter;
        public MainForm()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        public Image SnipImage { get => pbImageCapture.Image; set => pbImageCapture.Image = value; }
        public string TextFromImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            using (SnippingForm form = new SnippingForm())
            {
                this.Hide();
                if(form.ShowDialog() == DialogResult.OK)
                {
                    Rectangle bound = form.BoundRectangle;
                    presenter.GetScreenShot(bound);

                    pbImageCapture.Width = bound.Width;
                    pbImageCapture.Height = bound.Height;
                    this.Width = bound.Width + 40;
                    this.Height = bound.Height + 100;
                }
                this.Show();
            }
        }
    }
}
