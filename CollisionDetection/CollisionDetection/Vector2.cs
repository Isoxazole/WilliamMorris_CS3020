using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionDetection
{
    class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static double Distance(Vector2 a, Vector2 b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
    }
}
