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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchApplicantPage : Page
    {
        public SearchApplicantPage()
        {
            InitializeComponent();
            idApplicantTextBox.Text = "";
            surnameTextBox.Text = "";
            nameTextBox.Text = "";
            middleNameTextBox.Text = "";
            facultyNameComboBox.Items.Add("");
            facultyNameComboBox.SelectedIndex = 0;
            departmentNameComboBox.SelectedIndex = 0;
            groupNameComboBox.SelectedIndex = 0;
            FillFacultyNameComboBox();              
        }

        public string IDApplicant { get { return idApplicantTextBox.Text; } }
        public string Surname { get { return surnameTextBox.Text; } }
        public string Name { get { return nameTextBox.Text; } }
        public string MiddleName { get { return middleNameTextBox.Text; } }
        public string Faculty { get { return facultyNameComboBox.Text; } }
        public string Department { get { return departmentNameComboBox.Text; } }
        public string Group { get { return groupNameComboBox.Text; } }

        private void FillFacultyNameComboBox()
        {
            DataTable facultyTable = SQLSelectQueries.GetAllFacultiesNames();
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
