using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Text.RegularExpressions;

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for AddNEditDepartmentWindow.xaml
    /// </summary>
    public partial class AddNEditDepartmentWindow : Window
    {
        string idDepartment;
        string facultyName;
        string groupName;


        public AddNEditDepartmentWindow()
        {
            InitializeComponent();
            FillFacultyNameComboBox();
            SetAddButton();
            this.Title = "Додати кафедру";
        }

        public AddNEditDepartmentWindow(string departmentName)
        {
            InitializeComponent();
            this.idDepartment = SQLSelectQueries.GetDepartmentID(departmentName);
            FillFacultyNameComboBox();
            FillDepartmentData(departmentName);
            SetSaveChangesButton();
            this.Title = "Редагувати інформацію про кафедру";
        }

        private void SetSaveChangesButton()
        {
            saveButton.Content = "Зберегти";
            saveButton.Click += SaveButton_Click;
        }

        private void SetAddButton()
        {
            saveButton.Content = "Додати";
            saveButton.Click += AddButton_Click;
        }

        private void FillFacultyNameComboBox()
        {
            DataTable facultyTable = SQLSelectQueries.GetAllFacultiesNames();
            for (int i = 0; i < facultyTable.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(facultyTable.Rows[i]["FacultyName"].ToString());
            }
            facultyComboBox.SelectedIndex = 0;
        }

        private void FillDepartmentData(string departmentName)
        {
            DataTable departmentTable = SQLSelectQueries.GetDepartmentData(departmentName);
            departmentNameTextBox.Text = departmentTable.Rows[0]["DepartmentName"].ToString();
            facultyComboBox.SelectedItem = departmentTable.Rows[0]["FacultyName"].ToString();
            groupsNameTextBox.Text = departmentTable.Rows[0]["DepartmentGroupName"].ToString();
            studentsNumberTextBox.Text = departmentTable.Rows[0]["NumberOfStudents"].ToString();

            groupName = departmentTable.Rows[0]["DepartmentGroupName"].ToString();
            facultyName = departmentTable.Rows[0]["FacultyName"].ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(CheckInput() == false)
            {
                MessageBox.Show("Всі поля мають бути заповені");
                return;
            }
            SQLUpdateQueries.UpdateDepartmentInfo(idDepartment, departmentNameTextBox.Text, groupsNameTextBox.Text, studentsNumberTextBox.Text);
            ChangeFaculty();
            SQLUpdateQueries.UpdateDepartmentGroupsName(groupsNameTextBox.Text, groupName);
            MessageBox.Show("Зміни збережено");
        }

        private void ChangeFaculty()
        {
            if (facultyComboBox.SelectedItem.ToString() != facultyName)
            {
                SQLUpdateQueries.UpdateDepartmentFaculty(idDepartment, SQLSelectQueries.GetFacultyID(facultyComboBox.SelectedItem.ToString()));
                ChangeDepartmentApplicantsSubjects();
            }
        }

        private void ChangeDepartmentApplicantsSubjects()
        {
            string idFaculty = SQLSelectQueries.GetFacultyID(facultyName);
            string idNewFaculty = SQLSelectQueries.GetFacultyID(facultyComboBox.SelectedItem.ToString());

            string idNecessarySubject = SQLSelectQueries.GetNecessaryIDSubject(idFaculty);
            string idNewNecessarySubject = SQLSelectQueries.GetNecessaryIDSubject(idNewFaculty);

            DataTable idUnnecessarySubjects = SQLSelectQueries.GetUnnecessaryIDSubjects(idFaculty);
            DataTable idNewUnnecessarySubjects = SQLSelectQueries.GetUnnecessaryIDSubjects(idNewFaculty);

            SQLUpdateQueries.UpdateStudentNecessarySubjects(idNecessarySubject, idNewNecessarySubject, idDepartment, idNewFaculty);
            SQLUpdateQueries.UpdateStudentUnnecessarySubjects(idUnnecessarySubjects.Rows[0]["IDSubject"].ToString(), idNewUnnecessarySubjects.Rows[0]["IDSubject"].ToString(), idDepartment, idNewFaculty);
            SQLUpdateQueries.UpdateStudentUnnecessarySubjects(idUnnecessarySubjects.Rows[1]["IDSubject"].ToString(), idNewUnnecessarySubjects.Rows[1]["IDSubject"].ToString(), idDepartment, idNewFaculty);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                MessageBox.Show("Всі поля мають бути заповені");
                return;
            }
            string idNewFaculty = SQLSelectQueries.GetFacultyID(facultyComboBox.SelectedItem.ToString());

            SQLInsertQueries.InsertDepartment(departmentNameTextBox.Text, idNewFaculty, groupsNameTextBox.Text, studentsNumberTextBox.Text);
            AddNewGroup();
            MessageBox.Show("Кафедру додано до бази");
        }
        private void AddNewGroup()
        {
            SQLInsertQueries.InsertNewGroup((groupsNameTextBox.Text + "-1"), SQLSelectQueries.GetDepartmentID(departmentNameTextBox.Text));
            string[] facultySubjectsID = new string[3];
            SQLSelectQueries.GetFacultySubjectsID(facultyComboBox.SelectedItem.ToString(), facultySubjectsID);

            string idGroup = SQLSelectQueries.GetIDGroup(groupsNameTextBox.Text + "-1");

            for (int i = 0; i < 3; i++)
            {
                SQLInsertQueries.InsertExams(idGroup, facultySubjectsID[i]);
            }
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool CheckInput()
        {
            if (departmentNameTextBox.Text == "" || groupsNameTextBox.Text == "" || studentsNumberTextBox.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}
