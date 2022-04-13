using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OptimalRouteGreedyAlgorithm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Polygon polygon = new Polygon();
        public static PointCollection pointCollection = new PointCollection();
        static List<Ellipse> ellipseArray = new List<Ellipse>();
        static List<int> pointsList = new List<int>();
        static int numOfPoints = 5;
        static int[] route;
        static int radius = 15;
        public MainWindow()
        {
            InitializeComponent();
            FindRouteBtn.IsEnabled = false;
        }
        private void InitializePoints()
        {
            Random rnd = new Random();
            pointCollection.Clear();
            ellipseArray.Clear();

            for (int i = 0; i < numOfPoints; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(radius, (int)(0.75 * MainWin.Width) - 3 * radius);
                p.Y = rnd.Next(radius, (int)(0.90 * MainWin.Height - 3 * radius));
                pointCollection.Add(p);
            }

            for (int i = 0; i < numOfPoints; i++)
            {
                Ellipse el = new Ellipse();

                el.StrokeThickness = 2;
                el.Height = el.Width = radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                ellipseArray.Add(el);
            }
        }
        private void InitializePolygon()
        {
            polygon.Stroke = Brushes.Black;
            polygon.StrokeThickness = 2;
        }
        private void PlotPoints()
        {
            for (int i = 0; i < numOfPoints; i++)
            {
                Canvas.SetLeft(ellipseArray[i], pointCollection[i].X - radius / 2);
                Canvas.SetTop(ellipseArray[i], pointCollection[i].Y - radius / 2);
                mainCanvas.Children.Add(ellipseArray[i]);
            }
        }
        private void PlotWay(int[] route)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < route.Length; i++)
            {
                Points.Add(pointCollection[route[i]]);
            }


            polygon.Points = Points;
            mainCanvas.Children.Add(polygon);
        }
        private void FindRoute()
        {
            
            for(int i = 1; i < numOfPoints; i++)
            {
                pointsList.Add(i);
            }
            int currentPoint = 0;
            for (int i = 0; i < numOfPoints - 1; i++)
            {
                route[i] = currentPoint;
                int nearestPoint = FindTheNearestPoint(currentPoint);
                pointsList.Remove(nearestPoint);
                currentPoint = nearestPoint;
            }
            route[numOfPoints - 1] = currentPoint;
        }
        
        private int FindTheNearestPoint(int point)
        {
            int nearestPoint = pointsList[0];

            double nearestDistance = GetDistatnce(point, pointsList[0]);
            for (int i = 1; i < pointsList.Count; i++)
            {
                double currentDistance = GetDistatnce(point, pointsList[i]);
                if (currentDistance < nearestDistance)
                {
                    nearestDistance = currentDistance;
                    nearestPoint = pointsList[i];
                }
            }
            return nearestPoint;
        }
        private double GetDistatnce(int firstPoint, int secondPoint)
        {
            double x = pointCollection[firstPoint].X - pointCollection[secondPoint].X;
            double y = pointCollection[firstPoint].Y - pointCollection[secondPoint].Y;
            double distance = Math.Sqrt(x * x + y * y);
            return distance;
        }
        private void NumOfPointsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)comboBox.SelectedItem;
            numOfPoints = Convert.ToInt32(item.Content);
            route = new int[numOfPoints];
        }
        private void GeneratePointsBtn_Click(object sender, RoutedEventArgs e)
        {
            InitializePoints();
            InitializePolygon();
            mainCanvas.Children.Clear();
            PlotPoints();
            FindRouteBtn.IsEnabled = true;
        }
        private void FindRouteBtn_Click(object sender, RoutedEventArgs e)
        {
            FindRoute();
            PlotWay(route);
            FindRouteBtn.IsEnabled = false;
        }
    }
}
