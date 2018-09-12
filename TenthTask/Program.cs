using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthTask
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
    class Vector2
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2 operator -(Vector2 a, int num)
        {
            return new Vector2(a.X - num, a.Y - num);
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2 operator +(Vector2 a, int num)
        {
            return new Vector2(a.X + num, a.Y + num);
        }
        public static Vector2 operator +(int num, Vector2 b)
        {
            return new Vector2(num + b.X, num + b.Y);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }
        public static Vector2 operator *(Vector2 a, int num)
        {
            return new Vector2(a.X * num, a.Y * num);
        }
        public static Vector2 operator *(int num, Vector2 b)
        {
            return new Vector2(num * b.X, num * b.Y);
        }
    }
}
