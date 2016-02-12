using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1
{
    public static class Extensions
    {
        public static double DistTo(this Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.X, 2));
        }

        public static int Ceil(this double d)
        {
            return (int) Math.Ceiling(d);
        }
    }
}
