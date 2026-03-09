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

    public abstract class CircleCreator
    {
        public abstract Circle CreateCircle();
    }

    public class RedCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Colors.Red };
    }

    public class BlueCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Colors.Blue };
    }

    public class GreenCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Colors.Green };
    }

    public abstract class SquareCreator
    {
        public abstract Square CreateSquare();
    }

    public class RedSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Colors.Red };
    }

    public class BlueSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Colors.Blue };
    }

    public class GreenSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Colors.Green };
    }

    public abstract class TriangleCreator
    {
        public abstract Triangle CreateTriangle();
    }

    public class RedTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle() => new Triangle { Color = Colors.Red };
    }

    public class BlueTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle() => new Triangle { Color = Colors.Blue };
    }

    public class GreenTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle() => new Triangle { Color = Colors.Green };
    }
}