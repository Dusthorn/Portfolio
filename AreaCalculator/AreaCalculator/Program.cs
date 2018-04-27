using System;
using System.Collections.Generic;
using System.Drawing;
using Calculation;

namespace AreaCalculator
{
    class Program
    {
        private static void Main(string[] args)
        {
            MainMenuItem userInput;
            do
            {
                userInput = DisplayMenu();
                Shape shape = null;
                switch (userInput)
                {
                    case MainMenuItem.Circle:
                        Console.WriteLine("Введите радиус круга: ");
                        var radius = Convert.ToInt32(Console.ReadLine());
                        shape = new Circle(radius);
                        break;
                    case MainMenuItem.Triangle:
                        Console.WriteLine("Введите сторону A: ");
                        var a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите сторону B: ");
                        var b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите сторону C: ");
                        var c = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            shape = new Triangle(a, b, c);
                            Console.WriteLine("Треугольник" +
                                              (((Triangle) shape).IsRightTriangle() ? string.Empty : " не") +
                                              " является прямоугольным");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case MainMenuItem.Polygon:
                        var points = new List<Point>();
                        PolygonMenuItem selectedPolygonMenuItem;
                        do
                        {
                            selectedPolygonMenuItem = DisplayPolygonMenu();
                            if (selectedPolygonMenuItem != PolygonMenuItem.AddPoint) continue;
                            Console.WriteLine("Введите координату точки X: ");
                            var x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите координату точки Y: ");
                            var y = Convert.ToInt32(Console.ReadLine());
                            points.Add(new Point(x, y));
                        } while (selectedPolygonMenuItem != PolygonMenuItem.StopConstruction);
                        try
                        {
                            shape = new Polygon(points);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
                var area = shape?.GetArea();
                if (area != null)
                    Console.WriteLine($"Площадь фигуры равна: {area}\r\n");
            } while (userInput != MainMenuItem.Exit);
        }

        private static MainMenuItem DisplayMenu()
        {
            Console.WriteLine("Расчет площадей фигур");
            Console.WriteLine();
            Console.WriteLine($"{(int) MainMenuItem.Circle}. {MainMenuItemAttribute.GetName(MainMenuItem.Circle)}");
            Console.WriteLine($"{(int) MainMenuItem.Triangle}. {MainMenuItemAttribute.GetName(MainMenuItem.Triangle)}");
            Console.WriteLine($"{(int) MainMenuItem.Polygon}. {MainMenuItemAttribute.GetName(MainMenuItem.Polygon)}");
            Console.WriteLine($"{(int) MainMenuItem.Exit}. {MainMenuItemAttribute.GetName(MainMenuItem.Exit)}");
            var result = Console.ReadLine();
            return (MainMenuItem) Convert.ToInt32(result);
        }

        private static PolygonMenuItem DisplayPolygonMenu()
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine();
            Console.WriteLine($"{(int) PolygonMenuItem.AddPoint}. {PolygonMenuItemAttribute.GetName(PolygonMenuItem.AddPoint)}");
            Console.WriteLine($"{(int) PolygonMenuItem.StopConstruction}. {PolygonMenuItemAttribute.GetName(PolygonMenuItem.StopConstruction)}");
            var result = Console.ReadLine();
            return (PolygonMenuItem) Convert.ToInt32(result);
        }
    }
}
