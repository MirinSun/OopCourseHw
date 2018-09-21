using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Painter painter = new Painter(new Bitmap(100, 100));
            Pen pen = new Pen(Color.White);
            Figure curve = new Сurve(pen, new Point(new Pen(Color.Red), 10, 10),
                new Point(pen, 50, 10),
                new Point(pen, 50, 50),
                new Point(pen, 10, 50),
                new Point(pen, 10, 10));

            painter.Draw(curve);

            painter.SavePicture("canvas.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }


    class Painter
    {
        private Bitmap _canvas;
        public Painter(Bitmap canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException();
        }

        public void Draw(Figure figure)
        {
            if (figure == null)
                throw new ArgumentNullException();

            figure.Draw(_canvas);
        }

        public void SavePicture(string pathOfFile, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            _canvas.Save(pathOfFile, imageFormat);
        }
    }
    abstract class Figure
    {
        public Pen Pen { get; private set; }

        public Figure(Pen pen)
        {
            Pen = pen ?? throw new ArgumentNullException();
        }
        public abstract void Draw(Bitmap canavas);
    }
    class Point : Figure
    {
        public Point(Pen pen, int x, int y) : base(pen)
        {
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }

        public override void Draw(Bitmap canavas)
        {
            Graphics
                .FromImage(canavas)
                .DrawRectangle(Pen, new Rectangle(X, Y, 1, 1));
        }
    }
    class Сurve : Figure
    {
        private Point[] _points;
        public Сurve(Pen pen, params Point[] points) : base(pen)
        {
            if (points == null || points.Length < 2)
                throw new ArgumentException();

            _points = points;
        }

        public override void Draw(Bitmap canavas)
        {
            for (int i = 0; i < _points.Length - 1; i++)
            {
                _points[i].Draw(canavas);

                Graphics
                    .FromImage(canavas)
                    .DrawLine(Pen, _points[i].X, _points[i].Y, _points[i + 1].X, _points[i + 1].Y);
            }

            _points[_points.Length - 1].Draw(canavas);
        }
    }
}
