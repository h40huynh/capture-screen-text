using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_Screen_Text
{
    public interface IMain
    {
        Image SnipImage { get; set; }
        string TextFromImage { get; set; }
    }
}
