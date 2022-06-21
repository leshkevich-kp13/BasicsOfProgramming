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

namespace UniversityAdmissionCommittee
{
    public static class SQLInsertQueries
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static SqlConnection connection = null;
        static SqlCommand command;
        static SqlDataAdapter adapter;

        public static void InsertApplicant(string surname, string name, string middleName, string passportData, 
            string educationInstitution, string graduationDate, string medal, string idDepartment)
        {
            surname = surname.Replace("'", "''");
            name = name.Replace("'", "''");
            middleName = middleName.Replace("'", "''");
            educationInstitution = educationInstitution.Replace("'", "''");

            string sqlQ = "INSERT INTO Applicants " +
                $"VALUES ('{surname}', '{name}', '{middleName}', '{passportData}', '{educationInstitution}', " +
                $"'{(Convert.ToDateTime(graduationDate).Date).ToString("yyyy-MM-dd")}', '{medal}', '{idDepartment}')";
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertApplicantGroup(string idApplicant, string idGroup)
        {
            string sqlQ = "INSERT INTO ApplicantGroup " +
                $"VALUES ({idApplicant}, {idGroup})";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertSubjectsForMarks(string idApplicant, string idSubject)
        {
            string sqlQ = "INSERT INTO Marks " +
                "(IDApplicant, IDSubject) " +
                $"VALUES ({idApplicant}, {idSubject})";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertNewGroup(string groupName, string idDepartment)
        {
            string sqlQ = "INSERT INTO Groups " +
                $"VALUES ('{groupName}', {idDepartment})";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteApplicantSubject(string idApplicant)
        {
            string sqlQ = "DELETE FROM Marks " +
                $"WHERE Marks.IDApplicant = {idApplicant}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertDepartment(string departmentName, string idFacuclty, string departmentGroupName, string numberOfStudents)
        {
            departmentName = departmentName.Replace("'", "''");

            string sqlQ = "INSERT INTO Departments " +
                $"VALUES ('{departmentName}', {idFacuclty}, '{departmentGroupName}', {numberOfStudents})";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertExams(string idGroup, string idSubject)
        {

            string sqlQ = "INSERT INTO Exams " +
                "(IDGroup, IDSubject) " +
                $"VALUES ({idGroup}, {idSubject})";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertFaculty(string facultyName)
        {
            facultyName = facultyName.Replace("'", "''");

            string sqlQ = "INSERT INTO Faculties " +
                $"VALUES ('{facultyName}')";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertFacultySubject(string idFaculty, string idSubject, string necessary, string coefficient )
        {
            coefficient = coefficient.Replace(",", ".");

            string sqlQ = "INSERT INTO FacultySubjects " +
                $"VALUES ({idFaculty}, {idSubject}, {necessary}, {coefficient})";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertTotalMarkApplicantColumn(string idApplicant)
        {          
            string sqlQ = "INSERT INTO TotalMarks " +
                "(IDApplicant)" +
                $"VALUES ({idApplicant})";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteApplicant(string idApplicant)
        {
            string sqlQ = "DELETE FROM Applicants " +
                $"WHERE Applicants.IDApplicant = {idApplicant}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteDepartment(string idDepartment)
        {
            string sqlQ = "DELETE Groups " +
                "FROM Groups INNER JOIN " +
                "Departments ON Groups.IDDepartment = Departments.IDDepartment " +
                $"WHERE Departments.IDDepartment = {idDepartment}";
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();

            sqlQ = "DELETE FROM Departments " +
                $"WHERE Departments.IDDepartment = {idDepartment}";

            connection = new SqlConnection(connectionString);
            sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteFaculty(string idFaculty)
        {
            string sqlQ = "DELETE Groups " +
                "FROM Groups INNER JOIN " +
                "Departments ON Groups.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                $"WHERE Faculties.IDFaculty = {idFaculty}";
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();

            sqlQ = "DELETE FROM Faculties " +
                $"WHERE Faculties.IDFaculty = {idFaculty}";

            connection = new SqlConnection(connectionString);
            sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
