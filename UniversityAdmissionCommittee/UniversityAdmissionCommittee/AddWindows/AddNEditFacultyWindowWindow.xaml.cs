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
using System.Data;
using System.Text.RegularExpressions;

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for AddNEditFacultyWindowWindow.xaml
    /// </summary>
    public partial class AddNEditFacultyWindowWindow : Window
    {
        string idFaculty;

        string firstSubID;
        string secondSubID;
        string thirdSubID;

        public AddNEditFacultyWindowWindow()
        {
            InitializeComponent();
            FillSubjectComboBoxes();
            firstSubjectComboBox.SelectedIndex = 0;
            secondSubjectComboBox.SelectedIndex = 1;
            thirdSubjectComboBox.SelectedIndex = 2;
            SetAddButton();
            this.Title = "Додати факультет";
        }

        public AddNEditFacultyWindowWindow(string facultyName)
        {
            InitializeComponent();
            FillSubjectComboBoxes();
            idFaculty = SQLSelectQueries.GetFacultyID(facultyName);
            FillFacultyData(idFaculty, facultyName);
            SetSaveButton();
            this.Title = "Редагувати інформацію про факультет";
        }

        private void FillSubjectComboBoxes()
        {
            DataTable subjectsTable = SQLSelectQueries.GetAllSubjects();
            for (int i = 0; i < subjectsTable.Rows.Count; i++)
            {
                firstSubjectComboBox.Items.Add(subjectsTable.Rows[i]["SubjectName"].ToString());
                secondSubjectComboBox.Items.Add(subjectsTable.Rows[i]["SubjectName"].ToString());
                thirdSubjectComboBox.Items.Add(subjectsTable.Rows[i]["SubjectName"].ToString());
            }
        }
        private void FillFacultyData(string idFacuty, string facultyName)
        {
            facultyNameTextBox.Text = facultyName;

            DataTable facultySubjectsTable = SQLSelectQueries.GetNecessaryFacultySubjects(idFacuty);

            firstSubjectComboBox.SelectedItem = facultySubjectsTable.Rows[0]["SubjectName"].ToString();
            firstSubCoefTextBox.Text = facultySubjectsTable.Rows[0]["Coefficient"].ToString();

            facultySubjectsTable = SQLSelectQueries.GetUnnecessaryFacultySubjects(idFacuty);

            secondSubjectComboBox.SelectedItem = facultySubjectsTable.Rows[0]["SubjectName"].ToString();
            secondSubCoefTextBox.Text = facultySubjectsTable.Rows[0]["Coefficient"].ToString();
            thirdSubjectComboBox.SelectedItem = facultySubjectsTable.Rows[1]["SubjectName"].ToString();
            thirdSubCoefTextBox.Text = facultySubjectsTable.Rows[1]["Coefficient"].ToString();

            firstSubID = SQLSelectQueries.GetSubjectID(firstSubjectComboBox.SelectedItem.ToString());
            secondSubID = SQLSelectQueries.GetSubjectID(secondSubjectComboBox.SelectedItem.ToString()); 
            thirdSubID = SQLSelectQueries.GetSubjectID(thirdSubjectComboBox.SelectedItem.ToString());
        }

        private void SetSaveButton()
        {
            saveButton.Content = "Зберегти";
            saveButton.Click += SaveButton_Click;
        }

        private void SetAddButton()
        {
            saveButton.Content = "Додати";
            saveButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                SQLInsertQueries.InsertFaculty(facultyNameTextBox.Text);
                AddFacultySubjects();
                MessageBox.Show("Факультет додано до бази");
            }
           
        }

        private void AddFacultySubjects()
        {
            string firstSubID = SQLSelectQueries.GetSubjectID(firstSubjectComboBox.SelectedItem.ToString());
            string secondSubID = SQLSelectQueries.GetSubjectID(secondSubjectComboBox.SelectedItem.ToString());
            string thirdSubID = SQLSelectQueries.GetSubjectID(thirdSubjectComboBox.SelectedItem.ToString());

            string idFaculty = SQLSelectQueries.GetFacultyID(facultyNameTextBox.Text);

            SQLInsertQueries.InsertFacultySubject(idFaculty, firstSubID, "1", firstSubCoefTextBox.Text);
            SQLInsertQueries.InsertFacultySubject(idFaculty, secondSubID, "0", secondSubCoefTextBox.Text);
            SQLInsertQueries.InsertFacultySubject(idFaculty, thirdSubID, "0", thirdSubCoefTextBox.Text);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                SQLUpdateQueries.UpdateFacultyData(idFaculty, facultyNameTextBox.Text);
                UpdateFacultySubjects();
                UpdateSubjectsCoeficients();
                MessageBox.Show("Зміни збережено");
            }     
        }
        private void UpdateFacultySubjects()
        {
            string newFirstSubID = SQLSelectQueries.GetSubjectID(firstSubjectComboBox.SelectedItem.ToString());
            string newSecondSubID = SQLSelectQueries.GetSubjectID(secondSubjectComboBox.SelectedItem.ToString());
            string newThirdSubID = SQLSelectQueries.GetSubjectID(thirdSubjectComboBox.SelectedItem.ToString());

            SQLUpdateQueries.UpdateFacultySubjects(idFaculty, newFirstSubID, firstSubID);
            SQLUpdateQueries.UpdateFacultySubjects(idFaculty, newSecondSubID, secondSubID);
            SQLUpdateQueries.UpdateFacultySubjects(idFaculty, newThirdSubID, thirdSubID);
        }

        private void UpdateSubjectsCoeficients()
        {
            string firstSubID = SQLSelectQueries.GetSubjectID(firstSubjectComboBox.SelectedItem.ToString());
            string secondSubID = SQLSelectQueries.GetSubjectID(secondSubjectComboBox.SelectedItem.ToString());
            string thirdSubID = SQLSelectQueries.GetSubjectID(thirdSubjectComboBox.SelectedItem.ToString());

            SQLUpdateQueries.UpdatSubjectsCoefficient(idFaculty, firstSubID, firstSubCoefTextBox.Text);
            SQLUpdateQueries.UpdatSubjectsCoefficient(idFaculty, secondSubID, secondSubCoefTextBox.Text);
            SQLUpdateQueries.UpdatSubjectsCoefficient(idFaculty, thirdSubID, thirdSubCoefTextBox.Text);
        }

        private bool CheckInput()
        {
            if(facultyNameTextBox.Text == "")
            {
                MessageBox.Show("Всі поля мають бути заповені");
                return false;
            }
            if ((firstSubjectComboBox.SelectedIndex == secondSubjectComboBox.SelectedIndex) ||
                (firstSubjectComboBox.SelectedIndex == thirdSubjectComboBox.SelectedIndex) ||
                  (thirdSubjectComboBox.SelectedIndex == secondSubjectComboBox.SelectedIndex))
            {
                MessageBox.Show("Предмети співпадають");
                return false;
            }
            double coefSum = Convert.ToDouble(firstSubCoefTextBox.Text) + Convert.ToDouble(secondSubCoefTextBox.Text) + Convert.ToDouble(thirdSubCoefTextBox.Text);
            if (coefSum != 1)
            {
                MessageBox.Show("Cума коефіцієнтів повинна бути 1");
                return false;
            }
            return true;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;

            if (!textBox.Text.StartsWith("0,"))
            {
                textBox.Text = "0,";
                textBox.Select(textBox.Text.Length, 0);
            }
            Regex regex = new Regex("[^0-9]{1}");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
