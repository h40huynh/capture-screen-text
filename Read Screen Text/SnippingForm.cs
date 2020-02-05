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
    public partial class SnippingForm : Form
    {
        private Point _StartPosition;
        private Point _CurrentPosition;
        private bool _IsDrawing;

        public Rectangle BoundRectangle;

        public SnippingForm()
        {
            InitializeComponent();
            this.Opacity = 0.4;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Cursor = Cursors.Cross;
            this.DoubleBuffered = true;
        }

        private void SnippingForm_MouseDown(object sender, MouseEventArgs e)
        {
            _IsDrawing = true;
            _StartPosition = _CurrentPosition = e.Location;
        }

        private void SnippingForm_MouseUp(object sender, MouseEventArgs e)
        {
            if(_IsDrawing)
            {
                _IsDrawing = false;
                BoundRectangle = GetRectangle();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void SnippingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_IsDrawing)
            {
                _CurrentPosition = e.Location;
                this.Invalidate();
            }
        }

        private void SnippingForm_Paint(object sender, PaintEventArgs e)
        {
            if (_IsDrawing)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
            }
        }

        private Rectangle GetRectangle()
        {
            return new Rectangle(Math.Min(_StartPosition.X, _CurrentPosition.X), Math.Min(_StartPosition.Y, _CurrentPosition.Y), Math.Abs(_StartPosition.X - _CurrentPosition.X), Math.Abs(_StartPosition.Y - _CurrentPosition.Y));
        }
    }
}
