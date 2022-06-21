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
    public static class SQLSelectQueries
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static SqlConnection connection = null;
        static SqlCommand command;
        static SqlDataAdapter adapter;

        private static DataTable GetData(string sqlQuery)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(sqlQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }

        public static DataTable GetApplicantData()
        {
            string sqlQ = "SELECT Applicants.IDApplicant as [ID], Applicants.Surname as [Прізвище], " +
                "Applicants.Name as [Ім'я],Applicants.MiddleName as [По батькові],Faculties.FacultyName as [Факультет], " +
                "Departments.DepartmentName as [Кафедра], Groups.GroupName as [Група] " +
                "FROM ApplicantGroup INNER JOIN " +
                "Applicants ON ApplicantGroup.IDApplicant = Applicants.IDApplicant INNER JOIN " +
                "Groups ON ApplicantGroup.IDGroup = Groups.IDGroup INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Applicants.IDApplicant, Applicants.Surname, Applicants.Name, Applicants.MiddleName, " +
                "Applicants.GraduationDate, Departments.DepartmentName, Faculties.FacultyName, Groups.GroupName;";
            return GetData(sqlQ);
        }

        public static DataTable GetApplicantData(string idApplicant, string surname, string name, string middleName,
            string facultyName, string departmentName, string groupName)
        {
            surname = surname.Replace("'", "''");
            name = name.Replace("'", "''");
            middleName = middleName.Replace("'", "''");
            facultyName = facultyName.Replace("'", "''");
            departmentName = departmentName.Replace("'", "''");
            groupName = groupName.Replace("'", "''");

            idApplicant = idApplicant == "" ? "Applicants.IDApplicant" : "'" + idApplicant + "'";
            surname = surname == "" ? "Applicants.Surname" : "'" + surname + "'";
            name = name == "" ? "Applicants.Name" : "'" + name + "'";
            middleName = middleName == "" ? "Applicants.MiddleName" : "'" + middleName + "'";
            facultyName = facultyName == "" ? "Faculties.FacultyName" : "'" + facultyName + "'";
            departmentName = departmentName == "" ? "Departments.DepartmentName" : "'" + departmentName + "'";
            groupName = groupName == "" ? "Groups.GroupName" : "'" + groupName + "'";

            string sqlQ = "SELECT Applicants.IDApplicant as [ID], Applicants.Surname as [Прізвище], " +
                "Applicants.Name as [Ім'я],Applicants.MiddleName as [По батькові], " +
                "Faculties.FacultyName as [Факультет], Departments.DepartmentName as [Кафедра], " +
                "Groups.GroupName as [Група] " +
                "FROM ApplicantGroup INNER JOIN " +
                "Applicants ON ApplicantGroup.IDApplicant = Applicants.IDApplicant INNER JOIN " +
                "Groups ON ApplicantGroup.IDGroup = Groups.IDGroup INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Applicants.IDApplicant, Applicants.Surname, Applicants.Name, Applicants.MiddleName, Groups.GroupName, " +
                "Applicants.GraduationDate, Departments.DepartmentName, Faculties.FacultyName " +
                $"HAVING (Applicants.IDApplicant = {idApplicant}) AND (Applicants.Surname = {surname}) AND " +
                $"(Applicants.Name = {name}) AND (Applicants.MiddleName = {middleName}) AND " +
                $"(Faculties.FacultyName = {facultyName}) AND (Departments.DepartmentName = {departmentName}) AND " +
                $"(Groups.GroupName = {groupName})";
            return GetData(sqlQ);
        }

        public static DataTable GetDepartmentsAndFacultiesData()
        {
            string sqlQ = "SELECT Faculties.FacultyName as [Факультет], Departments.DepartmentName as [Кафедра] " +
                "FROM Departments INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Faculties.FacultyName, Departments.DepartmentName";
            return GetData(sqlQ);
        }

        public static DataTable GetDepartmentsAndFacultiesData(string facultyName)
        {
            facultyName = facultyName.Replace("'", "''");
            facultyName = facultyName == "" ? "Faculties.FacultyName" : "'" + facultyName + "'";

            string sqlQ = "SELECT Faculties.FacultyName as [Факультет], Departments.DepartmentName as [Кафедра] " +
                "FROM Departments INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                $"WHERE Faculties.FacultyName = {facultyName} " +
                "GROUP BY Faculties.FacultyName, Departments.DepartmentName";

            return GetData(sqlQ);
        }

        public static DataTable GetMarks()
        {
            string sqlQ = "SELECT Applicants.IDApplicant as [ID], Applicants.Surname as [Прізвище], Applicants.Name as [Ім'я], " +
                "Applicants.MiddleName as [По бітькові], Groups.GroupName as [Група], " +
                "Subjects.SubjectName as [Предмет], Marks.Mark as [Оцінка] " +
                "FROM dbo.ApplicantGroup INNER JOIN " +
                "Applicants ON ApplicantGroup.IDApplicant = Applicants.IDApplicant INNER JOIN " +
                "Groups ON ApplicantGroup.IDGroup = Groups.IDGroup INNER JOIN " +
                "Marks ON Applicants.IDApplicant = Marks.IDApplicant INNER JOIN " +
                "Subjects ON dbo.Marks.IDSubject = Subjects.IDSubject " +
                "GROUP BY Applicants.IDApplicant, Applicants.Surname, Applicants.Name, Applicants.MiddleName, Groups.GroupName, Subjects.SubjectName, " +
                "Marks.Mark ";

            return GetData(sqlQ);
        }

        public static DataTable GetMarks(string idApplicant, string surname, string name, string middleName, string group, string subject, 
            string faculty, string department)
        {
            surname = surname.Replace("'", "''");
            name = name.Replace("'", "''");
            middleName = middleName.Replace("'", "''");
            faculty = faculty.Replace("'", "''");
            department = department.Replace("'", "''");

            idApplicant = idApplicant == "" ? "Applicants.IDApplicant" : "'" + idApplicant + "'";
            surname = surname == "" ? "Applicants.Surname" : "'" + surname + "'";
            name = name == "" ? "Applicants.Name" : "'" + name + "'";
            middleName = middleName == "" ? "Applicants.MiddleName" : "'" + middleName + "'";
            group = group == "" ? "Groups.GroupName" : "'" + group + "'";
            subject = subject == "" ? "Subjects.SubjectName" : "'" + subject + "'";
            faculty = faculty == "" ? "Faculties.FacultyName" : "'" + faculty + "'";
            department = department == "" ? "Departments.DepartmentName" : "'" + department + "'";

            string sqlQ = "SELECT Applicants.IDApplicant as [ID], Applicants.Surname as [Прізвище], Applicants.Name as [Ім'я], " +
                "Applicants.MiddleName as [По бітькові], Groups.GroupName as [Група], " +
                "Subjects.SubjectName as [Предмет], Marks.Mark as [Оцінка] " +
                "FROM dbo.ApplicantGroup INNER JOIN " +
                "Applicants ON ApplicantGroup.IDApplicant = Applicants.IDApplicant INNER JOIN " +
                "Groups ON ApplicantGroup.IDGroup = Groups.IDGroup INNER JOIN " +
                "Marks ON Applicants.IDApplicant = Marks.IDApplicant INNER JOIN " +
                "Subjects ON dbo.Marks.IDSubject = Subjects.IDSubject INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Applicants.IDApplicant, Applicants.Surname, Applicants.Name, Applicants.MiddleName, Groups.GroupName,Subjects.SubjectName, " +
                "Marks.Mark, Faculties.FacultyName, Departments.DepartmentName " +
                $"HAVING Applicants.IDApplicant = {idApplicant} AND Applicants.Surname = {surname} AND Applicants.Name = {name} AND " +
                $"Applicants.MiddleName = {middleName} AND Groups.GroupName = {group} AND Subjects.SubjectName = {subject} AND " +
                $"Faculties.FacultyName = {faculty} AND Departments.DepartmentName = {department}";

            return GetData(sqlQ);
        }

        public static DataTable GetAllFacultiesNames()
        {
            string sqlQ = "SELECT Faculties.FacultyName " +
                "FROM Faculties " +
                "GROUP BY Faculties.FacultyName";
            return GetData(sqlQ);
        }

        public static DataTable GetDepartmentsNames(string facultyName)
        {
            facultyName = facultyName.Replace("'", "''");

            facultyName = facultyName == "" ? "Faculties.FacultyName" : "'" + facultyName + "'";
            
            string sqlQ = "SELECT Departments.DepartmentName " +
                "FROM Departments INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Faculties.FacultyName, Departments.DepartmentName " +
                $"HAVING (Faculties.FacultyName = {facultyName})";
            return GetData(sqlQ);
        }

        public static DataTable GetGroupsNames(string departmentName, string facultyName)
        {
            departmentName = departmentName.Replace("'", "''");
            facultyName = facultyName.Replace("'", "''");

            departmentName = departmentName == "" ? "Departments.DepartmentName" : "'" + departmentName + "'";
            facultyName = facultyName == "" ? "Faculties.FacultyName" : "'" + facultyName + "'";
     
            string sqlQ = "SELECT Groups.GroupName " +
                "FROM Departments INNER JOIN " +
                "Groups ON Departments.IDDepartment = Groups.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                "GROUP BY Groups.GroupName, Departments.DepartmentName, Faculties.FacultyName " +
                $"HAVING (Departments.DepartmentName = {departmentName}) AND " +
                $"(Faculties.FacultyName = {facultyName})";
            return GetData(sqlQ);
        }

        public static DataTable GetEnlistedApplicants(string departmentName)
        {
            string idDepartment = GetDepartmentID(departmentName);
            int numOfStudents = GetDepartmentStudentsNum(idDepartment);
            string sqlQ = $"SELECT TOP {numOfStudents} Applicants.IDApplicant as [ID], Applicants.Surname as [Прізвище], " +
                $"Applicants.Name as [Ім'я], Applicants.MiddleName as [По батькові], TotalMarks.TotalMark as [Конкурсний бал] " +
                "FROM Applicants INNER JOIN " +
                "TotalMarks ON Applicants.IDApplicant = TotalMarks.IDApplicant INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment " +
                $"WHERE Departments.IDDepartment = {idDepartment}" +
                "ORDER BY TotalMarks.TotalMark DESC";

            return GetData(sqlQ);
        }

        public static string GetAverageMarkOnFaculty(string idFaculty, string subjectName)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT AVG(Marks.Mark) " +
                "FROM Marks INNER JOIN " +
                "Applicants ON Marks.IDApplicant = Applicants.IDApplicant INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty INNER JOIN " +
                "Subjects ON Marks.IDSubject = Subjects.IDSubject " +
                $"WHERE Faculties.IDFaculty = {idFaculty} AND Subjects.SubjectName = '{subjectName}'";

            command = new SqlCommand(sqlQ, connection);
            string groupName = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return groupName;
        }

        private static int GetDepartmentStudentsNum(string idDepartment)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT NumberOfStudents " +
                "FROM Departments " +
                $"WHERE IDDepartment = {idDepartment}";

            command = new SqlCommand(sqlQ, connection);
            int studentsNum = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return studentsNum;
        }

        public static DataTable GetDepartmentData(string departmentName)
        {
            departmentName = departmentName.Replace("'", "''");
            departmentName = departmentName == "" ? "Departments.DepartmentName" : "'" + departmentName + "'";

            string sqlQ = "SELECT Departments.DepartmentName, Departments.IDFaculty, Departments.IDDepartment, " +
                "Departments.DepartmentGroupName, Departments.NumberOfStudents, Faculties.FacultyName " +
                "FROM Departments INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                $"WHERE Departments.DepartmentName = {departmentName}";
            return GetData(sqlQ);
        }

        public static DataTable GetAllSubjects()
        {     
            string sqlQ = "SELECT Subjects.SubjectName " +
                "FROM Subjects";
            return GetData(sqlQ);
        }

        public static DataTable GetUnnecessaryFacultySubjects(string idFaculty)
        {
            string sqlQ = "SELECT Subjects.SubjectName, FacultySubjects.Coefficient " +
                "FROM Subjects INNER JOIN " +
                "FacultySubjects ON Subjects.IDSubject = FacultySubjects.IDSubject INNER JOIN " +
                "Faculties ON FacultySubjects.IDFaculty = Faculties.IDFaculty " +
                $"WHERE Faculties.IDFaculty = {idFaculty} AND FacultySubjects.Necessary = 0";

            return GetData(sqlQ);
        }

        public static DataTable GetNecessaryFacultySubjects(string idFaculty)
        {
            string sqlQ = "SELECT Subjects.SubjectName, FacultySubjects.Coefficient " +
                "FROM Subjects INNER JOIN " +
                "FacultySubjects ON Subjects.IDSubject = FacultySubjects.IDSubject INNER JOIN " +
                "Faculties ON FacultySubjects.IDFaculty = Faculties.IDFaculty " +
                $"WHERE Faculties.IDFaculty = {idFaculty} AND FacultySubjects.Necessary = 1";

            return GetData(sqlQ);
        }

        public static void GetFacultySubjectsID(string facultyName, string[] subjectsID)
        {
            facultyName = facultyName.Replace("'", "''");

            connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQ = "SELECT Subjects.IDSubject " +
                "FROM FacultySubjects INNER JOIN " +
                "Faculties ON FacultySubjects.IDFaculty = Faculties.IDFaculty INNER JOIN " +
                "Subjects ON FacultySubjects.IDSubject = Subjects.IDSubject " +
                "GROUP BY Faculties.FacultyName, Subjects.IDSubject " +
                $"HAVING (Faculties.FacultyName = '{facultyName}')";
            command = new SqlCommand(sqlQ, connection);
            SqlDataReader sqlReader = command.ExecuteReader();
            for (int i = 0; sqlReader.Read(); i++)
            {
                subjectsID[i] = sqlReader["IDSubject"].ToString();
            }
            connection.Close();
        }
   
        public static string GetDepartmentGroupName(string idDepartment)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQ = "SELECT DepartmentGroupName " +
                "FROM Departments " +
                $"WHERE IDDepartment = '{idDepartment}'";
            command = new SqlCommand(sqlQ, connection);
            string groupName = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return groupName;
        }

        public static DataTable GetAllApplicantData(string idApplicant)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQ = "SELECT Applicants.IDApplicant, Applicants.Surname, Applicants.Name, " +
                "Applicants.MiddleName, Applicants.PassportData, Applicants.EducationInstitution, " +
                "Applicants.GraduationDate, Applicants.Medal, " +
                "Faculties.FacultyName, Departments.DepartmentName, Groups.GroupName " +
                "FROM ApplicantGroup INNER JOIN " +
                "Applicants ON ApplicantGroup.IDApplicant = Applicants.IDApplicant INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN  " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty INNER JOIN " +
                "FacultySubjects ON Faculties.IDFaculty = FacultySubjects.IDFaculty INNER JOIN " +
                "Groups ON ApplicantGroup.IDGroup = Groups.IDGroup " +
                "GROUP BY Applicants.IDApplicant, Applicants.Surname, Applicants.Name, " +
                "Applicants.MiddleName, Applicants.PassportData, Applicants.EducationInstitution, " +
                "Applicants.GraduationDate, Applicants.Medal,Faculties.FacultyName, Departments.DepartmentName, " +
                "Groups.GroupName " +
                $"HAVING (Applicants.IDApplicant = {idApplicant})";

            return GetData(sqlQ);
        }

        public static DataTable GetScheduleData()
        {
            string sqlQ = "SELECT Groups.GroupName as [Група], Subjects.SubjectName as [Предмет], Exams.ConsultationDate as [Дата консультації], " +
                "Exams.ConsultationClassroom as [Аудиторія консультації], Exams.ExamDate as [Дата екзамену], Exams.ExamClassroom as [Аудиторія екзамену] " +
                "FROM Exams INNER JOIN " +
                "Subjects ON Exams.IDSubject = Subjects.IDSubject INNER JOIN " +
                "Groups ON Exams.IDGroup = Groups.IDGroup";

            return GetData(sqlQ);
        }

        public static DataTable GetScheduleData(string facultyName, string departmentName, string groupName, string subjectName)
        {
            facultyName = facultyName.Replace("'", "''");
            departmentName = departmentName.Replace("'", "''");

            facultyName = facultyName == "" ? "Faculties.FacultyName" : "'" + facultyName + "'";
            departmentName = departmentName == "" ? "Departments.DepartmentName" : "'" + departmentName + "'";
            groupName = groupName == "" ? "Groups.GroupName" : "'" + groupName + "'";
            subjectName = subjectName == "" ? "Subjects.SubjectName" : "'" + subjectName + "'";

            string sqlQ = "SELECT Groups.GroupName as [Група], Subjects.SubjectName as [Предмет], Exams.ConsultationDate as [Дата консультації], " +
                "Exams.ConsultationClassroom as [Аудиторія консультації], Exams.ExamDate as [Дата екзамену], Exams.ExamClassroom as [Аудиторія екзамену] " +
                "FROM Exams INNER JOIN " +
                "Subjects ON Exams.IDSubject = Subjects.IDSubject INNER JOIN " +
                "Groups ON Exams.IDGroup = Groups.IDGroup INNER JOIN " +
                "Departments ON Groups.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties ON Departments.IDFaculty = Faculties.IDFaculty " +
                $"WHERE Faculties.FacultyName = {facultyName} AND Departments.DepartmentName = {departmentName} AND " +
                $"Groups.GroupName = {groupName} AND Subjects.SubjectName = {subjectName}";

            return GetData(sqlQ);
        }

        public static DataTable GetScheduleData(string groupName)
        { 
            string sqlQ = "SELECT Subjects.SubjectName, Exams.ConsultationDate, Exams.ExamDate, " +
                "Exams.ConsultationClassroom, Exams.ExamClassroom " +
                "FROM Groups INNER JOIN " +
                "Exams ON Groups.IDGroup = Exams.IDGroup INNER JOIN " +
                "Subjects ON Exams.IDSubject = Subjects.IDSubject " +          
                "GROUP BY Groups.GroupName, Subjects.SubjectName, Exams.ConsultationDate, Exams.ExamDate, " +
                "Exams.ConsultationClassroom, Exams.ExamClassroom " +
                $"HAVING Groups.GroupName = '{groupName}'";

            return GetData(sqlQ);
        }

        public static DataTable GetGroupSchedule(string idGroup)
        {
            string sqlQ = "SELECT Exams.ConsultationDate, Exams.ExamDate, Exams.ConsultationClassroom, Exams.ExamClassroom, Subjects.SubjectName " +
                "FROM Exams INNER JOIN " +
                "Subjects ON Exams.IDSubject = Subjects.IDSubject " +
                $"WHERE Exams.IDGroup = {idGroup}";
            return GetData(sqlQ);
        }

        public static string GetDepartmentID(string departmentName)
        {
            departmentName = departmentName.Replace("'", "''");

            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT Departments.IDDepartment " +
                "FROM Departments " +
                $"WHERE Departments.DepartmentName = '{departmentName}' " +
                "GROUP BY Departments.IDDepartment";
            command = new SqlCommand(sqlQ, connection);
            string idDepartment = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idDepartment;
        }

        public static string GetMaxIDApplicant()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT MAX (IDApplicant) " +
                "FROM Applicants";

            command = new SqlCommand(sqlQ, connection);
            string idApplicant = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idApplicant;
        }

        public static int GetNumberOfDepartmentApplicants(string departmentName)
        {

            string idDepartment = GetDepartmentIndex(departmentName);

            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT COUNT (Applicants.IDApplicant) " +
                "FROM Applicants " + 
                $"WHERE Applicants.IDDepartment = '{idDepartment}'";

            command = new SqlCommand(sqlQ, connection);
            int numOfApplicants = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return numOfApplicants;
        }

        public static int GetNumberOfDepartmentGroups(string idDepartment)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT COUNT(*) " +
                "FROM Groups " +
                $"WHERE IDDepartment = {idDepartment}";

            command = new SqlCommand(sqlQ, connection);
            int numOfGroups = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return numOfGroups;
        }

        public static string GetLastDepartmentGroupIndex(string departmentName)
        {
            string idDepartment = GetDepartmentIndex(departmentName);

            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT MAX(Groups.IDGroup) " +
                $"FROM Groups " +
                $"WHERE Groups.IDDepartment = {idDepartment}";

            command = new SqlCommand(sqlQ, connection);
            string idGroup = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idGroup;
        }

        public static int GetNumOfDepartmentApplicants(string idApplicant)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT Count(*) " +
                "FROM Applicants " +
                $"WHERE IDDepartment = {idApplicant}";

            command = new SqlCommand(sqlQ, connection);
            int num = Convert.ToInt16(command.ExecuteScalar());
            connection.Close();

            return num;
        }

        private static string GetDepartmentIndex(string departmentName)
        {
            departmentName = departmentName.Replace("'", "''");

            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT IDDepartment " +
                "FROM Departments " +
                $"WHERE DepartmentName = '{departmentName}'";

            command = new SqlCommand(sqlQ, connection);
            string idDepartment = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idDepartment;
        }

        public static string GetFacultyID(string facultyName)
        {
            facultyName = facultyName.Replace("'", "''");

            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT IDFaculty " +
                "FROM Faculties " +
                $"WHERE FacultyName = '{facultyName}'";

            command = new SqlCommand(sqlQ, connection);
            string idDepartment = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idDepartment;
        }

        public static DataTable GetUnnecessaryIDSubjects(string idFaculty)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQ = "SELECT FacultySubjects.IDSubject " +
                "FROM FacultySubjects " +
                $"WHERE FacultySubjects.IDFaculty = {idFaculty} AND FacultySubjects.Necessary = 0";

            return GetData(sqlQ);
        }

        public static string GetNecessaryIDSubject(string idFaculty)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQ = "SELECT FacultySubjects.IDSubject " +
                "FROM FacultySubjects " +
                $"WHERE FacultySubjects.IDFaculty = {idFaculty} AND FacultySubjects.Necessary = 1";

            command = new SqlCommand(sqlQ, connection);
            string idSubject = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idSubject;
        }

        public static string GetSubjectID(string subjectName)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQ = "SELECT Subjects.IDSubject " +
                "FROM Subjects " +
                $"WHERE Subjects.SubjectName = '{subjectName}'";

            command = new SqlCommand(sqlQ, connection);
            string idSubject = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idSubject;
        }

        public static string GetIDGroup(string groupName)
        {   
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQ = "SELECT Groups.IDGroup " +
                "FROM Groups " +
                $"WHERE Groups.GroupName = '{groupName}'";

            command = new SqlCommand(sqlQ, connection);
            string idGroup = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return idGroup;
        }

        public static int GetNumberOfGroupApplicants(string idGroup)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT Count(*) " +
                "FROM ApplicantGroup " +
                $"WHERE ApplicantGroup.IDGroup = {idGroup}";

            command = new SqlCommand(sqlQ, connection);
            int numOfApplicants = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return numOfApplicants;
        }

        public static DataTable GetMarksAndCoefficients(string idApplicant)
        {
            string sqlQ = "SELECT Marks.Mark, FacultySubjects.Coefficient " +
                "FROM Applicants INNER JOIN " +
                "Marks ON Applicants.IDApplicant = Marks.IDApplicant INNER JOIN " +
                "Departments ON Applicants.IDDepartment = Departments.IDDepartment INNER JOIN " +
                "Faculties On Departments.IDFaculty = Faculties.IDFaculty INNER JOIN " +
                "FacultySubjects ON Faculties.IDFaculty = FacultySubjects.IDFaculty INNER JOIN " +
                "Subjects ON FacultySubjects.IDSubject = Subjects.IDSubject AND Marks.IDSubject = Subjects.IDSubject " +
                "GROUP BY Marks.Mark, FacultySubjects.Coefficient, Applicants.IDApplicant, Subjects.IDSubject " +
                $"HAVING Applicants.IDApplicant = {idApplicant}";

            return GetData(sqlQ);       
        }

        public static double GetTotalMark(string idApplicant)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQ = "SELECT TotalMarks.TotalMark " +
                "FROM TotalMarks " +
                $"WHERE TotalMarks.IDApplicant = {idApplicant}";

            command = new SqlCommand(sqlQ, connection);
            double totalMark = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return totalMark;
        }
    }  
}
