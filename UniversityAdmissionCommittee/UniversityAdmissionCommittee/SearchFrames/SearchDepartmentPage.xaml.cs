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
    /// Interaction logic for SearchDepartmentPage.xaml
    /// </summary>
    public partial class SearchDepartmentPage : Page
    {
        public SearchDepartmentPage()
        {
            InitializeComponent();
            FillFacultyNameComboBox();
        }

        public string Faculty { get { return facultyNameComboBox.SelectedItem.ToString(); } }

        private void FillFacultyNameComboBox()
        {
            facultyNameComboBox.Items.Add("");
            DataTable facultyTable = SQLSelectQueries.GetAllFacultiesNames();
            for (int i = 0; i < facultyTable.Rows.Count; i++)
            {
                facultyNameComboBox.Items.Add(facultyTable.Rows[i]["FacultyName"].ToString());
            }
            facultyNameComboBox.SelectedIndex = 0;
        }
    }
}
