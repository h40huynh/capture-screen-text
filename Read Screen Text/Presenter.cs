using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IronOcr;

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

            Thread readThread = new Thread(() =>
            {
                var Orc = new AutoOcr();
                view.TextFromImage = Orc.Read(view.SnipImage).Text;
            });
            readThread.Start();
        }


    }
}
