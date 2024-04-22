using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpLibrary.Models
{
    public class Player
    {
        public Point ptn { get; set; }
        public Color color { get; set; }

        public Player() 
        { 
            ptn = new Point(10, 20);
            color = Color.Green;
        }
    }
}
