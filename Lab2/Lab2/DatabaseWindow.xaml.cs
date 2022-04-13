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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        string filePath;

        static StreamWriter DataFileWriter;
        static StreamReader DataFileReader;

        TextBox Name_TextBox = new TextBox();
        TextBox Surname_TextBox = new TextBox();
        TextBox StudentID_TextBox = new TextBox();
        TextBox DeleteStudentID_TextBox = new TextBox();
        public DatabaseWindow()
        {
            InitializeComponent();
            Width = 800;
            Height = 450;

            Grid mainGrid = new Grid();
            mainGrid.Background = new SolidColorBrush(Color.FromRgb(20, 200, 50));

            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());


            Grid grid2 = new Grid();
            ColumnDefinition columnDef1 = new ColumnDefinition();
            columnDef1.Width = new GridLength(15, GridUnitType.Star);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(columnDef1);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid2, 1);

            Grid grid2_1 = new Grid();
            grid2_1.RowDefinitions.Add(new RowDefinition());
            grid2_1.RowDefinitions.Add(new RowDefinition());
            grid2_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid2_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid2_1.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetColumn(grid2_1, 1);

            Grid grid3 = new Grid();
            grid3.ColumnDefinitions.Add(new ColumnDefinition());
            grid3.ColumnDefinitions.Add(new ColumnDefinition());
            grid3.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid3, 2);

            Grid grid4 = new Grid();
            ColumnDefinition columnDef2 = new ColumnDefinition();
            columnDef2.Width = new GridLength(15, GridUnitType.Star);
            grid4.ColumnDefinitions.Add(new ColumnDefinition());
            grid4.ColumnDefinitions.Add(columnDef2);
            grid4.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid4, 3);

            Grid grid4_1 = new Grid();
            grid4_1.RowDefinitions.Add(new RowDefinition());
            grid4_1.RowDefinitions.Add(new RowDefinition());
            grid4_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid4_1.ColumnDefinitions.Add(new ColumnDefinition());
            grid4_1.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetColumn(grid4_1, 1);

            Grid grid5 = new Grid();
            grid5.ColumnDefinitions.Add(new ColumnDefinition());
            grid5.ColumnDefinitions.Add(new ColumnDefinition());
            grid5.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid5, 4);

            Grid grid6 = new Grid();
            grid6.ColumnDefinitions.Add(new ColumnDefinition());
            grid6.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid6, 5);


            Label studentID_Label = new Label();
            studentID_Label.Content = "Student ID";
            studentID_Label.FontSize = 18;
            studentID_Label.FontFamily = new FontFamily("Segoe Print");
            studentID_Label.FontWeight = FontWeights.Bold;
            studentID_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Grid.SetRow(studentID_Label, 0);
            Grid.SetColumn(studentID_Label, 0);
            grid2_1.Children.Add(studentID_Label);

            Label name_Label = new Label();
            name_Label.Content = "Student ID";
            name_Label.FontSize = 18;
            name_Label.FontFamily = new FontFamily("Segoe Print");
            name_Label.FontWeight = FontWeights.Bold;
            name_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Grid.SetRow(name_Label, 0);
            Grid.SetColumn(name_Label, 1);
            grid2_1.Children.Add(name_Label);

            Label surname_Label = new Label();
            surname_Label.Content = "Student ID";
            surname_Label.FontSize = 18;
            surname_Label.FontFamily = new FontFamily("Segoe Print");
            surname_Label.FontWeight = FontWeights.Bold;
            surname_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Grid.SetRow(surname_Label, 0);
            Grid.SetColumn(surname_Label, 2);
            grid2_1.Children.Add(surname_Label);

            Label deleteStudentID_Label = new Label();
            deleteStudentID_Label.Content = "Student ID";
            deleteStudentID_Label.FontSize = 18;
            deleteStudentID_Label.FontFamily = new FontFamily("Segoe Print");
            deleteStudentID_Label.FontWeight = FontWeights.Bold;
            deleteStudentID_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Grid.SetRow(deleteStudentID_Label, 0);
            Grid.SetColumn(deleteStudentID_Label, 1);
            grid4_1.Children.Add(deleteStudentID_Label);

            
            StudentID_TextBox.FontSize = 18;
            StudentID_TextBox.FontWeight = FontWeights.Bold;
            StudentID_TextBox.Margin = new Thickness(4);
            Grid.SetRow(StudentID_TextBox, 1);
            Grid.SetColumn(StudentID_TextBox, 0);
            grid2_1.Children.Add(StudentID_TextBox);

            
            Name_TextBox.FontSize = 18;
            Name_TextBox.FontWeight = FontWeights.Bold;
            Name_TextBox.Margin = new Thickness(4);
            Grid.SetRow(Name_TextBox, 1);
            Grid.SetColumn(Name_TextBox, 1);
            grid2_1.Children.Add(Name_TextBox);

            
            Surname_TextBox.FontSize = 18;
            Surname_TextBox.FontWeight = FontWeights.Bold;
            Surname_TextBox.Margin = new Thickness(4);
            Grid.SetRow(Surname_TextBox, 1);
            Grid.SetColumn(Surname_TextBox, 2);
            grid2_1.Children.Add(Surname_TextBox);


            DeleteStudentID_TextBox.FontSize = 18;
            DeleteStudentID_TextBox.FontWeight = FontWeights.Bold;
            DeleteStudentID_TextBox.Margin = new Thickness(4);
            Grid.SetRow(DeleteStudentID_TextBox, 1);
            Grid.SetColumn(DeleteStudentID_TextBox, 1);
            grid4_1.Children.Add(DeleteStudentID_TextBox);

            Button AddStudent_Btn = new Button();
            AddStudent_Btn.Content = "Add Student";
            AddStudent_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            AddStudent_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            AddStudent_Btn.Margin = new Thickness(10);
            AddStudent_Btn.FontFamily = new FontFamily("Segoe Print");
            AddStudent_Btn.FontSize = 24;
            AddStudent_Btn.FontWeight = FontWeights.Bold;
            AddStudent_Btn.Click += AddStudent_Btn_Click;
            Grid.SetColumn(AddStudent_Btn, 1);
            grid3.Children.Add(AddStudent_Btn);

            Button DeleteStudent_Btn = new Button();
            DeleteStudent_Btn.Content = "Delete Student";
            DeleteStudent_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            DeleteStudent_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            DeleteStudent_Btn.Margin = new Thickness(10);
            DeleteStudent_Btn.FontFamily = new FontFamily("Segoe Print");
            DeleteStudent_Btn.FontSize = 24;
            DeleteStudent_Btn.FontWeight = FontWeights.Bold;
            DeleteStudent_Btn.Click += DeleteStudent_Btn_Click;
            Grid.SetColumn(DeleteStudent_Btn, 1);
            grid5.Children.Add(DeleteStudent_Btn);

            Button MainWin_Btn = new Button();
            MainWin_Btn.Content = "Main Window";
            MainWin_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            MainWin_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MainWin_Btn.Margin = new Thickness(10);
            MainWin_Btn.FontFamily = new FontFamily("Segoe Print");
            MainWin_Btn.FontSize = 24;
            MainWin_Btn.FontWeight = FontWeights.Bold;
            MainWin_Btn.Click += MoveToMainFromSecondBtn_Click; 
            Grid.SetColumn(MainWin_Btn, 0);
            grid6.Children.Add(MainWin_Btn);

            Button OpenFile_Btn = new Button();
            OpenFile_Btn.Content = "Open File";
            OpenFile_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            OpenFile_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            OpenFile_Btn.Margin = new Thickness(10);
            OpenFile_Btn.FontFamily = new FontFamily("Segoe Print");
            OpenFile_Btn.FontSize = 24;
            OpenFile_Btn.FontWeight = FontWeights.Bold;
            OpenFile_Btn.Click += OpenFile_Btn_Click;
            Grid.SetColumn(OpenFile_Btn, 1);
            grid6.Children.Add(OpenFile_Btn);

            grid2.Children.Add(grid2_1);
            grid4.Children.Add(grid4_1);

            mainGrid.Children.Add(grid2);
            mainGrid.Children.Add(grid3);
            mainGrid.Children.Add(grid4);
            mainGrid.Children.Add(grid5);
            mainGrid.Children.Add(grid6);

            Content = mainGrid;
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
            file.Write($"{studID,-15}");
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

