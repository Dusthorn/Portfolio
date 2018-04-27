using System;

namespace Calculation
{
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 3);
        }
    }
}
