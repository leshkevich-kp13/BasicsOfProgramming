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
using System.Data;

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for SearchSchedulePage.xaml
    /// </summary>
    public partial class SearchSchedulePage : Page
    {
        public SearchSchedulePage()
        {
            InitializeComponent();
            subjectNameComboBox.SelectedIndex = 0;
            facultyNameComboBox.SelectedIndex = 0;
            departmentNameComboBox.SelectedIndex = 0;
            groupNameComboBox.SelectedIndex = 0;
            FillFacultyNameComboBox();
            FillSubjectComboBox();
        }
        public string Subject { get { return subjectNameComboBox.Text; }}
        public string Faculty { get { return facultyNameComboBox.Text; } }
        public string Department { get { return departmentNameComboBox.Text; } }
        public string Group { get { return groupNameComboBox.Text; } }

        private void FillSubjectComboBox()
        {
            DataTable subjectsTable = SQLSelectQueries.GetAllSubjects();
            subjectNameComboBox.Items.Add("");
            for (int i = 0; i < subjectsTable.Rows.Count; i++)
            {
                subjectNameComboBox.Items.Add(subjectsTable.Rows[i]["SubjectName"].ToString());               
            }
        }

        private void FillFacultyNameComboBox()
        {
            DataTable facultyTable = SQLSelectQueries.GetAllFacultiesNames();
            facultyNameComboBox.Items.Add("");
            for (int i = 0; i < facultyTable.Rows.Count; i++)
            {
                facultyNameComboBox.Items.Add(facultyTable.Rows[i]["FacultyName"].ToString());
            }
        }

        private void FillDepartmentNameComboBox(string facultyName)
        {
            DataTable departmentTable = new DataTable();
            departmentTable = SQLSelectQueries.GetDepartmentsNames(facultyName);
            for (int i = 0; i < departmentTable.Rows.Count; i++)
            {
                departmentNameComboBox.Items.Add(departmentTable.Rows[i]["DepartmentName"].ToString());
            }
        }

        private void FillGroupNameComboBox(string departmentName, string facultyName)
        {
            DataTable groupTable = new DataTable();
            groupTable = SQLSelectQueries.GetGroupsNames(departmentName, facultyName);
            for (int i = 0; i < groupTable.Rows.Count; i++)
            {
                groupNameComboBox.Items.Add(groupTable.Rows[i]["GroupName"].ToString());
            }
        }

        private void FacultyNameComboBox_SelectionChanged(object sender, EventArgs e)
        {
            departmentNameComboBox.SelectionChanged -= DepartmentNameComboBox_SelectionChanged;
            departmentNameComboBox.Items.Clear();
            departmentNameComboBox.SelectionChanged += DepartmentNameComboBox_SelectionChanged;
            departmentNameComboBox.Items.Add("");
            departmentNameComboBox.SelectedIndex = 0;
            FillDepartmentNameComboBox(facultyNameComboBox.SelectedItem.ToString());
        }

        private void DepartmentNameComboBox_SelectionChanged(object sender, EventArgs e)
        {
            groupNameComboBox.Items.Clear();
            groupNameComboBox.Items.Add("");
            groupNameComboBox.SelectedIndex = 0;
            FillGroupNameComboBox(departmentNameComboBox.SelectedItem.ToString(),
                facultyNameComboBox.SelectedItem.ToString());
        }
    }
}
