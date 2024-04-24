using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Player
    {
        public int x;
        public int y;
        public string? color;

        public Player() { }

        public Player(int x, int y, string? color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override string ToString() => $"{x} : {y} | {color}";
    }
}
