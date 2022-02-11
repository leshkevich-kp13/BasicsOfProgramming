using Microsoft.Win32;
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
using System.IO;

namespace Task1
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        string filePath;

        static StreamWriter DataFileWriter;
        static StreamReader DataFileReader;

        public SecondWindow()
        {
            InitializeComponent();
        }

        private void MoveToMainFromSecondBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }


        private void OpenFile_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }
        }

        private void AddStudent_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataFileWriter = new StreamWriter(filePath, true);
            }
            catch
            {
                MessageBox.Show("Error reading .txt file");
                return;
            }

            string studID = StudentID_TextBox.Text;

            string name = Name_TextBox.Text;

            string surname = Surname_TextBox.Text;

            PrintStudent(DataFileWriter, studID, name, surname);

            DataFileWriter.Close();
        }

        public static void PrintStudent(StreamWriter file, string studID, string name, string surname)
        {
            file.Write($"{studID, -15}");
            file.Write($"{name,-15}");
            file.Write($"{surname,-15}");
            file.WriteLine("");
            file.Flush();
        }

        private void DeleteStudent_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataFileReader = new StreamReader(filePath);
            }
            catch
            {
                MessageBox.Show("Error reading .txt file");
                return;
            }

            string studID = DeleteStudentID_TextBox.Text;

            DeleteStudent(DataFileReader, studID);
        }

        public void DeleteStudent(StreamReader fileRead, string studID)
        {
            List<string> lines = new List<string>();
            while (!fileRead.EndOfStream)
            {
                string currentLine = fileRead.ReadLine();
                
                if (!currentLine.Contains(studID))
                {
                    lines.Add(currentLine);
                }
            }
            fileRead.Close();
            File.WriteAllLines(filePath, lines);
        }

    }
}
