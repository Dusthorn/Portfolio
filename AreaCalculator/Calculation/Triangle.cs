using System;

namespace Calculation
{
    public class Triangle : Shape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (!TriangleExists(sideA, sideB, sideC))
                throw new Exception("Не возможно построить треугольник с заданными размерами сторон!");
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetArea()
        {
            var halfPerimeter = (SideA + SideB + SideC) / 2.0;
            return Math.Round(Math.Sqrt(halfPerimeter *
                                        (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC)), 3);
        }

        /// <summary>
        /// Треугольник существует
        /// </summary>
        private bool TriangleExists(double sideA, double sideB, double sideC)
        {
            return sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;
        }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        /// <returns></returns>
        public bool IsRightTriangle()
        {
            return Math.Pow(SideA, 2) + Math.Pow(SideB, 2) == Math.Pow(SideC, 2) ||
                   Math.Pow(SideA, 2) + Math.Pow(SideC, 2) == Math.Pow(SideB, 2) ||
                   Math.Pow(SideB, 2) + Math.Pow(SideC, 2) == Math.Pow(SideA, 2);
        }
    }
}
