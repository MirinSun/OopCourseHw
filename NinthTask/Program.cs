using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinthTask
{
    class Player
    {
        private Health _health;
        private Vector2 _position;

        public Player(float health, int x, int y, Map map)
        {
            _health = new Health(health);
            _position = new Vector2(x, y);
            Map = map;
        }

        public Map Map { get; private set; }

        public void Update()
        {
            if (_position.X < Map.Width)
            {
                _position.X++;
                if (Map.GetCell(_position.X, _position.Y) == '#')
                {
                    _health.ApplyDamage(10);
                }
            }
        }
    }

    class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Health
    {
        public float Value { get; private set; }

        public Health(float value)
        {
            Value = value;
        }

        public bool IsAlive
        {
            get
            {
                return Value > 0;
            }
        }

        public void ApplyDamage(float damage)
        {
            Value -= damage;
        }
    }

    class Map
    {
        private char[,] _cells;

        public char GetCell(int x, int y)
        {
            return _cells[x, y];
        }

        public int Width
        {
            get
            {
                return _cells.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return _cells.GetLength(1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


}
