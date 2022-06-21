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

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for DetailedDepartmentInfoPage.xaml
    /// </summary>
    public partial class DetailedDepartmentInfoPage : Page
    {
        public DetailedDepartmentInfoPage()
        {
            InitializeComponent();
        }
        public string IDFaculty { get; set; }
        public string IDDepartment { get; set; }

        public string Faculty { set { facultyTextBlock.Text = value; } }
        public string Department { set { departmentTextBlock.Text = value; } }
        public string GroupsName { set { groupsNameTextBlock.Text = value; } }
        public string NumberOfStudents { set { numberOfPlacesTextBlock.Text = value; } }
        public string NumberOfApplicants { set { numberOfApplicantsTextBlock.Text = value; } }
        public string Competition { set { competitionTextBlock.Text = value; } }
        public string FirstSubject { set { firstSubjectTextBlock.Text = value; } }
        public string SecondSubject { set { secondSubjectTextBlock.Text = value; } }
        public string ThirdSubject { set { thirdSubjectTextBlock.Text = value; } }
        public string FirstSubjectCoef { set { firstSubjectCoefTextBlock.Text = value; } }
        public string SecondSubjectCoef { set { secondSubjectCoefTextBlock.Text = value; } }
        public string ThirdSubjectCoef { set { thirdSubjectCoefTextBlock.Text = value; } }
        public string FirstSubjectAvgMark { set { firstSubjectAvgMarkTextBlock.Text = value; } }
        public string SecondSubjectAvgMark { set { secondSubjectAvgMarkTextBlock.Text = value; } }
        public string ThirdSubjectAvgMark { set { thirdSubjectAvgMarkTextBlock.Text = value; } }
    }
}
