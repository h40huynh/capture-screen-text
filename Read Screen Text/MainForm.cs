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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            using (SnippingForm form = new SnippingForm())
            {
                this.Hide();
                if(form.ShowDialog() == DialogResult.OK)
                {
                    //
                }
                this.Show();
            }
        }
    }
}
