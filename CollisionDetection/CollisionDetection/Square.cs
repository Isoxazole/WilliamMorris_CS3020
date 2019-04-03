using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CollisionDetection
{
    class Square
    {
        public static Vector2 Bounds { get; set; }
        public int Size { get; private set; }
        public Vector2 Position;
        public Vector2 Velocity { get; private set; }
        public Color Color { get; set; }

        public Square(int size, Vector2 spawn, Vector2 velocity)
        {
            Size = size;
            Position = spawn;
            Color = Color.Black;
            Velocity = velocity;
        }

        public void Move()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;

            if (Position.X > Bounds.X)
            {
                Position.X = Bounds.X;
                Velocity.X = -Velocity.X;
            }
            else if (Position.X < 0)
            {
                Position.X = 0;
                Velocity.X = -Velocity.X;
            }

            if (Position.Y > Bounds.Y)
            {
                Position.Y = Bounds.Y;
                Velocity.Y = -Velocity.Y;
            }
            else if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity.Y = -Velocity.Y;
            }
        }

        public bool IsCollidingWith(Square s)
        {
            if (Position.X < s.Position.X + s.Size
                && Position.X + Size > s.Position.X
                && Position.Y < s.Position.Y + s.Size
                && Position.Y + Size > s.Position.Y)
                return true;
            return false;
        }
    }
}
