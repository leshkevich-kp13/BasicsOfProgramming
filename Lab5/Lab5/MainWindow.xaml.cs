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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        //Data Source=LAPTOP;Initial Catalog=AdmissionsCommittee;Integrated Security=True

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            FillApplicantFacultyCB();
            FillFacultyForDepartmentCB();
            FillSubjectCBS();
            FillApplicantMedalCB();
            ShowData();
        }

        private void ShowData()
        {
            GetStudentsData();
            GetFacultiesData();
        }

        private void GetAndShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;
            connection.Close();
        }

        private void GetStudentsData()
        {
            string sqlQ = "SELECT Applicants.Surname as [Прізвище], Applicants.Name as [Ім'я], " +
                "Applicants.MiddleName as [По батькові], Applicants.Medal as [Медаль], " +
                "Faculties.FacultyName as [Факультет], Departments.DepartmentName as [Кафедра] " +
                "FROM Applicants INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Applicants.Surname, Applicants.Name, Applicants.MiddleName, " +
                "Applicants.Medal, Applicants.GraduationDate, Departments.DepartmentName, Faculties.FacultyName";
            try
            {
                GetAndShowData(sqlQ, StudentsDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void GetFacultiesData()
        {
            string sqlQ = "SELECT Faculties.FacultyName as [Факультет], Departments.DepartmentName as [Кафедра] " +
                "FROM Departments INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Faculties.FacultyName, Departments.DepartmentName;";
            try
            {
                GetAndShowData(sqlQ, FacultiesDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillApplicantFacultyCB()
        {
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Faculties", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                applicantFacultyCB.Items.Add(sqlReader["FacultyName"].ToString());
            }

            connection.Close();
        }
        private void FillFacultyForDepartmentCB()
        {
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Faculties", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                facultyForDepartmentCB.Items.Add(sqlReader["FacultyName"].ToString());
            }

            connection.Close();
        }
        
        private void FillSubjectCBS()
        {
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Subjects", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                firstSubjectCB.Items.Add(sqlReader["SubjectName"].ToString());
                secondSubjectCB.Items.Add(sqlReader["SubjectName"].ToString());
                thirdSubjectCB.Items.Add(sqlReader["SubjectName"].ToString());
            }

            connection.Close();
        }
        private void FillApplicantMedalCB()
        {
            applicantMedalCB.Items.Add("Відсутня");
            applicantMedalCB.Items.Add("Золота");
            applicantMedalCB.Items.Add("Срібна");
        }
        private void FillApplicantDepartmentCB()
        {
            applicantDepartmentCB.Items.Clear();
            connection = new SqlConnection(connectionString);
            string sqlQ = "SELECT Faculties.FacultyName, Departments.DepartmentName " +
                "FROM Departments INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "WHERE (Faculties.FacultyName = '" + applicantFacultyCB.SelectedItem + "') " +
                "GROUP BY Faculties.FacultyName, Departments.DepartmentName;";
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                applicantDepartmentCB.Items.Add(sqlReader["DepartmentName"].ToString());         
            }

            connection.Close();
        }
        private void ApplicantFacultyCB_SelectionChanged(object sender, EventArgs e)
        {
            FillApplicantDepartmentCB();
        }

        private void AddApplicantButton_Click(object sender, RoutedEventArgs e)
        {
            if(applicantFacultyCB.SelectedItem == null || applicantDepartmentCB.SelectedItem == null || applicantSurnameTextBox.Text == "" ||
                applicantNameTextBox.Text == "" || applicantMiddleNameTextBox.Text == "" || applicantPassportDataTextBox.Text == "" ||
                applicantEducationInstitutionTextBox.Text == "" || applicantGraduationDateDatePicker.Text == "" || applicantMedalCB.SelectedItem == null)
            {
                MessageBox.Show("Необхідно заповнити всі графи");
                return;
            }
            connection = new SqlConnection(connectionString);

            string sqlQ = "SELECT Departments.IDDepartment " +
                "FROM Departments " +
                "WHERE(Departments.DepartmentName = '" + applicantDepartmentCB.SelectedItem + "');";
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            string departmentID = Convert.ToString(sqlCmd.ExecuteScalar());
            

            sqlQ = ("INSERT INTO Applicants" +
                "(Surname, Name, MiddleName, PassportData, " +
                "EducationInstitution, GraduationDate, Medal, IDDepartment)" +
                $"VALUES('{applicantSurnameTextBox.Text}', '{applicantNameTextBox.Text}', " +
                $"'{applicantMiddleNameTextBox.Text}', '{applicantPassportDataTextBox.Text}', " +
                $"'{applicantEducationInstitutionTextBox.Text}', '{Convert.ToDateTime(applicantGraduationDateDatePicker.Text).Date}', " +
                $"'{applicantMedalCB.SelectedItem}', '{departmentID}')");
            sqlCmd = new SqlCommand(sqlQ, connection);
            sqlCmd.ExecuteNonQuery();
            connection.Close();
            GetStudentsData();

            MessageBox.Show("Абітурієнт був доданий до бази даних");
        }

        private void AddFacultyButton_Click(object sender, RoutedEventArgs e)
        {
            if(firstSubjectCB.SelectedItem == null || secondSubjectCB == null ||
                thirdSubjectCB.SelectedItem == null || facultyNameTextBox.Text == "")
            {
                MessageBox.Show("Необхідно заповнити всі графи");
                return;
            }

            if (firstSubjectCB.SelectedIndex == secondSubjectCB.SelectedIndex ||
                thirdSubjectCB.SelectedIndex == secondSubjectCB.SelectedIndex ||
                firstSubjectCB.SelectedIndex == thirdSubjectCB.SelectedIndex)
            {
                MessageBox.Show("Предмети не можуть співпадати");
                return;
            }

            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "INSERT INTO Faculties(FacultyName)" +
                $"VALUES('{facultyNameTextBox.Text}')";
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            sqlCmd.ExecuteNonQuery();



            sqlQ = "SELECT Subjects.IDSubject " +
                "FROM Subjects " +
                $"WHERE(Subjects.SubjectName = '{firstSubjectCB.SelectedItem}');";
            sqlCmd = new SqlCommand(sqlQ, connection); 
            string firstSubjectID = Convert.ToString(sqlCmd.ExecuteScalar());

            sqlQ = "SELECT Subjects.IDSubject " +
                "FROM Subjects " +
                "WHERE(Subjects.SubjectName = '" + secondSubjectCB.SelectedItem + "');";
            sqlCmd = new SqlCommand(sqlQ, connection);
            string secondSubjectID = Convert.ToString(sqlCmd.ExecuteScalar());

            sqlQ = "SELECT Subjects.IDSubject " +
                "FROM Subjects " +
                "WHERE(Subjects.SubjectName = '" + thirdSubjectCB.SelectedItem + "');";
            sqlCmd = new SqlCommand(sqlQ, connection);
            string thirdSubjectID = Convert.ToString(sqlCmd.ExecuteScalar());
            

            sqlQ = "SELECT Faculties.IDFaculty " +
                "FROM Faculties " +
                "WHERE(Faculties.FacultyName = '" + facultyNameTextBox.Text + "');";
            sqlCmd = new SqlCommand(sqlQ, connection);
            string facultyID = Convert.ToString(sqlCmd.ExecuteScalar());

            sqlQ = "INSERT INTO FacultySubjects(IDFaculty, IDSubject)" +
                $"VALUES('{facultyID}', '{firstSubjectID}')";
            sqlCmd = new SqlCommand(sqlQ, connection);
            sqlCmd.ExecuteNonQuery();

            sqlQ = "INSERT INTO FacultySubjects(IDFaculty, IDSubject)" +
                $"VALUES('{facultyID}', '{secondSubjectID}')";
            sqlCmd = new SqlCommand(sqlQ, connection);
            sqlCmd.ExecuteNonQuery();

            sqlQ = "INSERT INTO FacultySubjects(IDFaculty, IDSubject)" +
                $"VALUES('{facultyID}', '{thirdSubjectID}')";
            sqlCmd = new SqlCommand(sqlQ, connection);
            sqlCmd.ExecuteNonQuery();
            connection.Close();

            GetFacultiesData();
            applicantFacultyCB.Items.Add(facultyNameTextBox.Text);
            facultyForDepartmentCB.Items.Add(facultyNameTextBox.Text);
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (facultyForDepartmentCB.SelectedItem == null || departmentNameTextBox.Text == "" ||
                groupNameTextBox.Text == "")
            {
                MessageBox.Show("Необхідно заповнити всі графи");
                return;
            }
            connection.Open();

            string sqlQ = "SELECT Faculties.IDFaculty " +
                "FROM Faculties " +
                "WHERE(Faculties.FacultyName = '" + facultyForDepartmentCB.SelectedItem + "');";
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            string facultyID = Convert.ToString(sqlCmd.ExecuteScalar());

            sqlQ = ("INSERT INTO Departments" +
               "(DepartmentName, IDFaculty, GropeName)" +
               $"VALUES('{departmentNameTextBox.Text}', '{facultyID}', " +
               $"'{groupNameTextBox.Text}')");
            sqlCmd = new SqlCommand(sqlQ, connection);
            sqlCmd.ExecuteNonQuery();

            connection.Close();

            applicantDepartmentCB.Items.Add(facultyNameTextBox.Text);
            GetFacultiesData();
        }

    }
}
