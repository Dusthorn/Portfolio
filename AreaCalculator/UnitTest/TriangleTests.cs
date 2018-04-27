using System;
using Calculation;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        [TestCase(1, 10, 1)]
        [TestCase(1, 10, 5)]
        [TestCase(3, 4, 7)]
        public void Test_Triangle_NotExists(double sideA, double sideB, double sideC)
        {
            Assert.Throws<Exception>(() => { new Triangle(sideA, sideB, sideC); });
        }

        [Test]
        [TestCase(3, 4, 5, 6)]
        [TestCase(13, 14, 15, 84)]
        [TestCase(1, 1, 1, 0.433)]
        [TestCase(193, 194, 195, 16296)]
        public void Test_Triangle_AreaCalculation(double sideA, double sideB, double sideC, double expectedArea)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            var area = triangle.GetArea();
            Assert.AreEqual(area, expectedArea);
        }
    }
}
