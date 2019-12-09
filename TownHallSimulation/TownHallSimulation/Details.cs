using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TownHallSimulation
{
    public static class Details
    {
        private static Person p;
        public static readonly Point[] pathAB = pathAB = new Point[] { new Point(p.Location.X,p.Location.Y), new Point(736, 483) };
        //public static readonly Point[] pathAB = pathAB = new Point[] { new Point(p.Image.Size.Width, p.Image.Size.Height / 8), new Point(0, p.Image.Size.Height / 8) };
        public static readonly Point[] pathCD = pathCD = new Point[] { new Point(p.Image.Size.Width, (int)(p.Image.Size.Height / 1.5)), new Point(0, (int)(p.Image.Size.Height / 1.5)) };
    }
}
