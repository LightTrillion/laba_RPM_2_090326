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
        private IShapeFactory currentFactory;

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
                    currentFactory = new RedShapeFactory();
                    break;
                case "Синий":
                    currentFactory = new BlueShapeFactory();
                    break;
                case "Зелёный":
                    currentFactory = new GreenShapeFactory();
                    break;
                default:
                    return;
            }
        }

        private void AddCircle_Click(object sender, RoutedEventArgs e)
        {
            if (currentFactory != null)
                DrawingCanvas.Children.Add(currentFactory.CreateCircle().Draw());
        }

        private void AddSquare_Click(object sender, RoutedEventArgs e)
        {
            if (currentFactory != null)
                DrawingCanvas.Children.Add(currentFactory.CreateSquare().Draw());
        }

        private void AddTriangle_Click(object sender, RoutedEventArgs e)
        {
            if (currentFactory != null)
                DrawingCanvas.Children.Add(currentFactory.CreateTriangle().Draw());
        }
    }
}