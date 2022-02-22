using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Forms.DataVisualization.Charting;

namespace KeystrokeDynamicsAuthentication
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationMode.xaml
    /// </summary>
    public partial class AuthenticationMode : Window
    {
        public AuthenticationMode()
        {
            InitializeComponent();
            InputWord_TextBox.KeyDown += InputWord_TextBox_KeyDown;
            for(int i = 3; i < 10; i++)
            {
                NumOfAttemps_ComboBox.Items.Add(i);
            }
            for (int i = 1; i < 6; i++)
            {
                Alpha_ComboBox.Items.Add(0.01 * i);
            }

            Alpha_ComboBox.SelectedItem = 0.01;
            NumOfAttemps_ComboBox.SelectedItem = 3;

            Start_Btn.IsEnabled = false;
            InputWord_TextBox.IsEnabled = false;
        }
        MathOperations mathOperations = new MathOperations();
        Stopwatch stopWatch = new Stopwatch();

        string codeword;
        string filePath;

        int keyDownCount = 0;
        int attempsCounter = 0;

        int numOfHomogeneousDispersions;
        int numOfInhomogeneousDispersions;
        double maxDispersion;

        int grossErrors;

        int numOfAttemts;
        int numOfAllAttemts;
        double alpha;

        List<List<double>> inputTimings;    
        List<List<double>> loadTimings;

        private void InputWord_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            if (keyDownCount < codeword.Length && keyDownCount > 0)
            {
                inputTimings[attempsCounter].Add(ts.TotalSeconds);
            }
            keyDownCount++;
            InputCheck(Convert.ToString(e.Key));
        }

        private void InputCheck(string key)
        {
            if (key == "Return")
            {
                if (InputWord_TextBox.Text == codeword)
                {
                    stopWatch.Stop();
                    attempsCounter++;
                    numOfAllAttemts++;
                    keyDownCount = 0;
                    
                    MessageBox.Show("Attempt Recorded");
                    AttemptsChecker();
                }
                else
                {
                    numOfAllAttemts++;
                    MessageBox.Show("Incorrect Input");
                }
                InputWord_TextBox.Text = "";
                return;
            }
            stopWatch.Restart();
        }

        private void AttemptsChecker()
        {
            CurrentAttemt_Label.Content = "Current attempt: " + attempsCounter;
            if (attempsCounter == numOfAttemts)
            {
                InputWord_TextBox.IsEnabled = false;
                grossErrors = 0;

                EleminateGrossErrors();

                if (grossErrors == 1)
                {
                    inputTimings.Add(new List<double>());
                    InputWord_TextBox.IsEnabled = true;
                    attempsCounter--;
                    return;
                }

                double sumOfNormalDistribution = 0;

                for (int i = 0; i < inputTimings.Count; i++)
                {
                    sumOfNormalDistribution += AnalyseTheNormalDistribution(inputTimings[i].ToArray());
                }

                DisplayStatistics(sumOfNormalDistribution);

                return;
            }
            inputTimings.Add(new List<double>());
        }


        private void EleminateGrossErrors()
        {
            for (int i = 0; i < codeword.Length - 1; i++)
            {
                for(int j = 0; j < inputTimings.Count; j++)
                {
                    double[] elements = new double[inputTimings.Count - 1];
                    int l = 0;
                    for(int k = 0; k < inputTimings.Count; k++)
                    {
                        if(k != j)
                        {
                            
                            elements[l] = inputTimings[k][i];
                            l++;
                        }               
                    }


                    if (AnalyseGrossErrors(elements, inputTimings[j][i]) == false)
                    {
                        inputTimings.RemoveAt(j);
                        grossErrors++;
                        MessageBox.Show("Error find");
                        return;
                        
                    }
                }
            }
        }

        private bool AnalyseGrossErrors(double[] elements, double element)
        {
            double expectation = mathOperations.Expectation(elements);
            double dispersion = mathOperations.Dispersion(elements, expectation);
            double standardDeviation = Math.Sqrt(dispersion);
            int degreeOfFreedom = elements.Length;

            double studentCoefficient = mathOperations.StudentCoefficient(element, expectation, standardDeviation, elements.Length);

            var chart = new Chart();
            double tDistribution = chart.DataManipulator.Statistics.InverseTDistribution(2 * alpha, degreeOfFreedom - 1);

            if(studentCoefficient > tDistribution)
            {
                return false;
            }

            return true;
        }

        private double AnalyseTheNormalDistribution(double[] currentAttempt)
        {
            int numOfReferenceAttempts = loadTimings.Count;
            int positiveSolutions = 0;

            for (int i = 0; i < numOfReferenceAttempts; i++)
            {
                double expectationReferenceIntervals = mathOperations.Expectation(loadTimings[i].ToArray());
                double expectationCurrentAttempt = mathOperations.Expectation(currentAttempt);

                double diapersionReferenceIntervals = mathOperations.Dispersion(loadTimings[i].ToArray(), expectationReferenceIntervals);
                double diapersionCurrentAttempt = mathOperations.Dispersion(currentAttempt, expectationCurrentAttempt);

                double standardDeviation = mathOperations.StandardDeviation(diapersionReferenceIntervals, diapersionCurrentAttempt, currentAttempt.Length);

                double studentCoefficient = mathOperations.StudentCoefficient(diapersionReferenceIntervals, diapersionCurrentAttempt, standardDeviation, currentAttempt.Length);

                double Fisherfficient = 0;

                Chart chart = new Chart();
                double TableStudentCoefficient = chart.DataManipulator.Statistics.InverseTDistribution(2 * alpha, currentAttempt.Length - 1);
                double TableFisherfficient = chart.DataManipulator.Statistics.InverseFDistribution(2 * alpha, currentAttempt.Length, currentAttempt.Length);

                MessageBox.Show(studentCoefficient + " " + TableStudentCoefficient);

                if(studentCoefficient <= TableStudentCoefficient) { positiveSolutions++; }

                if (diapersionReferenceIntervals > diapersionCurrentAttempt) { TableFisherfficient = diapersionReferenceIntervals / diapersionCurrentAttempt; }
                else { Fisherfficient = diapersionCurrentAttempt / diapersionReferenceIntervals; }

                if (Fisherfficient > TableFisherfficient) { numOfInhomogeneousDispersions++; }
                else { numOfHomogeneousDispersions++; }
            }

            double probabilityOfCorrectInput = (double)positiveSolutions / numOfReferenceAttempts;
            MessageBox.Show(positiveSolutions + " / " + numOfReferenceAttempts + " = " + probabilityOfCorrectInput);
            return probabilityOfCorrectInput;
        }

        private void DisplayStatistics(double sumOfNormalDistribution)
        {
            double probabilityOfCorrectInput = sumOfNormalDistribution / inputTimings.Count;
            PIdentification_Label.Content = "P identification: " + (int)(probabilityOfCorrectInput * 100) + "%";

            if (numOfHomogeneousDispersions >= numOfInhomogeneousDispersions) { Dispercion_Label.Content = "Dispersions: homogeneous"; }
            else { Dispercion_Label.Content = "Dispersions: inhomogeneous"; }

            Type1Errors_Label.Content = "Type II Errors: " + ((((double)numOfAllAttemts - numOfAttemts) / numOfAllAttemts) * 100) + "%";
            Type2Errors_Label.Content = "Type II Errors: " + (((double)numOfAttemts / numOfAllAttemts) * 100) + "%";

            if (probabilityOfCorrectInput > 0.6)
            {
                RewriteReferences();
            }
        }
        private void RewriteReferences()
        {
            StreamWriter DataFileWriter;
            try
            {
                DataFileWriter = new StreamWriter(filePath, false);
            }
            catch
            {
                MessageBox.Show("Error reading .txt file");
                return;
            }

            DataFileWriter.WriteLine(codeword);
            DataFileWriter.WriteLine();
            for (int i = 0; i < codeword.Length - 1; i++)
            {
                for (int j = 0; j < inputTimings.Count; j++)
                {
                    DataFileWriter.Write(inputTimings[j][i] + " ");
                }
                DataFileWriter.WriteLine();
            }
            DataFileWriter.Flush();
            DataFileWriter.Close();
        }

        private void MainWindow_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void Start_Btn_Click(object sender, RoutedEventArgs e)
        {
            attempsCounter = 0;
            numOfAllAttemts = 0;

            numOfAttemts = Convert.ToInt16(NumOfAttemps_ComboBox.SelectedItem);
            alpha = Convert.ToDouble(Alpha_ComboBox.SelectedItem);

            CurrentAttemt_Label.Content = "Current attempt: " + attempsCounter;
            PIdentification_Label.Content = "P identification: ";
            Type1Errors_Label.Content = "Type II Errors: ";
            Type2Errors_Label.Content = "Type II Errors: ";
            Dispercion_Label.Content = "Dispersions: ";

            inputTimings = new List<List<double>>(Convert.ToInt16(NumOfAttemps_ComboBox.SelectedItem));
            inputTimings.Add(new List<double>());

            InputWord_TextBox.IsEnabled = true;
        }

        private void LoadData_Btn_Click(object sender, RoutedEventArgs e)
        {
            StreamReader DataFile;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                DataFile = new StreamReader(filePath);

                codeword = DataFile.ReadLine();
                Codeword_Label.Content = "Codeword: " + codeword;

                loadTimings = new List<List<double>>();
                
                Start_Btn.IsEnabled = true;

                int j = 0;
                while (!DataFile.EndOfStream)
                {
                    loadTimings.Add(new List<double>());
                    string[] Line = DataFile.ReadLine().Split(' ');
                    for (int i = 0; i < Line.Length - 1; i++)
                    {
                        loadTimings[j].Add(Convert.ToDouble(Line[i]));
                    }
                    j++;
                }
            }
        }

    }
    
}
