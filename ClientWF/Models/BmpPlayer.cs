using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClientWF.Models
{
    public class BmpPlayer
    {
        public Bitmap bmp { get; set; }
        public int x { get; private set; } = 50;
        public int y { get; private set; } = 50;
        public int offset { get; private set; } = 5;

        public BmpPlayer(Image img, Size size)
        {
            bmp = new Bitmap(img, size);
            bmp.MakeTransparent(bmp.GetPixel(1, 1));           
        }

        public void movePayer(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) { y += offset; }
            else if (e.KeyCode == Keys.Up) { y -= offset; }
            else if (e.KeyCode == Keys.Right) { x += offset; }
            else if (e.KeyCode == Keys.Left) { x -= offset; }
        }
    }
}
