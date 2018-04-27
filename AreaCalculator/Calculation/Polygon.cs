using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Calculation
{
    public class Polygon : Shape
    {
        public List<Point> Points { get; }

        public Polygon(List<Point> points)
        {
            if (points.Count < 3)
                throw new Exception("Пожалуйста задайте больше двух точек!");
            Points = points;
        }

        public override double GetArea()
        {
            return Math.Abs(Points.Take(Points.Count - 1)
                                .Select((p, i) => (Points[i + 1].X - p.X) * (Points[i + 1].Y + p.Y))
                                .Sum() / 2.0);
        }
    }
}
