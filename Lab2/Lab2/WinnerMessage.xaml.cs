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
    /// Логика взаимодействия для WinnerMessage.xaml
    /// </summary>
    public partial class WinnerMessage : Window
    {
        public WinnerMessage(string message)
        {
            InitializeComponent();

            Width = 300;
            Height = 200;

            Grid mainGrid = new Grid();
            mainGrid.Background = new SolidColorBrush(Color.FromRgb(20, 200, 50));

            RowDefinition rowDef1 = new RowDefinition();
            rowDef1.Height = new GridLength(1.5, GridUnitType.Star);
            RowDefinition rowDef2 = new RowDefinition();
            rowDef2.Height = new GridLength(1, GridUnitType.Star);
            mainGrid.RowDefinitions.Add(rowDef1);
            mainGrid.RowDefinitions.Add(rowDef2);

            Grid grid2 = new Grid();
            ColumnDefinition columnDef1 = new ColumnDefinition();
            columnDef1.Width = new GridLength(2, GridUnitType.Star);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(columnDef1);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid2, 1);
            mainGrid.Children.Add(grid2);

            Label Message_Label = new Label();
            Message_Label.Content = message;
            Message_Label.FontSize = 36;
            Message_Label.FontFamily = new FontFamily("Segoe Print");
            Message_Label.FontWeight = FontWeights.Bold;
            Message_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Message_Label.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(Message_Label, 0);
            mainGrid.Children.Add(Message_Label);

            Button OK_Btn = new Button();
            OK_Btn.Content = "OK";
            OK_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            OK_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            OK_Btn.Margin = new Thickness(5);
            OK_Btn.FontFamily = new FontFamily("Segoe Print");
            OK_Btn.FontSize = 20;
            OK_Btn.FontWeight = FontWeights.Bold;
            OK_Btn.Click += OK_Btn_Click;
            Grid.SetColumn(OK_Btn, 1);
            grid2.Children.Add(OK_Btn);

            Content = mainGrid;

        }

        private void OK_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
