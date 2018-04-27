using System;
using System.Linq;

namespace AreaCalculator
{
    public enum MainMenuItem
    {
        [MainMenuItem("Выход")]
        Exit,
        [MainMenuItem("Круг")]
        Circle,
        [MainMenuItem("Треугольник")]
        Triangle,
        [MainMenuItem("Любая фигура")]
        Polygon
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class MainMenuItemAttribute : Attribute
    {
        public string Name { get; set; }

        public MainMenuItemAttribute(string name)
        {
            Name = name;
        }

        public static string GetName(MainMenuItem menuItem)
        {
            var menuItemName = menuItem.GetType().GetMember(Enum.GetName(typeof(MainMenuItem), menuItem))[0]
                .GetCustomAttributes(typeof(MainMenuItemAttribute), false).Cast<MainMenuItemAttribute>().SingleOrDefault()
                ?.Name;

            return menuItemName;
        }
    }

    public enum PolygonMenuItem
    {
        [PolygonMenuItem("Завершить построение")]
        StopConstruction,
        [PolygonMenuItem("Добавить точку")]
        AddPoint
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class PolygonMenuItemAttribute : Attribute
    {
        public string Name { get; set; }

        public PolygonMenuItemAttribute(string name)
        {
            Name = name;
        }

        public static string GetName(PolygonMenuItem menuItem)
        {
            var menuItemName = menuItem.GetType().GetMember(Enum.GetName(typeof(PolygonMenuItem), menuItem))[0]
                .GetCustomAttributes(typeof(PolygonMenuItemAttribute), false).Cast<PolygonMenuItemAttribute>().SingleOrDefault()
                ?.Name;

            return menuItemName;
        }
    }
}
