using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_Screen_Text
{
    public class Presenter
    {
        IMain view;
        public Presenter(IMain view)
        {
            this.view = view;
        }

        public void GetScreenShot(Rectangle bound)
        {
            using (Image image = new Bitmap(bound.Width, bound.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(bound.Left, bound.Top), Point.Empty, bound.Size);
                    view.SnipImage = image.Clone() as Image;
                }
            }
        }


    }
}
