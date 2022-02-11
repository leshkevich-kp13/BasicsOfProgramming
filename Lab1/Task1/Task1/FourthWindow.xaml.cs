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

namespace Task1
{
    /// <summary>
    /// Логика взаимодействия для FourthWindow.xaml
    /// </summary>
    public partial class FourthWindow : Window
    {
        public FourthWindow()
        {
            InitializeComponent();
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

                case '*':
                    result = firstNum * secondNum;
                    break;

                case '/':
                    result = firstNum / secondNum;
                    break;
            }

            return result;
        }

        private void OperationsPrinter(string firstNum, string symbol)
        {
            Operations_TextBox.Document.Blocks.Clear();
            Operations_TextBox.Document.Blocks.Add(new Paragraph(new Run(firstNum + symbol)));
        }

        private void TextBoxPrinter(string num)
        {
            Number_TextBox.Document.Blocks.Clear();
            Number_TextBox.Document.Blocks.Add(new Paragraph(new Run(num)));
        }

        private void MoveToMainFromFourthBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void Num_0_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(symbol == " ")
            {
                firstNum = firstNum == "0" ? "0" : firstNum + 0;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "0" : secondNum + 0;
            TextBoxPrinter(secondNum);
        }

        private void Num_1_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {          
                firstNum = firstNum == "0" ? "1" : firstNum + 1;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "1" : secondNum + 1;
            TextBoxPrinter(secondNum);
        }

        private void Num_2_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "2" : firstNum + 2;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "2" : secondNum + 2;
            TextBoxPrinter(secondNum);
        }

        private void Num_3_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "3" : firstNum + 3;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "3" : secondNum + 3;
            TextBoxPrinter(secondNum);
        }

        private void Num_4_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "4" : firstNum + 4;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "4" : secondNum + 4;
            TextBoxPrinter(secondNum);
        }

        private void Num_5_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "5" : firstNum + 5;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "5" : secondNum + 5;
            TextBoxPrinter(secondNum);
        }

        private void Num_6_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "6" : firstNum + 6;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "6" : secondNum + 6;
            TextBoxPrinter(secondNum);
        }
        private void Num_7_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "7" : firstNum + 7;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "7" : secondNum + 7;
            TextBoxPrinter(secondNum);
        }
        private void Num_8_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "8" : firstNum + 8;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "8" : secondNum + 8;
            TextBoxPrinter(secondNum);
        }

        private void Num_9_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol == " ")
            {
                firstNum = firstNum == "0" ? "9" : firstNum + 9;
                TextBoxPrinter(firstNum);
                return;
            }
            secondNum = secondNum == "0" ? "9" : secondNum + 9;
            TextBoxPrinter(secondNum);
        }

        private void Sym_Minus_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(symbol != " ") { Sym_Equals_Btn_Click(sender, e); }
            symbol = "-";
            OperationsPrinter(firstNum, symbol);
        }

        private void Sym_Plus_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol != " ") { Sym_Equals_Btn_Click(sender, e); }
            symbol = "+";
            OperationsPrinter(firstNum, symbol);
        }

        private void Sym_Multiply_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol != " ") { Sym_Equals_Btn_Click(sender, e); }
            symbol = "*";
            OperationsPrinter(firstNum, symbol);
        }

        private void Sym_Divide_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (symbol != " ") { Sym_Equals_Btn_Click(sender, e); }
            symbol = "/";
            OperationsPrinter(firstNum, symbol);
        }

        private void ChangeSign_Btn_Click(object sender, RoutedEventArgs e)
        {
            Number_TextBox.SelectAll();
            string currentNum = Number_TextBox.Selection.Text;

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
            Number_TextBox.SelectAll();
            secondNum = Number_TextBox.Selection.Text;
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
                if(firstNum.Length == 1) { firstNum = "0"; }
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
