using System;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Diagnostics;


namespace KeystrokeDynamicsAuthentication
{
    /// <summary>
    /// Логика взаимодействия для LearningMode.xaml
    /// </summary>
    public partial class LearningMode : Window
    {

        static string codeword = " ";
        int numOfAttempts;
        static StreamWriter DataFileWriter;
        string filePath;
        public LearningMode(string inputCodeword, string inputFilePath, int InputNumOfAttempts)  
        {
            InitializeComponent();
            filePath = inputFilePath;
            numOfAttempts = InputNumOfAttempts;
            codeword = inputCodeword;
            Attemts_Label.Content = "Number of attempts: " + InputNumOfAttempts;
            CurrentAttemt_Label.Content = "Current attempt: " + attempsCounter;
            InputWord_TextBox.KeyDown += InputWord_TextBox_KeyDown;

            time = new double[codeword.Length - 1, numOfAttempts];
        }

        double[,] time;

        int attempsCounter = 0;

        Stopwatch stopWatch = new Stopwatch();
        int keyDownCount = 0;

        private void InputWord_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            if (keyDownCount < codeword.Length && keyDownCount > 0)
            {
                time[keyDownCount - 1, attempsCounter] = ts.TotalSeconds;
            }
            keyDownCount++;
            InputCheck(Convert.ToString(e.Key));
            AttemptsChecker();
        }

        private void InputCheck(string key)
        {
            if (key == "Return")
            {
                if (InputWord_TextBox.Text == codeword)
                {
                    stopWatch.Stop();
                    attempsCounter++;
                    keyDownCount = 0;
                    MessageBox.Show("Attempt Recorded");           
                }
                else
                {
                    MessageBox.Show("Incorrect Input");
                }
                InputWord_TextBox.Text = "";
                return;
            }
            stopWatch.Restart();
        }

        private void AttemptsChecker()
        {
            if(attempsCounter == numOfAttempts)
            {
                InputWord_TextBox.IsEnabled = false;
                MessageBox.Show("Learning recorded");
                SaveData();
            }
            CurrentAttemt_Label.Content = "Current attempt: " + attempsCounter;
        }

        private void SaveData()
        {
            try
            {
                DataFileWriter = new StreamWriter(filePath, false);
            }
            catch
            {
                MessageBox.Show("Error reading .txt file");
                return;
            }
            DataFileWriter.Write(codeword);
            DataFileWriter.WriteLine();
            for (int i = 0; i < codeword.Length - 1; i++)
            {
                for(int j = 0; j < numOfAttempts; j++)
                {
                    DataFileWriter.Write(time[i, j] + " ");
                }
                DataFileWriter.WriteLine();
            }
            DataFileWriter.Flush();
            DataFileWriter.Close();

        }

        private void ExitFromLM_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

    }
}
