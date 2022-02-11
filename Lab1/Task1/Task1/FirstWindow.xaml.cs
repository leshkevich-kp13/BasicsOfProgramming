using System.Windows;

namespace Task1
{
    public partial class FirstWindow : Window
    {
        public FirstWindow()
        {
            InitializeComponent();
        }

        private void MoveToMainFromFirstBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }
    }
}
