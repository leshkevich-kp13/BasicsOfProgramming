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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Width = 800;
            Height = 450;

            Grid mainGrid = new Grid();
            mainGrid.Background = new SolidColorBrush(Color.FromRgb(20, 200, 50));
            GridLengthConverter gridLengthConverter = new GridLengthConverter();

            RowDefinition rowDef1 = new RowDefinition();
            rowDef1.Height = new GridLength(0.3, GridUnitType.Star);
            RowDefinition rowDef2 = new RowDefinition();

            mainGrid.RowDefinitions.Add(rowDef1);
            mainGrid.RowDefinitions.Add(rowDef2);
           
            Grid grid2 = new Grid();
            grid2.RowDefinitions.Add(new RowDefinition());
            grid2.RowDefinitions.Add(new RowDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid2, 1);

            Label mainWindow_Label = new Label();
            mainWindow_Label.Content = "Main Window";
            mainWindow_Label.Foreground = new SolidColorBrush(Colors.White);
            mainWindow_Label.FontFamily = new FontFamily("Segoe Print");
            mainWindow_Label.FontSize = 48;
            mainWindow_Label.HorizontalAlignment = HorizontalAlignment.Center;
            mainWindow_Label.FontStretch = FontStretches.UltraCondensed;
            mainWindow_Label.FontWeight = FontWeights.Bold;
            Grid.SetRow(mainWindow_Label, 0);

            Button MoveToInfoWin_Btn = new Button();
            MoveToInfoWin_Btn.Content = "Info";
            MoveToInfoWin_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128,0));
            MoveToInfoWin_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MoveToInfoWin_Btn.Margin = new Thickness(15);
            MoveToInfoWin_Btn.FontFamily = new FontFamily("Segoe Print");
            MoveToInfoWin_Btn.FontSize = 36;
            MoveToInfoWin_Btn.FontWeight = FontWeights.Bold;
            Grid.SetRow(MoveToInfoWin_Btn, 0);
            Grid.SetColumn(MoveToInfoWin_Btn, 0);
            MoveToInfoWin_Btn.Click += MoveToInfoWinBtn_Click;

            Button MoveToDatabaseWin_Btn = new Button();
            MoveToDatabaseWin_Btn.Content = "Students Database";
            MoveToDatabaseWin_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            MoveToDatabaseWin_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MoveToDatabaseWin_Btn.Margin = new Thickness(15);
            MoveToDatabaseWin_Btn.FontFamily = new FontFamily("Segoe Print");
            MoveToDatabaseWin_Btn.FontSize = 36;
            MoveToDatabaseWin_Btn.FontWeight = FontWeights.Bold;
            Grid.SetRow(MoveToDatabaseWin_Btn, 0);
            Grid.SetColumn(MoveToDatabaseWin_Btn, 1);
            MoveToDatabaseWin_Btn.Click += MoveToDatabaseWinBtn_Click;

            Button MoveToTicTacToeWin_Btn = new Button();
            MoveToTicTacToeWin_Btn.Content = "Tic-Tac-Toe";
            MoveToTicTacToeWin_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            MoveToTicTacToeWin_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MoveToTicTacToeWin_Btn.Margin = new Thickness(15);
            MoveToTicTacToeWin_Btn.FontFamily = new FontFamily("Segoe Print");
            MoveToTicTacToeWin_Btn.FontSize = 36;
            MoveToTicTacToeWin_Btn.FontWeight = FontWeights.Bold;
            MoveToTicTacToeWin_Btn.Click += MoveToTicTacToeWinBtn_Click;
            Grid.SetRow(MoveToTicTacToeWin_Btn, 1);
            Grid.SetColumn(MoveToTicTacToeWin_Btn, 0);

            Button MoveToCalculatorWin_Btn = new Button();
            MoveToCalculatorWin_Btn.Content = "Calculator";
            MoveToCalculatorWin_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            MoveToCalculatorWin_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MoveToCalculatorWin_Btn.Margin = new Thickness(15);
            MoveToCalculatorWin_Btn.FontFamily = new FontFamily("Segoe Print");
            MoveToCalculatorWin_Btn.FontSize = 36;
            MoveToCalculatorWin_Btn.FontWeight = FontWeights.Bold;
            MoveToCalculatorWin_Btn.Click += MoveToCalculatorWinBtn_Click;
            Grid.SetRow(MoveToCalculatorWin_Btn, 1);
            Grid.SetColumn(MoveToCalculatorWin_Btn, 1);

            mainGrid.Children.Add(mainWindow_Label);
            mainGrid.Children.Add(grid2);

            grid2.Children.Add(MoveToInfoWin_Btn);
            grid2.Children.Add(MoveToDatabaseWin_Btn);
            grid2.Children.Add(MoveToTicTacToeWin_Btn);
            grid2.Children.Add(MoveToCalculatorWin_Btn);

            Content = mainGrid;
        }

        private void MoveToInfoWinBtn_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWin = new InfoWindow();
            Close();
            infoWin.Show();
        }

        private void MoveToDatabaseWinBtn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseWindow databaseWin = new DatabaseWindow();
            Close();
            databaseWin.Show();
        }

        private void MoveToTicTacToeWinBtn_Click(object sender, RoutedEventArgs e)
        {
            TicTacToeWindow ticTacToeWin = new TicTacToeWindow();
            Close();
            ticTacToeWin.Show();
        }
        
        private void MoveToCalculatorWinBtn_Click(object sender, RoutedEventArgs e)
        {
            CalculatorWindow calculatorWin = new CalculatorWindow();
            Close();
            calculatorWin.Show();
        }
    }
}

