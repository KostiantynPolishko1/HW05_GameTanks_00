using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWF.Models
{
    public class RectPlayer
    {
        public Bitmap bmp { get; set; }
        public Rectangle rect { get; set; }
        public Size size { get; set; }
        public int x { get; set; } = 175;
        public int y { get; set; } = 175;
        public int offset { get; private set; } = 5;

        public RectPlayer(Image img, Size size) 
        {
            this.size = size;
            bmp = new Bitmap(img, this.size);
            //rect = new Rectangle(new Point(x, y), this.size);
            bmp.MakeTransparent(bmp.GetPixel(1, 1));
        }

        public void setRectPoint(int x, int y)
        {
            rect = new Rectangle(new Point(x, y), size);
        }
    }
}
