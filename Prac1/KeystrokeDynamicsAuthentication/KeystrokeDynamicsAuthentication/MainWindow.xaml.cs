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

namespace KeystrokeDynamicsAuthentication
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LearningSettings learningsettings = new LearningSettings();
            Close();
            learningsettings.Show();
        }

        private void AuthenticationMode_Btn_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationMode authenticationMode = new AuthenticationMode();
            Close();
            authenticationMode.Show();
        }
    }
}
