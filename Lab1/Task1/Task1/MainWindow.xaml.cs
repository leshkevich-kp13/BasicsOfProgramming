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

namespace Task1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MoveToWin1Btn_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow firstWin = new FirstWindow();
            Close();
            firstWin.Show();
        }

        private void MoveToWin2Btn_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow secondWin = new SecondWindow();
            Close();
            secondWin.Show();
        }

        private void MoveToWin3Btn_Click(object sender, RoutedEventArgs e)
        {
            ThirdWindow thirdWindow = new ThirdWindow();
            Close();
            thirdWindow.Show();
        }

        private void MoveToWin4Btn_Click(object sender, RoutedEventArgs e)
        {
            FourthWindow fourthWindow = new FourthWindow();
            Close();
            fourthWindow.Show();
        }
    }
}
