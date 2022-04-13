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
    /// Логика взаимодействия для CalculatorWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        TextBox Operations_TextBox = new TextBox();
        TextBox Number_TextBox = new TextBox();
        public CalculatorWindow()
        {
            InitializeComponent();

            Width = 400;
            Height = 500;

            Grid mainGrid = new Grid();
            mainGrid.Background = new SolidColorBrush(Color.FromRgb(20, 200, 50));

            RowDefinition rowDef1 = new RowDefinition();
            rowDef1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition rowDef2 = new RowDefinition();
            rowDef2.Height = new GridLength(5.5, GridUnitType.Star);
            RowDefinition rowDef3 = new RowDefinition();
            rowDef3.Height = new GridLength(0.5, GridUnitType.Star);
            RowDefinition rowDef4 = new RowDefinition();
            rowDef4.Height = new GridLength(14, GridUnitType.Star);
            RowDefinition rowDef5 = new RowDefinition();
            rowDef5.Height = new GridLength(3.5, GridUnitType.Star);

            mainGrid.RowDefinitions.Add(rowDef1);
            mainGrid.RowDefinitions.Add(rowDef2);
            mainGrid.RowDefinitions.Add(rowDef3);
            mainGrid.RowDefinitions.Add(rowDef4);
            mainGrid.RowDefinitions.Add(rowDef5);

            Grid grid2 = new Grid();
            ColumnDefinition columnDef1 = new ColumnDefinition();
            columnDef1.Width = new GridLength(18, GridUnitType.Star);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(columnDef1);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid2, 1);
            mainGrid.Children.Add(grid2);

            Grid grid4 = new Grid();          
            ColumnDefinition columnDef2 = new ColumnDefinition();
            columnDef2.Width = new GridLength(18, GridUnitType.Star);
            grid4.ColumnDefinitions.Add(new ColumnDefinition());
            grid4.ColumnDefinitions.Add(columnDef2);
            grid4.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid4, 3);
            mainGrid.Children.Add(grid4);


            Grid grid4_1 = new Grid();
            grid4_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid4_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid4_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid4_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid4_1.RowDefinitions.Add(new RowDefinition());
            grid4_1.RowDefinitions.Add(new RowDefinition());
            grid4_1.RowDefinitions.Add(new RowDefinition());
            grid4_1.RowDefinitions.Add(new RowDefinition());
            grid4_1.RowDefinitions.Add(new RowDefinition());
            Grid.SetColumn(grid4_1, 1);
            grid4.Children.Add(grid4_1);

            Grid grid5 = new Grid();
            ColumnDefinition columnDef3 = new ColumnDefinition();
            columnDef3.Width = new GridLength(3, GridUnitType.Star);
            grid5.ColumnDefinitions.Add(new ColumnDefinition());
            grid5.ColumnDefinitions.Add(columnDef3);
            grid5.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid5, 4);
            mainGrid.Children.Add(grid5);

            Number_TextBox.Text = "0";
            Number_TextBox.HorizontalAlignment = HorizontalAlignment.Left;
            Number_TextBox.FontSize = 48;
            Number_TextBox.TextAlignment = TextAlignment.Right;
            Number_TextBox.FontFamily = new FontFamily("Segoe Print");
            Number_TextBox.Margin = new Thickness(0, 34, 0, -0.4);
            Number_TextBox.IsReadOnly = true;
            Number_TextBox.Width = 350;
            Grid.SetColumn(Number_TextBox, 1);
            grid2.Children.Add(Number_TextBox);

            Operations_TextBox.Text = "0";
            Operations_TextBox.HorizontalAlignment = HorizontalAlignment.Left;
            Operations_TextBox.FontSize = 13;
            Operations_TextBox.TextAlignment = TextAlignment.Right;
            Operations_TextBox.FontFamily = new FontFamily("Segoe Print");
            Operations_TextBox.Margin = new Thickness(-1, 34, 0, 47.6);
            Operations_TextBox.Width = 350;
            Operations_TextBox.IsReadOnly = true;
            Grid.SetColumn(Operations_TextBox, 1);
            grid2.Children.Add(Operations_TextBox);

            Button Sym_Equals_Btn = new Button();
            Sym_Equals_Btn = ButtonSettings(Sym_Equals_Btn);
            Sym_Equals_Btn.Content = "=";
            Sym_Equals_Btn.Click += Sym_Equals_Btn_Click;
            Grid.SetColumn(Sym_Equals_Btn, 1);
            Grid.SetRow(Sym_Equals_Btn, 0);
            grid4_1.Children.Add(Sym_Equals_Btn);

            Button Clear_Btn = new Button();
            Clear_Btn = ButtonSettings(Clear_Btn);
            Clear_Btn.Content = "C";
            Clear_Btn.Click += Clear_Btn_Click;
            Grid.SetColumn(Clear_Btn, 2);
            Grid.SetRow(Clear_Btn, 0);
            grid4_1.Children.Add(Clear_Btn);

            Button Backspace_Btn = new Button();
            Backspace_Btn = ButtonSettings(Backspace_Btn);
            Backspace_Btn.Content = "⌫";
            Backspace_Btn.Click += Backspace_Btn_Click;
            Grid.SetColumn(Backspace_Btn, 3);
            Grid.SetRow(Backspace_Btn, 0);
            grid4_1.Children.Add(Backspace_Btn);

            Button Num_7_Btn = new Button();
            Num_7_Btn = ButtonSettings(Num_7_Btn);
            Num_7_Btn.Content = "7";
            Num_7_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_7_Btn, 0);
            Grid.SetRow(Num_7_Btn, 1);
            grid4_1.Children.Add(Num_7_Btn);

            Button Num_8_Btn = new Button();
            Num_8_Btn = ButtonSettings(Num_8_Btn);
            Num_8_Btn.Content = "8";
            Num_8_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_8_Btn, 1);
            Grid.SetRow(Num_8_Btn, 1);
            grid4_1.Children.Add(Num_8_Btn);

            Button Num_9_Btn = new Button();
            Num_9_Btn = ButtonSettings(Num_9_Btn);
            Num_9_Btn.Content = "9";
            Num_9_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_9_Btn, 2);
            Grid.SetRow(Num_9_Btn, 1);
            grid4_1.Children.Add(Num_9_Btn);

            Button Sym_Divide_Btn = new Button();
            Sym_Divide_Btn = ButtonSettings(Sym_Divide_Btn);
            Sym_Divide_Btn.Content = "÷";
            Sym_Divide_Btn.Click += Symbol_Btn_Click;
            Grid.SetColumn(Sym_Divide_Btn, 3);
            Grid.SetRow(Sym_Divide_Btn, 1);
            grid4_1.Children.Add(Sym_Divide_Btn);

            Button Num_4_Btn = new Button();
            Num_4_Btn = ButtonSettings(Num_4_Btn);
            Num_4_Btn.Content = "4";
            Num_4_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_4_Btn, 0);
            Grid.SetRow(Num_4_Btn, 2);
            grid4_1.Children.Add(Num_4_Btn);

            Button Num_5_Btn = new Button();
            Num_5_Btn = ButtonSettings(Num_5_Btn);
            Num_5_Btn.Content = "5";
            Num_5_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_5_Btn, 1);
            Grid.SetRow(Num_5_Btn, 2);
            grid4_1.Children.Add(Num_5_Btn);

            Button Num_6_Btn = new Button();
            Num_6_Btn = ButtonSettings(Num_6_Btn);
            Num_6_Btn.Content = "6";
            Num_6_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_6_Btn, 2);
            Grid.SetRow(Num_6_Btn, 2);
            grid4_1.Children.Add(Num_6_Btn);

            Button Sym_Multiply_Btn = new Button();
            Sym_Multiply_Btn = ButtonSettings(Sym_Multiply_Btn);
            Sym_Multiply_Btn.Content = "×";
            Sym_Multiply_Btn.Click += Symbol_Btn_Click;
            Grid.SetColumn(Sym_Multiply_Btn, 3);
            Grid.SetRow(Sym_Multiply_Btn, 2);
            grid4_1.Children.Add(Sym_Multiply_Btn);

            Button Num_1_Btn = new Button();
            Num_1_Btn = ButtonSettings(Num_1_Btn);
            Num_1_Btn.Content = "1";
            Num_1_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_1_Btn, 0);
            Grid.SetRow(Num_1_Btn, 3);
            grid4_1.Children.Add(Num_1_Btn);

            Button Num_2_Btn = new Button();
            Num_2_Btn = ButtonSettings(Num_2_Btn);
            Num_2_Btn.Content = "2";
            Num_2_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_2_Btn, 1);
            Grid.SetRow(Num_2_Btn, 3);
            grid4_1.Children.Add(Num_2_Btn);

            Button Num_3_Btn = new Button();
            Num_3_Btn = ButtonSettings(Num_3_Btn);
            Num_3_Btn.Content = "3";
            Num_3_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_3_Btn, 2);
            Grid.SetRow(Num_3_Btn, 3);
            grid4_1.Children.Add(Num_3_Btn);

            Button Sym_Minus_Btn = new Button();
            Sym_Minus_Btn = ButtonSettings(Sym_Minus_Btn);
            Sym_Minus_Btn.Content = "-";
            Sym_Minus_Btn.Click += Symbol_Btn_Click;
            Grid.SetColumn(Sym_Minus_Btn, 3);
            Grid.SetRow(Sym_Minus_Btn, 3);
            grid4_1.Children.Add(Sym_Minus_Btn);

            Button ChangeSign_Btn = new Button();
            ChangeSign_Btn = ButtonSettings(ChangeSign_Btn);
            ChangeSign_Btn.Content = "±";
            ChangeSign_Btn.Click += Symbol_Btn_Click;
            Grid.SetColumn(ChangeSign_Btn, 0);
            Grid.SetRow(ChangeSign_Btn, 4);
            grid4_1.Children.Add(ChangeSign_Btn);

            Button Num_0_Btn = new Button();
            Num_0_Btn = ButtonSettings(Num_0_Btn);
            Num_0_Btn.Content = "0";
            Num_0_Btn.Click += Num_Btn_Click;
            Grid.SetColumn(Num_0_Btn, 1);
            Grid.SetRow(Num_0_Btn, 4);
            grid4_1.Children.Add(Num_0_Btn);

            Button Comma_Btn = new Button();
            Comma_Btn = ButtonSettings(Comma_Btn);
            Comma_Btn.Content = ",";
            Comma_Btn.Click += Comma_Btn_Click;
            Grid.SetColumn(Comma_Btn, 2);
            Grid.SetRow(Comma_Btn, 4);
            grid4_1.Children.Add(Comma_Btn);

            Button Sym_Plus_Btn = new Button();
            Sym_Plus_Btn = ButtonSettings(Sym_Plus_Btn);
            Sym_Plus_Btn.Content = "+";
            Sym_Plus_Btn.Click += Symbol_Btn_Click;
            Grid.SetColumn(Sym_Plus_Btn, 3);
            Grid.SetRow(Sym_Plus_Btn, 4);
            grid4_1.Children.Add(Sym_Plus_Btn);

            Button MainWin_Btn = new Button();
            MainWin_Btn.Content = "Main Window";
            MainWin_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            MainWin_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MainWin_Btn.FontFamily = new FontFamily("Segoe Print");
            MainWin_Btn.FontSize = 20;
            MainWin_Btn.Margin = new Thickness(10);
            MainWin_Btn.FontWeight = FontWeights.Bold;
            MainWin_Btn.Click += MoveToMainFromFourthBtn_Click;
            Grid.SetColumn(MainWin_Btn, 1);
            grid5.Children.Add(MainWin_Btn);

            Content = mainGrid;
        }
        Button ButtonSettings(Button button)
        {
            button.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            button.FontFamily = new FontFamily("Segoe Print");
            button.FontSize = 30;
            button.FontWeight = FontWeights.Bold;
            return button;
        }

        string firstNum = "0";
        string secondNum = "0";
        string symbol = " ";


        private double Calculator(double firstNum, double secondNum, char symbol)
        {
            double result = firstNum;

            switch (symbol)
            {
                case '+':
                    result = firstNum + secondNum;
                    break;

                case '-':
                    result = firstNum - secondNum;
                    break;

                case '×':
                    result = firstNum * secondNum;
                    break;

                case '÷':
                    result = firstNum / secondNum;
                    break;
            }

            return result;
        }

        private void OperationsPrinter(string firstNum, string symbol)
        {
            Operations_TextBox.Clear();
            Operations_TextBox.Text = firstNum + symbol;
        }

        private void TextBoxPrinter(string num)
        {
            Number_TextBox.Clear();
            Number_TextBox.Text = num;
        }

        private void MoveToMainFromFourthBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void Num_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? Convert.ToString(button.Content) : firstNum + Convert.ToString(button.Content);
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? Convert.ToString(button.Content) : secondNum + Convert.ToString(button.Content);
            TextBoxPrinter(secondNum);
        }

        private void Symbol_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (symbol != " ") { Sym_Equals_Btn_Click(sender, e); }
            symbol = Convert.ToString(button.Content);
            OperationsPrinter(firstNum, symbol);
        }

        private void ChangeSign_Btn_Click(object sender, RoutedEventArgs e)
        {          
            string currentNum = Number_TextBox.Text;

            if (symbol == " " && firstNum.Length > 0)
            {
                firstNum = Convert.ToString(Convert.ToDouble(currentNum) * (-1));
                TextBoxPrinter(firstNum);
            }
            else if (secondNum.Length > 0)
            {
                secondNum = Convert.ToString(Convert.ToDouble(currentNum) * (-1));
                TextBoxPrinter(secondNum);
            }

        }

        private void Comma_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                if (!firstNum.Contains(","))
                {
                    firstNum = firstNum + ",";
                    TextBoxPrinter(firstNum);
                }
                return;
            }
            if (!secondNum.Contains(","))
            {
                secondNum = secondNum + ",";
                TextBoxPrinter(secondNum);
            }

        }

        private void Sym_Equals_Btn_Click(object sender, RoutedEventArgs e)
        {       
            secondNum = Number_TextBox.Text;
            double result = Calculator(Convert.ToDouble(firstNum), Convert.ToDouble(secondNum), Convert.ToChar(symbol));
            firstNum = Convert.ToString(result);
            TextBoxPrinter(firstNum);
            secondNum = "0";
            symbol = " ";
            OperationsPrinter(firstNum, symbol);
        }

        private void Clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            firstNum = "0";
            secondNum = "0";
            symbol = " ";
            TextBoxPrinter(firstNum);
            OperationsPrinter("", "");
        }

        private void Backspace_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " " && firstNum.Length > 0)
            {
                if (firstNum.Length == 1) { firstNum = "0"; }
                else { firstNum = firstNum.Remove(firstNum.Length - 1); }

                TextBoxPrinter(firstNum);
                return;
            }
            else if (secondNum.Length > 0)
            {
                if (secondNum.Length == 1) { secondNum = "0"; }
                else { secondNum = secondNum.Remove(secondNum.Length - 1); }

                TextBoxPrinter(secondNum);
            }
        }
    }
}

