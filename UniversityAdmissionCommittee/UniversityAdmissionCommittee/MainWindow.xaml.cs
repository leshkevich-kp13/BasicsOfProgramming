using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Windows.Input;
using System.Data;
using System.Text.RegularExpressions;

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SearchApplicantPage searchApplicantPage = new SearchApplicantPage();
        SearchDepartmentPage searchDepartmentPage = new SearchDepartmentPage();
        DetailedApplicantInfoPage detailedApplicantInfoPage = new DetailedApplicantInfoPage();
        DetailedDepartmentInfoPage detailedDepartmentInfoPage = new DetailedDepartmentInfoPage();
        SearchSchedulePage searchSchedulePage = new SearchSchedulePage();
        SearchEnlistedApplicantsPage searchEnlistedApplicantsPage = new SearchEnlistedApplicantsPage();
        SearchMarksPage SearchMarksPage = new SearchMarksPage();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowInfoModeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            switch (showInfoModeComboBox.SelectedIndex)
            {
                case 0:
                    SetApplicantsButtons();
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetApplicantData().DefaultView;
                    informationDataGrid.IsReadOnly = true;
                    searchFrame.Content = null;
                    detailedInfoFrame.Content = null;
                    searchFrame.Navigate(searchApplicantPage);
                    detailedInfoFrame.Navigate(detailedApplicantInfoPage);
                    break;
                case 1:
                    SetFacultiesNDepartmentsButtons();
                    informationDataGrid.IsReadOnly = true;
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetDepartmentsAndFacultiesData().DefaultView;
                    searchFrame.Content = null;
                    detailedInfoFrame.Content = null;
                    searchFrame.Navigate(searchDepartmentPage);
                    detailedInfoFrame.Navigate(detailedDepartmentInfoPage);                  
                    break;
                case 2:
                    SetMarksButtons();
                    informationDataGrid.IsReadOnly = false;
                    informationDataGrid.CellEditEnding += DataGrid_CellValueChanged;
                    informationDataGrid.PreviewTextInput += PreviewTextInput;
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetMarks().DefaultView;
                    informationDataGrid.Columns[0].IsReadOnly = true;
                    informationDataGrid.Columns[1].IsReadOnly = true;
                    informationDataGrid.Columns[2].IsReadOnly = true;
                    informationDataGrid.Columns[3].IsReadOnly = true;
                    informationDataGrid.Columns[4].IsReadOnly = true;
                    informationDataGrid.Columns[5].IsReadOnly = true;
                    informationDataGrid.Columns[6].IsReadOnly = false;
                    detailedInfoFrame.Content = null;
                    searchFrame.Navigate(SearchMarksPage);
                    break;
                case 3:
                    SetScheduleButtons();
                    informationDataGrid.IsReadOnly = true;
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetScheduleData().DefaultView;
                    searchFrame.Navigate(searchSchedulePage);
                    detailedInfoFrame.Content = null;
                    break;
                case 4:
                    SetEnlistedButtons();
                    informationDataGrid.IsReadOnly = true;
                    searchFrame.Navigate(searchEnlistedApplicantsPage);
                    detailedApplicantInfoPage.Content = null;
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetEnlistedApplicants(searchEnlistedApplicantsPage.Department).DefaultView;
                    break;

            }
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DataGrid_CellValueChanged( object sender, DataGridCellEditEndingEventArgs e)
        {
            string idApplicant = "";
            string subjectName = "";
            foreach (DataRowView row in informationDataGrid.SelectedItems)
            {
                DataRow MyRow = row.Row;
                idApplicant = MyRow[0].ToString();
                subjectName = MyRow[5].ToString();
            }
            
            if (idApplicant != "") 
            {
                TextBox mark = e.EditingElement as TextBox;        
                SQLUpdateQueries.UpdateMark(idApplicant, subjectName, mark.Text);
                SQLUpdateQueries.UpdateTotalMark(idApplicant); 
            }    
        }

        private void SetApplicantsButtons()
        {
            firstEditButton.Visibility = Visibility.Hidden;
            secondEditButton.Visibility = Visibility.Visible;
            secondEditButton.IsEnabled = false;
            secondEditButton.Content = "Редагувати";

            firstDeleteButton.Visibility = Visibility.Visible;
            secondDeleteButton.Visibility= Visibility.Hidden;
            firstDeleteButton.IsEnabled = false;
            firstDeleteButton.Content = "Видалити абітурієнта";

            firstAddButton.Visibility = Visibility.Visible;
            secondAddButton.Visibility = Visibility.Hidden;
            firstAddButton.Content = "Додати абітурієнта";

        }

        private void SetFacultiesNDepartmentsButtons()
        {
            firstEditButton.Visibility = Visibility.Visible;
            secondEditButton.Visibility = Visibility.Visible;
            secondEditButton.IsEnabled = false;
            firstEditButton.IsEnabled = false;
            firstEditButton.Content = "Редагувати факультет";
            secondEditButton.Content = "Редагувати кафедру";

            firstDeleteButton.Visibility = Visibility.Visible;
            secondDeleteButton.Visibility = Visibility.Visible;
            firstDeleteButton.IsEnabled = false;
            secondDeleteButton.IsEnabled = false;
            firstDeleteButton.Content = "Видалити кафедру";
            secondDeleteButton.Content = "Видалити факультет";

            firstAddButton.Visibility = Visibility.Visible;
            secondAddButton.Visibility = Visibility.Visible;
            firstAddButton.Content = "Додати кафедру";
            secondAddButton.Content = "Додати факультет";
        }

        private void SetMarksButtons()
        {
            firstEditButton.Visibility = Visibility.Hidden;
            secondEditButton.Visibility = Visibility.Hidden;

            firstDeleteButton.Visibility = Visibility.Hidden;
            secondDeleteButton.Visibility = Visibility.Hidden;

            firstAddButton.Visibility = Visibility.Hidden;
            secondAddButton.Visibility = Visibility.Hidden;
        }

        private void SetScheduleButtons()
        {
            firstEditButton.Visibility = Visibility.Hidden;
            secondEditButton.Visibility = Visibility.Visible;
            secondEditButton.Content = "Редагувати";

            firstDeleteButton.Visibility = Visibility.Hidden;
            secondDeleteButton.Visibility = Visibility.Hidden;

            firstAddButton.Visibility = Visibility.Hidden;
            secondAddButton.Visibility = Visibility.Hidden;
        }

        private void SetEnlistedButtons()
        {
            firstEditButton.Visibility = Visibility.Hidden;
            secondEditButton.Visibility = Visibility.Hidden;

            firstDeleteButton.Visibility = Visibility.Hidden;
            secondDeleteButton.Visibility = Visibility.Hidden;

            firstAddButton.Visibility = Visibility.Hidden;
            secondAddButton.Visibility = Visibility.Hidden;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            switch (showInfoModeComboBox.SelectedIndex)
            {
                case 0:
                    string idApplicant = searchApplicantPage.IDApplicant;
                    string surname = searchApplicantPage.Surname;
                    string name = searchApplicantPage.Name;
                    string middleName = searchApplicantPage.MiddleName;
                    string facultyName = searchApplicantPage.Faculty;
                    string departmentName = searchApplicantPage.Department;
                    string groupName = searchApplicantPage.Group;
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetApplicantData(idApplicant, surname, name,
                       middleName, facultyName, departmentName, groupName).DefaultView;
                    break;
                case 1:
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetDepartmentsAndFacultiesData(searchDepartmentPage.Faculty).DefaultView;
                    break;
                case 2:
                    idApplicant = SearchMarksPage.IDApplicant;
                    surname = SearchMarksPage.Surname;
                    name = SearchMarksPage.Name;
                    middleName = SearchMarksPage.MiddleName;
                    facultyName = SearchMarksPage.Faculty;
                    departmentName = SearchMarksPage.Department;
                    groupName = SearchMarksPage.Group;
                    string subjectName = SearchMarksPage.Subject;
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetMarks(idApplicant, surname, name, middleName, groupName,
                        subjectName, facultyName, departmentName).DefaultView;
                    break;
                case 3:
                    subjectName = searchSchedulePage.Subject;
                    facultyName = searchSchedulePage.Faculty;
                    departmentName = searchSchedulePage.Department;
                    groupName = searchSchedulePage.Group;               
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetScheduleData(facultyName, departmentName, groupName, subjectName).DefaultView;
                    break;
                case 4:
                    departmentName = searchEnlistedApplicantsPage.Department;
                    informationDataGrid.ItemsSource = SQLSelectQueries.GetEnlistedApplicants(departmentName).DefaultView;
                    break;
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {            
            searchApplicantPage = new SearchApplicantPage();
            searchDepartmentPage = new SearchDepartmentPage();
            detailedApplicantInfoPage = new DetailedApplicantInfoPage();
            detailedDepartmentInfoPage = new DetailedDepartmentInfoPage();
            searchSchedulePage = new SearchSchedulePage();
            searchEnlistedApplicantsPage = new SearchEnlistedApplicantsPage();
            SearchMarksPage = new SearchMarksPage();

            ShowInfoModeComboBox_SelectionChanged(sender, e);

            SearchButton_Click(sender, e);
        }

        private void InformationDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            firstEditButton.IsEnabled = false;
            secondEditButton.IsEnabled = false;
            switch (showInfoModeComboBox.SelectedIndex)
            {
                case 0:                 
                    string applicantID = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        applicantID = MyRow[0].ToString();              
                    }
                    if(applicantID != "") 
                    {
                        firstDeleteButton.IsEnabled = true;
                        secondEditButton.IsEnabled = true;
                        DisplayDetailedApplicantInfo(applicantID);
                        break;
                    }
                    firstEditButton.IsEnabled = false;
                    secondEditButton.IsEnabled = false;
                    break;
                case 1:
                    string departmentName = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        departmentName = MyRow[1].ToString();
                    }
                    if (departmentName != "") 
                    {
                        firstDeleteButton.IsEnabled = true;
                        secondDeleteButton.IsEnabled = true;
                        secondDeleteButton.IsEnabled = true;
                        firstDeleteButton.IsEnabled = true;
                        firstEditButton.IsEnabled = true;
                        secondEditButton.IsEnabled = true;
                        DisplayDetailedDepartment(departmentName);
                        break;
                    }
                    secondDeleteButton.IsEnabled = false;
                    firstDeleteButton.IsEnabled = false;

                    firstEditButton.IsEnabled = false;
                    secondEditButton.IsEnabled = false;
                    break;
                case 3:
                    string groupName = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        groupName = MyRow[0].ToString();
                    }
                    if (groupName != "")
                    {
                        firstEditButton.IsEnabled = true;
                        secondEditButton.IsEnabled = true;
                        break;
                    }
                    firstEditButton.IsEnabled = false;
                    secondEditButton.IsEnabled = false;
                    break;
            }
        }

        private void DisplayDetailedApplicantInfo(string applicantID)
        {
            DataTable infoTable = SQLSelectQueries.GetAllApplicantData(applicantID);
            detailedApplicantInfoPage.IDApplicant = infoTable.Rows[0]["IDApplicant"].ToString();
            detailedApplicantInfoPage.Surmane = infoTable.Rows[0]["Surname"].ToString();
            detailedApplicantInfoPage.Name = infoTable.Rows[0]["Name"].ToString();
            detailedApplicantInfoPage.MiddleName = infoTable.Rows[0]["MiddleName"].ToString();
            detailedApplicantInfoPage.PassportData = infoTable.Rows[0]["PassportData"].ToString();
            detailedApplicantInfoPage.EducationInstitution = infoTable.Rows[0]["EducationInstitution"].ToString();
            detailedApplicantInfoPage.GraduationDate = Convert.ToDateTime(infoTable.Rows[0]["GraduationDate"]).ToString("dd.MM.yyyy");
            detailedApplicantInfoPage.Medal = infoTable.Rows[0]["Medal"].ToString();
            detailedApplicantInfoPage.Faculty = infoTable.Rows[0]["FacultyName"].ToString();
            detailedApplicantInfoPage.Department = infoTable.Rows[0]["DepartmentName"].ToString();
            detailedApplicantInfoPage.Group = infoTable.Rows[0]["GroupName"].ToString();

            infoTable = SQLSelectQueries.GetScheduleData(infoTable.Rows[0]["GroupName"].ToString());
            detailedApplicantInfoPage.FirstSubject = infoTable.Rows[0]["SubjectName"].ToString();
            detailedApplicantInfoPage.SecondSubject = infoTable.Rows[1]["SubjectName"].ToString();
            detailedApplicantInfoPage.ThirdSubject = infoTable.Rows[2]["SubjectName"].ToString();

            detailedApplicantInfoPage.FirstSubjectConsultation = infoTable.Rows[0]["ConsultationDate"].ToString() + " / " + 
                infoTable.Rows[0]["ConsultationClassroom"].ToString();
            detailedApplicantInfoPage.SecondSubjectConsultation = infoTable.Rows[1]["ConsultationDate"].ToString() + " / " +
                infoTable.Rows[1]["ConsultationClassroom"].ToString();
            detailedApplicantInfoPage.ThirdSubjectConsultation = infoTable.Rows[2]["ConsultationDate"].ToString() + " / " +
                infoTable.Rows[2]["ConsultationClassroom"].ToString();

            detailedApplicantInfoPage.FirstSubjectExam = infoTable.Rows[0]["ExamDate"].ToString() + " / " +
                infoTable.Rows[0]["ExamClassroom"].ToString();
            detailedApplicantInfoPage.SecondSubjectExam = infoTable.Rows[1]["ExamDate"].ToString() + " / " +
                infoTable.Rows[1]["ExamClassroom"].ToString();
            detailedApplicantInfoPage.ThirdSubjectExam = infoTable.Rows[2]["ExamDate"].ToString() + " / " +
                infoTable.Rows[2]["ExamClassroom"].ToString();
        }

        private void DisplayDetailedDepartment(string departmentName)
        {
            
            DataTable departmentTable = SQLSelectQueries.GetDepartmentData(departmentName);
            string idFaculty = departmentTable.Rows[0]["IDFaculty"].ToString();
            detailedDepartmentInfoPage.IDDepartment = departmentTable.Rows[0]["IDDepartment"].ToString();
            detailedDepartmentInfoPage.IDFaculty = idFaculty;
            detailedDepartmentInfoPage.Department = departmentTable.Rows[0]["DepartmentName"].ToString();
           
            detailedDepartmentInfoPage.Faculty = departmentTable.Rows[0]["FacultyName"].ToString();
            detailedDepartmentInfoPage.GroupsName = departmentTable.Rows[0]["DepartmentGroupName"].ToString();

            int applicantsCount = SQLSelectQueries.GetNumOfDepartmentApplicants(departmentTable.Rows[0]["IDDepartment"].ToString());
            int studentsCount = Convert.ToInt32(departmentTable.Rows[0]["NumberOfStudents"]);

            detailedDepartmentInfoPage.NumberOfStudents = studentsCount.ToString();

            DataTable facultySubjectsTable = SQLSelectQueries.GetNecessaryFacultySubjects(idFaculty);

            detailedDepartmentInfoPage.FirstSubject = facultySubjectsTable.Rows[0]["SubjectName"].ToString() + "*";
            detailedDepartmentInfoPage.FirstSubjectCoef = facultySubjectsTable.Rows[0]["Coefficient"].ToString();

            detailedDepartmentInfoPage.FirstSubjectAvgMark = SQLSelectQueries.GetAverageMarkOnFaculty(idFaculty, facultySubjectsTable.Rows[0]["SubjectName"].ToString());

            facultySubjectsTable = SQLSelectQueries.GetUnnecessaryFacultySubjects(idFaculty);

            detailedDepartmentInfoPage.SecondSubject = facultySubjectsTable.Rows[0]["SubjectName"].ToString();
            detailedDepartmentInfoPage.SecondSubjectCoef = facultySubjectsTable.Rows[0]["Coefficient"].ToString();
            detailedDepartmentInfoPage.SecondSubjectAvgMark = SQLSelectQueries.GetAverageMarkOnFaculty(idFaculty, facultySubjectsTable.Rows[0]["SubjectName"].ToString());
            detailedDepartmentInfoPage.ThirdSubject = facultySubjectsTable.Rows[1]["SubjectName"].ToString();
            detailedDepartmentInfoPage.ThirdSubjectCoef = facultySubjectsTable.Rows[1]["Coefficient"].ToString();
            detailedDepartmentInfoPage.ThirdSubjectAvgMark = SQLSelectQueries.GetAverageMarkOnFaculty(idFaculty, facultySubjectsTable.Rows[1]["SubjectName"].ToString());

            detailedDepartmentInfoPage.NumberOfApplicants = applicantsCount.ToString();

            detailedDepartmentInfoPage.Competition = Math.Round(((double)applicantsCount / studentsCount), 1).ToString();

            
        }
     
        private void FirstAddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (showInfoModeComboBox.SelectedIndex)
            {
                case 0:
                    AddNEditApplicantWindow addApplicantWindow = new AddNEditApplicantWindow();
                    this.Closed += (s, args) => addApplicantWindow.Close();
                    addApplicantWindow.Show();
                    break;
                case 1:
                    AddNEditDepartmentWindow addNEditDepartmentWindow = new AddNEditDepartmentWindow();
                    this.Closed += (s, args) => addNEditDepartmentWindow.Close();
                    addNEditDepartmentWindow.Show();
                    break;
            }
        }

        private void SecondAddButton_Click(object sender, RoutedEventArgs e)
        {

            AddNEditFacultyWindowWindow addNEditFacultyWindowWindow = new AddNEditFacultyWindowWindow();
            this.Closed += (s, args) => addNEditFacultyWindowWindow.Close();
            addNEditFacultyWindowWindow.Show();

        }

        private void FirstEditButton_Click(object sender, RoutedEventArgs e)
        {
           
            string facultyName = "";
            foreach (DataRowView row in informationDataGrid.SelectedItems)
            {
                DataRow MyRow = row.Row;
                facultyName = MyRow[0].ToString();
            }
            AddNEditFacultyWindowWindow addNEditFacultyWindowWindow = new AddNEditFacultyWindowWindow(facultyName);
            addNEditFacultyWindowWindow.Show();
                  
        }

        private void SecondEditButton_Click(object sender, RoutedEventArgs e)
        {
            switch (showInfoModeComboBox.SelectedIndex)
            {
                case 0:
                    string applicantID = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        applicantID = MyRow[0].ToString();
                    }
                    AddNEditApplicantWindow addApplicantWindow = new AddNEditApplicantWindow(applicantID);
                    this.Closed += (s, args) => addApplicantWindow.Close();
                    addApplicantWindow.Show();
                    break;
                case 1:
                    string departmentName = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        departmentName = MyRow[1].ToString();
                    }
                    AddNEditDepartmentWindow addNEditDepartmentWindow = new AddNEditDepartmentWindow(departmentName);
                    this.Closed += (s, args) => addNEditDepartmentWindow.Close();
                    addNEditDepartmentWindow.Show();
                    break;
                case 3:
                    string groupName = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        groupName = MyRow[0].ToString();
                    }
                    EditScheduleWindow editScheduleWindow = new EditScheduleWindow(groupName);
                    this.Closed += (s, args) => editScheduleWindow.Close();
                    editScheduleWindow.Show();
                    break;
            }
        }

        private void FirstDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (showInfoModeComboBox.SelectedIndex)
            {
                case 0:
                    string idApplicant = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        idApplicant = MyRow[0].ToString();
                    }
                    if (QuestuonMessageBoxResult("Ви впевнені, що збираєтеся видалити абітурієнта?") == false) { return; }
                    SQLInsertQueries.DeleteApplicant(idApplicant);
                    break;
                case 1:
                    string departmentName = "";
                    foreach (DataRowView row in informationDataGrid.SelectedItems)
                    {
                        DataRow MyRow = row.Row;
                        departmentName = MyRow[1].ToString();
                    }
                    if (QuestuonMessageBoxResult("Ви впевнені, що збираєтеся видалити факультет?") == false) { return; }
                    SQLInsertQueries.DeleteDepartment(SQLSelectQueries.GetDepartmentID(departmentName));
                    break;

            }
        }

        private void SecondDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string facultyName = "";
            foreach (DataRowView row in informationDataGrid.SelectedItems)
            {
                DataRow MyRow = row.Row;
                facultyName = MyRow[1].ToString();
            }
            if(QuestuonMessageBoxResult("Ви впевнені, що збираєтеся видалити кафедру?") == false) { return; }
            SQLInsertQueries.DeleteDepartment(SQLSelectQueries.GetDepartmentID(SQLSelectQueries.GetFacultyID(facultyName)));
        }

        private bool QuestuonMessageBoxResult(string question)
        {
            if (MessageBox.Show(question,
                    "Попередження",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}
