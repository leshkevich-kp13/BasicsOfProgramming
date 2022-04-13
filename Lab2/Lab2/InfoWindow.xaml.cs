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
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
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
            rowDef2.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition rowDef3 = new RowDefinition();
            rowDef3.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition rowDef4 = new RowDefinition();
            rowDef3.Height = new GridLength(0.7, GridUnitType.Star);

            mainGrid.RowDefinitions.Add(rowDef1);
            mainGrid.RowDefinitions.Add(rowDef2);
            mainGrid.RowDefinitions.Add(rowDef3);
            mainGrid.RowDefinitions.Add(rowDef4);

            Label name_Label = new Label();
            name_Label.Content = "Lesgkevich Pavlo Stepanovich";
            name_Label.Foreground = new SolidColorBrush(Colors.White);
            name_Label.FontFamily = new FontFamily("Segoe Print");
            name_Label.FontSize = 36;
            name_Label.HorizontalAlignment = HorizontalAlignment.Center;
            name_Label.FontStretch = FontStretches.UltraCondensed;
            name_Label.FontWeight = FontWeights.Bold;
            Grid.SetRow(name_Label, 1);

            Label group_Label = new Label();
            group_Label.Content = "KP-13 2022";
            group_Label.Foreground = new SolidColorBrush(Colors.White);
            group_Label.FontFamily = new FontFamily("Segoe Print");
            group_Label.FontSize = 36;
            group_Label.HorizontalAlignment = HorizontalAlignment.Center;
            group_Label.FontStretch = FontStretches.UltraCondensed;
            group_Label.FontWeight = FontWeights.Bold;
            Grid.SetRow(group_Label, 2);

            Grid grid2 = new Grid();
            ColumnDefinition columnDef1 = new ColumnDefinition();
            columnDef1.Width = new GridLength(5, GridUnitType.Star);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(columnDef1);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid2, 3);

            Button MoveToMainWin_Btn = new Button();
            MoveToMainWin_Btn.Content = "Main Window";
            MoveToMainWin_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            MoveToMainWin_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MoveToMainWin_Btn.Margin = new Thickness(20);
            MoveToMainWin_Btn.FontFamily = new FontFamily("Segoe Print");
            MoveToMainWin_Btn.FontSize = 36;
            MoveToMainWin_Btn.FontWeight = FontWeights.Bold;
            Grid.SetColumn(MoveToMainWin_Btn, 1);
            MoveToMainWin_Btn.Click += MoveToMaintBtn_Click;

            grid2.Children.Add(MoveToMainWin_Btn);

            mainGrid.Children.Add(name_Label);
            mainGrid.Children.Add(group_Label);
            mainGrid.Children.Add(grid2);
        
            Content = mainGrid;
        }

        private void MoveToMaintBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
