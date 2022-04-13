using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OptimalRoute
{
    public partial class MainWindow : Window
    {
        static DispatcherTimer dispatcherTimer = new DispatcherTimer();
        static Polygon polygon = new Polygon();
        public static PointCollection pointCollection = new PointCollection();
        static List<Ellipse> ellipseArray = new List<Ellipse>();
        static int numOfPoints = 5;
        static int populationDimension = 5;
        static int mutationProbability = 10;
        static int currentIteration = 0;
        static int numOfIterations = 200;
        static int radius = 15;
        static Chromosome[] population;
        public MainWindow()
        {
            InitializeComponent();
            InitializePoints();
            InitializePolygon();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(OneStep);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);

            stopStartBtn.IsEnabled = false;
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
        private void PlotWay(int[] BestWayIndex)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
            {
                Points.Add(pointCollection[BestWayIndex[i]]);
            }


            polygon.Points = Points;
            mainCanvas.Children.Add(polygon);
        }
        private void SpeedCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)comboBox.SelectedItem;

            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }
        private void NumOfPointsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)comboBox.SelectedItem;
            numOfPoints = Convert.ToInt32(item.Content);
        }
        private void PopulationDimensionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)comboBox.SelectedItem;
            populationDimension = Convert.ToInt32(item.Content);
            population = new Chromosome[populationDimension];
        }
        private void MutatuionProbabilityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)comboBox.SelectedItem;
            mutationProbability = Convert.ToInt32(item.Content);
        }
        private void NumberOfIterationsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)comboBox.SelectedItem;
            numOfIterations = Convert.ToInt32(item.Content);
        }

        private void OneStep(object sender, EventArgs e)
        {
            mainCanvas.Children.Clear();
            PlotPoints();
            PlotWay(population[0].route);
            ChangePopulation();
            currentIteration++;
            CurrentIteration_Label.Content = currentIteration;
            CurrentLength_Label.Content = population[0].GetLength();
            if(currentIteration == numOfIterations) 
            {
                currentIteration = 0;
                dispatcherTimer.Stop(); 

            }
        }
        private void ChangePopulation()
        {
            Random rnd = new Random();
            int breakPoint = rnd.Next(numOfPoints);
            int firstParent = rnd.Next(population.Length);
            int secondParent = rnd.Next(population.Length);

            while (secondParent == firstParent) { secondParent = rnd.Next(population.Length); }

            Chromosome firstChild = Crossing(firstParent, secondParent, breakPoint);
            Chromosome secondChild = Crossing(secondParent, firstParent, breakPoint);

            firstChild = Mutation(firstChild);
            secondChild = Mutation(secondChild);

            AddDescendant(firstChild);
            AddDescendant(secondChild);
        }

        private Chromosome Crossing(int firstParent, int secondParent, int breakPoint)
        {
            Chromosome child;
            int[] newRoute = new int[numOfPoints];
            Array.Copy(population[firstParent].route, newRoute, numOfPoints);

            List<int> genes = new List<int>();

            for (int i = breakPoint; i < numOfPoints; i++)
            {
                genes.Add(population[firstParent].route[i]);
            }

            int checkbox = breakPoint;

            for (int i = breakPoint; i < numOfPoints; i++)
            {
                if (genes.Contains(population[secondParent].route[i]))
                {
                    newRoute[checkbox] = population[secondParent].route[i];
                    genes.Remove(population[secondParent].route[i]);
                    checkbox++;
                }
            }

            for (int i = 0; i < genes.Count; i++, checkbox++)
            {
                newRoute[checkbox] = genes[i];
            }

            child.route = newRoute;
            return child;
        }

        private Chromosome Mutation(Chromosome chromosome)
        {
            Chromosome mutatedChromosome = chromosome;
            Random rnd = new Random();
            if (rnd.Next(101) < mutationProbability)
            {
                int i1, i2;
                i1 = rnd.Next(numOfPoints);
                i2 = rnd.Next(numOfPoints - i1);
                Array.Reverse(mutatedChromosome.route, i1, i2);
            }
            return mutatedChromosome;
        }

        private void AddDescendant(Chromosome descendant)
        {
            int index = FindPlaceForDescendant(descendant.GetLength());

            if (index < population.Length)
            {
                for (int i = population.Length - 2; i >= index; i--)
                {
                    population[i + 1] = population[i];
                }
                population[index] = descendant;
            }
        }

        private int FindPlaceForDescendant(double descendantLength)
        {
            int index = 0;
            while (index < population.Length && descendantLength > population[index].GetLength())
            {
                index++;
            }
            return index;
        }
        private void GeneratePointsBtn_Click(object sender, RoutedEventArgs e)
        {
            InitializePoints();
            InitializePolygon();
            mainCanvas.Children.Clear();
            PlotPoints();
            stopStartBtn.IsEnabled = true;
            dispatcherTimer.Stop();
            numOfPointsCB.IsEnabled = true;
            populationDimensionCB.IsEnabled = true;
            CurrentIteration_Label.Content = "";
            currentIteration = 0;
            CurrentLength_Label.Content = "";
        }
        private void StopStartBtn_Click(object sender, RoutedEventArgs e)
        {
            
            FormPopulation();
            population = QuickSort(population);

            if (dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Stop();
                numOfPointsCB.IsEnabled = true;
                populationDimensionCB.IsEnabled = true;
            }
            else
            {
                numOfPointsCB.IsEnabled = false;
                populationDimensionCB.IsEnabled = false;
                dispatcherTimer.Start();
            }
        }
        static void Swap(ref Chromosome x, ref Chromosome y)
        {
            Chromosome t = x;
            x = y;
            y = t;
        }

        static int Partition(Chromosome[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].GetLength() < array[maxIndex].GetLength())
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        static Chromosome[] QuickSort(Chromosome[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static Chromosome[] QuickSort(Chromosome[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        private void SortPopulation()
        {
            for (int i = 0; i < population.Length; i++)
            {
                for (int j = 1; j < population.Length - i; j++)
                {
                    if (population[j - 1].GetLength() > population[j].GetLength())
                    {
                        Chromosome tmp = population[j - 1];
                        population[j - 1] = population[j];
                        population[j] = tmp;

                    }
                }
            }
        }
        private void FormPopulation()
        {
            Random rnd = new Random();

            for (int i = 0; i < populationDimension; i++)
            {
                int[] way = new int[numOfPoints];

                for (int j = 0; j < numOfPoints; j++)
                {
                    way[j] = j;
                }

                for (int s = 0; s < 2 * numOfPoints; s++)
                {
                    int i1, i2, tmp;

                    i1 = rnd.Next(numOfPoints);
                    i2 = rnd.Next(numOfPoints);
                    tmp = way[i1];
                    way[i1] = way[i2];
                    way[i2] = tmp;
                }
                Chromosome cr;
                cr.route = way;
                population[i] = cr;
            }
        }
    }

    struct Chromosome
    {
        public int[] route;

        public double GetLength()
        {
            double x = MainWindow.pointCollection[route[route.Length - 1]].X - MainWindow.pointCollection[route[0]].X;
            double y = MainWindow.pointCollection[route[route.Length - 1]].Y - MainWindow.pointCollection[route[0]].Y;
            double length = Math.Sqrt(x * x + y * y);

            for (int i = 0; i < route.Length - 1; i++)
            {
                x = MainWindow.pointCollection[route[i]].X - MainWindow.pointCollection[route[i + 1]].X;
                y = MainWindow.pointCollection[route[i]].Y - MainWindow.pointCollection[route[i + 1]].Y;
                length += Math.Sqrt(x * x + y * y);
            }
            return length;
        }
    }
}

