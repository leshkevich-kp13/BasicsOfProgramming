using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeystrokeDynamicsAuthentication
{
    /// <summary>
    /// Логика взаимодействия для LearningSettings.xaml
    /// </summary>
    public partial class LearningSettings : Window
    {
        public LearningSettings()
        {
            InitializeComponent();
            for (int i = 1; i < 10; i++)
            {
                NumOfAttemps_ComboBox.Items.Add(i);
            }
            NumOfAttemps_ComboBox.SelectedItem = 1;
        }

        string filePath;
        StreamWriter DataFileWriter;

        private void ApplySettings_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(InputWord_TextBox.Text.Length > 10)
            {
                MessageBox.Show("Codeword is too long");
                return;
            }
            if (InputWord_TextBox.Text.Length < 5)
            {
                MessageBox.Show("Codeword is too short");
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() != DialogResult)
            {
                filePath = saveFileDialog1.FileName;
                try
                {
                    DataFileWriter = new StreamWriter(filePath, false);
                }
                catch
                {
                    MessageBox.Show("Error reading .txt file");
                    return;
                }

                CreateDataFile();
            }
            else
            {
                MessageBox.Show("Error saving DataFile");
                return;
            }
            ApplyChanges(InputWord_TextBox.Text, filePath, (int)NumOfAttemps_ComboBox.SelectedItem);

        }

        private void CreateDataFile()
        {
            
            DataFileWriter.Write(InputWord_TextBox.Text);
            DataFileWriter.Flush();
            DataFileWriter.Close();
            return;
        }

        private void ApplyChanges(string codeword, string filePath, int numOfAttemps)
        {
            LearningMode learningMode = new LearningMode(codeword, filePath, numOfAttemps);
            Close();
            learningMode.Show();
        }


        private void MainWindow_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
