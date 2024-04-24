using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWF.Models
{
    public class BmpPlayer
    {
        public Bitmap bmp;
        public int x { get; set; } = 50;
        public int y { get; set; } = 50;
        public int offset { get; set; } = 5;

        public BmpPlayer(Image img, Size size)
        {
            bmp = new Bitmap(img, size);
            bmp.MakeTransparent(bmp.GetPixel(1, 1));
        }

    }
}
