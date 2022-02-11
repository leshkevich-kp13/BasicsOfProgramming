using System.Windows;

namespace Task1
{

    public partial class WinnerMessage : Window
    {
        public WinnerMessage(string message)
        {
            InitializeComponent();
            Message_Label.Content = message;
        }

        private void OK_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
