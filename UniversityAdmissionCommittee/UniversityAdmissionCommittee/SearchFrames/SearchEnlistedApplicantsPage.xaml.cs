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
using System.Data;
using System.Windows.Shapes;

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for SearchEnlistedApplicantsPage.xaml
    /// </summary>
    public partial class SearchEnlistedApplicantsPage : Page
    {
        public SearchEnlistedApplicantsPage()
        {
            InitializeComponent();
            FillFacultyNameComboBox();
        }
        public string Department { get { return departmentNameComboBox.Text; } }

        private void FillFacultyNameComboBox()
        {
            DataTable facultyTable = SQLSelectQueries.GetAllFacultiesNames();
            for (int i = 0; i < facultyTable.Rows.Count; i++)
            {
                facultyNameComboBox.Items.Add(facultyTable.Rows[i]["FacultyName"].ToString());
            }
            facultyNameComboBox.SelectedIndex = 0;
        }

        private void FillDepartmentNameComboBox(string facultyName)
        {
            DataTable departmentTable = SQLSelectQueries.GetDepartmentsNames(facultyName);
            for (int i = 0; i < departmentTable.Rows.Count; i++)
            {
                departmentNameComboBox.Items.Add(departmentTable.Rows[i]["DepartmentName"].ToString());
            }
        }

        private void FacultyNameComboBox_SelectionChanged(object sender, EventArgs e)
        {
            departmentNameComboBox.Items.Clear();         
            FillDepartmentNameComboBox(facultyNameComboBox.SelectedItem.ToString());
            departmentNameComboBox.SelectedIndex = 0;
        }

    }
}
