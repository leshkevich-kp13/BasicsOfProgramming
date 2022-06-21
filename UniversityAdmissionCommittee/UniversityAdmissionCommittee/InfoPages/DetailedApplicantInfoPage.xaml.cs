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
    /// Interaction logic for DetailedInfoPage.xaml
    /// </summary>
    public partial class DetailedApplicantInfoPage : Page
    {
        public DetailedApplicantInfoPage()
        {
            InitializeComponent();
        }
        public string IDApplicant { set { idApplicantTextBlock.Text = value; } }
        public string Surmane { set { surnameTextBlock.Text = value; } }
        public string Name { set { nameTextBlock.Text = value; } }
        public string MiddleName { set { middleNameTextBlock.Text = value; } }
        public string PassportData { set { passportDataTextBlock.Text = value; } }
        public string EducationInstitution { set { educationInstitutonTextBlock.Text = value; } }
        public string GraduationDate { set { graduationDateTextBlock.Text = value; } }
        public string Medal { set { medalTextBlock.Text = value; } }
        public string Faculty { set { facultyTextBlock.Text = value; } }
        public string Department { set { departmentTextBlock.Text = value; } }
        public string Group { set { groupTextBlock.Text = value; } }
        public string FirstSubject { set { firstSubject1TextBlock.Text = value + ":"; firstSubject2TextBlock.Text = value + ":"; } }
        public string SecondSubject { set { secondSubject1TextBlock.Text = value + ":"; secondSubject2TextBlock.Text = value + ":"; } }
        public string ThirdSubject { set { thirdSubject1TextBlock.Text = value + ":"; thirdSubject2TextBlock.Text = value + ":"; } }
        public string FirstSubjectConsultation { set { firstSubjectConsultationTextBlock.Text = value; } }
        public string SecondSubjectConsultation { set { secondSubjectConsultationTextBlock.Text = value; } }
        public string ThirdSubjectConsultation { set { thirdSubjectConsultationTextBlock.Text = value; } }
        public string FirstSubjectExam { set { firstSubjectExamTextBlock.Text = value; } }
        public string SecondSubjectExam { set { secondSubjectExamTextBlock.Text = value; } }
        public string ThirdSubjectExam { set { thirdSubjectExamTextBlock.Text = value; } }
    }
}
