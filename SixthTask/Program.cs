using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixthTask
{
    class Stack
    {
        private int[] _data;
        private int _indexOfTop;
        public Stack()
        {
            _data = new int[1];
            _indexOfTop = -1;
        }
        public bool IsEmpty()
        {
            return _indexOfTop == -1;
        }
        public void Push(int data)
        {
            if (IsFull())
                Resize();
         
            _data[++_indexOfTop] = data;
        }
        public int Pop()
        {
            int cData = Peek();
            _data[_indexOfTop--] = 0;

            return cData;
        }
        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _data[_indexOfTop];
        }
        private void Resize()
        {
            var old = _data;
            _data = new int[_data.Length * 2];
            Array.Copy(old, _data, old.Length);
        }
        private bool IsFull()
        {
            return _indexOfTop == _data.Length - 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack pancakes = new Stack();
            Random r = new Random();

            while (true)
            {
                Console.WriteLine("Что вы хотите?");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Скушать":
                        if (!pancakes.IsEmpty())
                        {
                            Console.WriteLine($"В блинчике {pancakes.Pop()} каллорий");
                        }
                        else
                        {
                            Console.WriteLine($"Сначала надо испечь блинчик!");
                        }
                        break;
                    case "Испечь":
                        pancakes.Push(r.Next(1, 20));
                        Console.WriteLine($"Вы испекли блинчик с {pancakes.Peek()} каллориями");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
