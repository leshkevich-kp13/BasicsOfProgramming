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
    public static class SQLUpdateQueries
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static SqlConnection connection = null;
        static SqlCommand command;
        static SqlDataAdapter adapter;

        public static void UpdateApplicantData(string idApplicant, string surname, string name, string middleName, string passportData, string eduacationInstitution, 
            string graduationDate, string medal, string idDepartment)
        {
            surname = surname.Replace("'", "''");
            name = name.Replace("'", "''");
            middleName = middleName.Replace("'", "''");
            passportData = passportData.Replace("'", "''");
            eduacationInstitution = eduacationInstitution.Replace("'", "''");

            string sqlQ = "UPDATE Applicants " +
                $"SET Surname = '{surname}', Name = '{name}', MiddleName = '{middleName}', PassportData = '{passportData}', " +
                $"EducationInstitution = '{eduacationInstitution}', GraduationDate = '{(Convert.ToDateTime(graduationDate).Date).ToString("yyyy-MM-dd")}', " +
                $"Medal = '{medal}', IDDepartment = '{idDepartment}' " +
                $"WHERE IDApplicant = {idApplicant}";
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void SetMarksForGoldenMedal(string idApplicant)
        {
            string sqlQ = "UPDATE Marks " +
                "SET Marks.Mark = 12 " +
                "FROM Applicants INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty INNER JOIN " +
                "FacultySubjects ON Faculties.IDFaculty = FacultySubjects.IDFaculty INNER JOIN " +
                "Marks ON Applicants.IDApplicant = Marks.IDApplicant INNER JOIN " +
                "Subjects ON FacultySubjects.IDSubject = Subjects.IDSubject AND Marks.IDSubject = Subjects.IDSubject " +
                $"WHERE (FacultySubjects.Necessary = 0) AND (Marks.IDApplicant = {idApplicant})";
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateApplicantGroup(string idApplicant, string idGroup)
        {
            string sqlQ = "UPDATE ApplicantGroup " +
                $"SET ApplicantGroup.IDGroup = {idGroup} " +
                $"FROM ApplicantGroup " +
                $"WHERE ApplicantGroup.IDApplicant = {idApplicant}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateDepartmentInfo(string idDepartment, string departmentName, string groupName, string numberOfStudents)
        {
            departmentName = departmentName.Replace("'", "''");

            string sqlQ = "UPDATE Departments " +
                $"SET Departments.DepartmentName = '{departmentName}', Departments.DepartmentGroupName = '{groupName}', " +
                $"Departments.NumberOfStudents = '{numberOfStudents}' " +
                $"FROM Departments " +
                $"WHERE Departments.IDDepartment = {idDepartment}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }
       
        public static void UpdateDepartmentFaculty(string idDepartment, string idFaculty)
        {

            string sqlQ = "UPDATE Departments " +
                $"SET Departments.IDFaculty = {idFaculty} " +
                $"FROM Departments " +
                $"WHERE Departments.IDDepartment = {idDepartment}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateDepartmentGroupsName(string newGroupName, string groupName)
        {
            string sqlQ = "UPDATE Groups " +
                $"SET GroupName = REPLACE(GroupName, '{groupName}-', '{newGroupName}-') " +
                $"WHERE GroupName LIKE '{groupName}-%'";
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateStudentNecessarySubjects(string idNewSubject, string idSubject, string idDepartment, string idFaculty)
        {
            string sqlQ = "UPDATE Marks " +
            $"SET Marks.IDSubject = {idNewSubject} " +
            "FROM Marks INNER JOIN Applicants ON Marks.IDApplicant = Applicants.IDApplicant INNER JOIN " +
            "FacultySubjects ON Marks.IDSubject = FacultySubjects.IDSubject " +
            $"WHERE Applicants.Medal = 'Золота' AND FacultySubjects.Necessary = 1 AND Applicants.IDDepartment = {idDepartment} AND " +
            $"FacultySubjects.IDFaculty = {idFaculty} AND Marks.IDSubject = {idSubject}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();

            sqlQ = "UPDATE Marks " +
            $"SET Marks.IDSubject = {idNewSubject}, Marks.Mark = 0 " +
            "FROM Marks INNER JOIN Applicants ON Marks.IDApplicant = Applicants.IDApplicant INNER JOIN " +
            "FacultySubjects ON Marks.IDSubject = FacultySubjects.IDSubject " +
            $"WHERE Applicants.Medal != 'Золота' AND FacultySubjects.Necessary = 1 AND Applicants.IDDepartment = {idDepartment} AND " +
            $"FacultySubjects.IDFaculty = {idFaculty} AND Marks.IDSubject = {idSubject}";

            connection = new SqlConnection(connectionString);
            sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateStudentUnnecessarySubjects(string idNewSubject, string idSubject, string idDepartment, string idFaculty)
        {
            string sqlQ = "UPDATE Marks " +
            $"SET Marks.IDSubject = {idNewSubject}, Marks.Mark = 0 " +
            "FROM Marks INNER JOIN Applicants ON Marks.IDApplicant = Applicants.IDApplicant INNER JOIN " +
            "FacultySubjects ON Marks.IDSubject = FacultySubjects.IDSubject " +
            $"WHERE FacultySubjects.Necessary = 1 AND Applicants.IDDepartment = {idDepartment} AND " +
            $"FacultySubjects.IDFaculty = {idFaculty} AND Marks.IDSubject = {idSubject}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateFacultyData(string idFaculty, string facultyName)
        {
            facultyName = facultyName.Replace("'", "''");

            string sqlQ = "UPDATE Faculties " +
            $"SET Faculty.FacultyName = {facultyName} " +
            $"WHERE Faculty.IDFaculty = {idFaculty}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateFacultySubjects(string idFaculty, string newIDSubject, string idSubject)
        {        
            string sqlQ = "UPDATE FacultySubject " +
            $"SET FacultySubject.IDSubject = {newIDSubject} " +
            $"WHERE FacultySubject.IDFaculty = {idFaculty} AND FacultySubject.IDSubject = {idSubject}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdatSubjectsCoefficient(string idFaculty, string idSubject, string coefficient)
        {
            string sqlQ = "UPDATE FacultySubject " +
            $"SET FacultySubject.Coefficient = {coefficient} " +
            $"WHERE FacultySubject.IDFaculty = {idFaculty} AND FacultySubject.IDSubject = {idSubject}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();

        }

        public static void UpdateTotalMark(string idApplicant)
        {
            DataTable marks = SQLSelectQueries.GetMarksAndCoefficients(idApplicant);

            double mark1 = Convert.ToInt16(marks.Rows[0]["Mark"]) * Convert.ToDouble(marks.Rows[0]["Coefficient"]);
            double mark2 = Convert.ToInt16(marks.Rows[1]["Mark"]) * Convert.ToDouble(marks.Rows[1]["Coefficient"]);
            double mark3 = Convert.ToInt16(marks.Rows[2]["Mark"]) * Convert.ToDouble(marks.Rows[2]["Coefficient"]);

            string totalMark = Convert.ToString(Math.Round((mark1 + mark2 + mark3), 1)).Replace(',', '.');

            string sqlQ = "UPDATE TotalMarks " +
            $"SET TotalMarks.TotalMark = '{totalMark}' " +
            $"WHERE TotalMarks.IDApplicant = {idApplicant}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateGroupSchedule(string idGroup, string idSubject, string consultationDate,
            string examDate, string consultationClassroom, string examClassroom)
        {
            
            string sqlQ = "UPDATE Exams " +
            $"SET Exams.ConsultationDate = {consultationDate}, Exams.ExamDate = {examDate}, " +
            $"Exams.ConsultationClassroom = '{consultationClassroom}', Exams.ExamClassroom = '{examClassroom}'" +
            $"WHERE Exams.IDSubject = {idSubject} AND Exams.IDGroup = {idGroup}";

            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateMark(string idApplicant, string subjectName, string mark)
        {
            string sqlQ = $"UPDATE Marks " +
                $"SET Mark = {mark} " +
                "FROM Marks INNER JOIN " +
                "Subjects ON Marks.IDSubject = Subjects.IDSubject " +
                $"WHERE IDApplicant = {idApplicant} AND Subjects.SubjectName = '{subjectName}'";
            
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(sqlQ, connection);
            connection.Open();
            sqlCmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
