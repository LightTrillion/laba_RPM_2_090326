using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace laba_RPM_2_090326
{
    public abstract class Figure
    {
        public Color Color { get; set; }

        // Метод, создающий визуальный элемент для отображения
        public abstract UIElement Draw(double size = 50);
    }

    public class Circle : Figure
    {
        public override UIElement Draw(double size = 50)
        {
            return new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
        }
    }

    public class Square : Figure
    {
        public override UIElement Draw(double size = 50)
        {
            return new Rectangle
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
        }
    }

    public class Triangle : Figure
    {
        public override UIElement Draw(double size = 50)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection
                {
                new Point(size / 2, 0),
                new Point(0, size),
                new Point(size, size)
                },
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5),
                Width = size,
                Height = size,
                Stretch = Stretch.Fill
            };
            return polygon;
        }
    }

    public interface IShapeFactory
    {
        Circle CreateCircle();
        Square CreateSquare();
        Triangle CreateTriangle();
    }

    public class RedShapeFactory : IShapeFactory
    {
        public Circle CreateCircle() => new Circle { Color = Colors.Red };
        public Square CreateSquare() => new Square { Color = Colors.Red };
        public Triangle CreateTriangle() => new Triangle { Color = Colors.Red };
    }

    public class BlueShapeFactory : IShapeFactory
    {
        public Circle CreateCircle() => new Circle { Color = Colors.Blue };
        public Square CreateSquare() => new Square { Color = Colors.Blue };
        public Triangle CreateTriangle() => new Triangle { Color = Colors.Blue };
    }

    public class GreenShapeFactory : IShapeFactory
    {
        public Circle CreateCircle() => new Circle { Color = Colors.Green };
        public Square CreateSquare() => new Square { Color = Colors.Green };
        public Triangle CreateTriangle() => new Triangle { Color = Colors.Green };
    }
}