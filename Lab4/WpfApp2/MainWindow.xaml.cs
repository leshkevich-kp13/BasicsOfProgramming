using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Lab4
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

        //Data Source=LAPTOP;Initial Catalog=AdmissiomsCommittee;Integrated Security=True

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ShowData();
        }

        private void ShowData()
        {
            GetStudentsData();
            GetScheduleData();
            GetMarksData();
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
                "Applicants.MiddleName as [По батькові], Applicants.MedalPresance as [Медаль], " +
                "Faculties.FacultyName as [Факультет], Departments.DepartmentName as [Кафедра] " +
                "FROM Applicants INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Applicants.Surname, Applicants.Name, Applicants.MiddleName, " +
                "Applicants.MedalPresance,  Departments.DepartmentName, Faculties.FacultyName";
            try
            {
                GetAndShowData(sqlQ, StudentsDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetScheduleData()
        {
            string sqlQ = "SELECT Groups.GroupName as [Група], Subjects.SubjectName as [Предмет], " +
                "Exams.ConsultationDate as [Дата консультації],Exams.ConsultationClassroom as [Аудиторія консультації], " +
                "Exams.ExamDate as [Дата екзамену], Exams.ExamClassroom as [Аудиторія екзамену]" +
                "FROM Groups INNER JOIN " +
                "Exams ON Groups.IDGroup = Exams.IDGroup INNER JOIN " +
                "Subjects ON Exams.IDSubject = Subjects.IDSubject " +
                "GROUP BY Groups.GroupName, Exams.ExamDate, Exams.ConsultationDate, Exams.ExamClassroom, " +
                "Exams.ConsultationClassroom, Subjects.SubjectName;";
            try
            {
                GetAndShowData(sqlQ, ScheduleDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetMarksData()
        {
            string sqlQ = "SELECT Applicants.Surname as [Прізвище], Applicants.Name as [Ім'я], " +
                "Applicants.MiddleName as [По бітькові], Groups.GroupName as [Група], " +
                "Subjects.SubjectName as [Предмет], Marks.Mark as [Оцінка] " +
                "FROM dbo.ApplicantGroup INNER JOIN " +
                "Applicants ON ApplicantGroup.IDApplicant = Applicants.IDApplicant INNER JOIN " +
                "Groups ON ApplicantGroup.IDGroup = Groups.IDGroup INNER JOIN " +
                "Marks ON Applicants.IDApplicant = Marks.IDApplicant INNER JOIN " +
                "Subjects ON dbo.Marks.IDSubject = Subjects.IDSubject " +
                "WHERE Marks.Mark > 9" +
                "GROUP BY Applicants.Surname, Applicants.Name, Applicants.MiddleName, Groups.GroupName, " +
                "Subjects.SubjectName, Marks.Mark";
            try
            {
                GetAndShowData(sqlQ, MarksDG);
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
    }
}
