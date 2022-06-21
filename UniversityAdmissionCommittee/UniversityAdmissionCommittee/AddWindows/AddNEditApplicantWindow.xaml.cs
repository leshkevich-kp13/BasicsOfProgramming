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

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for AddApplicantWindow.xaml
    /// </summary>
    public partial class AddNEditApplicantWindow : Window
    {
        string idApplicant;
        string selectedApplicantDepartment;

        public AddNEditApplicantWindow()
        {
            InitializeComponent();
            FillApplicantMedalCB();
            FillFacultyNameComboBox();
            SetAddApplicantButton();
            this.Title = "Додати абітурієнта";
        }
        public AddNEditApplicantWindow(string applicantID)
        {
            InitializeComponent();
            FillApplicantMedalCB();
            FillFacultyNameComboBox();
            FillApplicantData(applicantID);
            SetSaveChangesButton();
            this.Title = "Редагувати інформацію про абітурієнта";
        }
        private void FillApplicantMedalCB()
        {
            medalComboBox.Items.Add("Відсутня");
            medalComboBox.Items.Add("Золота");
            medalComboBox.Items.Add("Срібна");
        }

        private void FillApplicantData(string applicantID)
        {
            DataTable applicantInfo = SQLSelectQueries.GetAllApplicantData(applicantID);
            surnameTextBox.Text = applicantInfo.Rows[0]["Surname"].ToString();
            nameTextBox.Text = applicantInfo.Rows[0]["Name"].ToString();
            middleNameTextBox.Text = applicantInfo.Rows[0]["MiddleName"].ToString();
            passportDataTextBox.Text = applicantInfo.Rows[0]["PassportData"].ToString();
            educationInstitutionTextBox.Text = applicantInfo.Rows[0]["EducationInstitution"].ToString();
            graduationDateDatePicker.Text = applicantInfo.Rows[0]["GraduationDate"].ToString();
            medalComboBox.SelectedItem = applicantInfo.Rows[0]["Medal"].ToString();
            facultyComboBox.SelectedItem = applicantInfo.Rows[0]["FacultyName"].ToString();
            departmentComboBox.SelectedItem = applicantInfo.Rows[0]["DepartmentName"].ToString();

            idApplicant = applicantID;
            selectedApplicantDepartment = departmentComboBox.SelectedItem.ToString();
        }

        private void FillFacultyNameComboBox()
        {
            DataTable facultyTable =  SQLSelectQueries.GetAllFacultiesNames();
            for (int i = 0; i < facultyTable.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(facultyTable.Rows[i]["FacultyName"].ToString());
            }
            facultyComboBox.SelectionChanged += FacultyNameComboBox_SelectionChanged;
            facultyComboBox.SelectedIndex = 0;
        }

        private void FillDepartmentNameComboBox(string facultyName)
        {
            DataTable departmentTable =  SQLSelectQueries.GetDepartmentsNames(facultyName);
            for (int i = 0; i < departmentTable.Rows.Count; i++)
            {
                departmentComboBox.Items.Add(departmentTable.Rows[i]["DepartmentName"].ToString());
            }
        }

        private void FacultyNameComboBox_SelectionChanged(object sender, EventArgs e)
        {
            departmentComboBox.Items.Clear();
            departmentComboBox.SelectedIndex = 0;
            FillDepartmentNameComboBox(facultyComboBox.SelectedItem.ToString());
        }

        private void SetSaveChangesButton()
        {
            saveButton.Content = "Зберегти зміни";
            saveButton.Click += SaveButton_Click;
        }

        private void SetAddApplicantButton()
        {
            saveButton.Content = "Додати абітурієнта";
            saveButton.Click += AddApplicantButton_Click;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                MessageBox.Show("Всі поля мають бути заповнені");
                return;
            }
            UpdateApplicantInfo();
            UpdateApplicantGroup();
            UpdateApplicantSubjects();
            SetApplicantMarks(idApplicant);
            SQLUpdateQueries.UpdateTotalMark(idApplicant);
            MessageBox.Show("Зміни збережено");
        }

        private void UpdateApplicantInfo()
        {
            string idDepartment = SQLSelectQueries.GetDepartmentID(departmentComboBox.SelectedItem.ToString());

            SQLUpdateQueries.UpdateApplicantData(idApplicant, surnameTextBox.Text, nameTextBox.Text, middleNameTextBox.Text, passportDataTextBox.Text,
                 educationInstitutionTextBox.Text, graduationDateDatePicker.Text, medalComboBox.SelectedItem.ToString(), idDepartment);
        }

        private void UpdateApplicantGroup()
        {
            string idDepartmentChanged = SQLSelectQueries.GetDepartmentID(departmentComboBox.SelectedItem.ToString());
            string idDepartment = SQLSelectQueries.GetDepartmentID(selectedApplicantDepartment);

            if (idDepartmentChanged != idDepartment)
            {
                string idGroup = SQLSelectQueries.GetLastDepartmentGroupIndex(departmentComboBox.SelectedItem.ToString());

                if (SQLSelectQueries.GetNumberOfGroupApplicants(idGroup) == 20)
                {
                    AddNewGroup(departmentComboBox.SelectedItem.ToString());
                }
                idGroup = SQLSelectQueries.GetLastDepartmentGroupIndex(departmentComboBox.SelectedItem.ToString());
                SQLUpdateQueries.UpdateApplicantGroup(idApplicant, idGroup);
            }     
        }

        private void UpdateApplicantSubjects()
        {
            string[] subjectsID = new string[3];

            SQLSelectQueries.GetFacultySubjectsID(facultyComboBox.SelectedItem.ToString(), subjectsID);
            SQLInsertQueries.DeleteApplicantSubject(idApplicant);
            for (int i = 0; i < 3; i++)
            {
                SQLInsertQueries.InsertSubjectsForMarks(idApplicant, subjectsID[i]);
            }
        }

        private void AddApplicantButton_Click(object sender, RoutedEventArgs e)
        {       
            if(CheckInput() == false)
            {
                MessageBox.Show("Всі поля мають бути заповнені");
                return;
            }
            AddApplicant();
            string idApplicant = SQLSelectQueries.GetMaxIDApplicant();
            AddApplicantGroup(idApplicant);
            AddSubjectsForMarks(idApplicant);
            SetApplicantMarks(idApplicant);
            SQLInsertQueries.InsertTotalMarkApplicantColumn(idApplicant);
            SQLUpdateQueries.UpdateTotalMark(idApplicant);
            MessageBox.Show("Абітурієнт був доданий до бази даних");
        }

        private void AddApplicant()
        {
            string idDepartment = SQLSelectQueries.GetDepartmentID(departmentComboBox.SelectedItem.ToString());
            SQLInsertQueries.InsertApplicant(surnameTextBox.Text, nameTextBox.Text, middleNameTextBox.Text, passportDataTextBox.Text,
                educationInstitutionTextBox.Text, graduationDateDatePicker.Text, medalComboBox.SelectedItem.ToString(), idDepartment);
        }

        private void AddApplicantGroup(string idApplicant)
        {
            string idGroup = SQLSelectQueries.GetLastDepartmentGroupIndex(departmentComboBox.SelectedItem.ToString());

            if (SQLSelectQueries.GetNumberOfGroupApplicants(idGroup) >= 20)
            {
                string idDepartment = SQLSelectQueries.GetDepartmentID(departmentComboBox.SelectedItem.ToString());
                AddNewGroup(idDepartment);
            }

            idGroup = SQLSelectQueries.GetLastDepartmentGroupIndex(departmentComboBox.SelectedItem.ToString());
            SQLInsertQueries.InsertApplicantGroup(idApplicant, idGroup);
        }

        private void AddSubjectsForMarks(string idApplicant)
        {
            string[] subjectsID = new string[3];

            SQLSelectQueries.GetFacultySubjectsID(facultyComboBox.SelectedItem.ToString(), subjectsID);

            for(int i = 0; i < 3; i++)
            {
                SQLInsertQueries.InsertSubjectsForMarks(idApplicant, subjectsID[i]);
            }
        }

        private void SetApplicantMarks(string idApplicant)
        {
            if(medalComboBox.SelectedIndex == 1)
            {           
                SQLUpdateQueries.SetMarksForGoldenMedal(idApplicant);
            }
        }

        private void AddNewGroup(string idDepartment)
        {         
            string groupName = SQLSelectQueries.GetDepartmentGroupName(idDepartment) +"-"+ (SQLSelectQueries.GetNumberOfDepartmentGroups(idDepartment) + 1);
            SQLInsertQueries.InsertNewGroup(groupName, idDepartment);
            string[] facultySubjectsID = new string[3];
            SQLSelectQueries.GetFacultySubjectsID(facultyComboBox.SelectedItem.ToString(), facultySubjectsID);

            string idGroup = SQLSelectQueries.GetIDGroup(groupName);

            for (int i = 0; i < 3; i++)
            {
                SQLInsertQueries.InsertExams(idGroup, facultySubjectsID[i]);
            }
        } 

        private bool CheckInput()
        {
            if(surnameTextBox.Text == "" || nameTextBox.Text == "" || middleNameTextBox.Text == "" || passportDataTextBox.Text == "" ||
                educationInstitutionTextBox.Text == "" || graduationDateDatePicker.Text == " ")
            {
                return false;
            }
            return true;
        }
    }
}
