using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba_RPM_2_090326
{
    public partial class MainWindow : Window
    {
        CircleCreator circleCreator;
        SquareCreator squareCreator;
        TriangleCreator triangleCreator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrawingCanvas == null) return;

            DrawingCanvas.Children.Clear();

            // выбор фигуры
            ComboBoxItem selectedItem = (ComboBoxItem)ColorSelector.SelectedItem;
            if (selectedItem == null) return;

            switch (selectedItem.Content.ToString())
            {
                case "Красный":
                    circleCreator = new RedCircleCreator();
                    squareCreator = new RedSquareCreator();
                    triangleCreator = new RedTriangleCreator();
                    break;
                case "Синий":
                    circleCreator = new BlueCircleCreator();
                    squareCreator = new BlueSquareCreator();
                    triangleCreator = new BlueTriangleCreator();
                    break;
                case "Зелёный":
                    circleCreator = new GreenCircleCreator();
                    squareCreator = new GreenSquareCreator();
                    triangleCreator = new GreenTriangleCreator();
                    break;
                default:
                    return;
            }
        }

        private void AddCircle_Click(object sender, RoutedEventArgs e)
        {
            if (circleCreator != null)
                DrawingCanvas.Children.Add(circleCreator.CreateCircle().Draw());
        }

        private void AddSquare_Click(object sender, RoutedEventArgs e)
        {
            if (squareCreator != null)
                DrawingCanvas.Children.Add(squareCreator.CreateSquare().Draw());
        }

        private void AddTriangle_Click(object sender, RoutedEventArgs e)
        {
            if (triangleCreator != null)
                DrawingCanvas.Children.Add(triangleCreator.CreateTriangle().Draw());
        }
    }
}