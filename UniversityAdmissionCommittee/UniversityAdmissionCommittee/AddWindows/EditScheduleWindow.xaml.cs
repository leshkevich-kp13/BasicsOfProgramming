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
using System.Windows.Shapes;
using System.Data;

namespace UniversityAdmissionCommittee
{
    /// <summary>
    /// Interaction logic for EditScheduleWindow.xaml
    /// </summary>
    public partial class EditScheduleWindow : Window
    {
        string idGroup;

        public EditScheduleWindow(string groupName)
        {
            InitializeComponent();
            idGroup = SQLSelectQueries.GetIDGroup(groupName);
            FillGroupScheduleData(groupName);
            this.Title = "Редагувати розклад екзаменів та консультацій";
        }
        private void FillGroupScheduleData(string groupName)
        {
            DataTable schedule = SQLSelectQueries.GetGroupSchedule(idGroup);
            groupNameTextBlock.Text = groupName;
            firstSubject1TextBlock.Text = schedule.Rows[0]["SubjectName"].ToString();
            firstSubject2TextBlock.Text = schedule.Rows[0]["SubjectName"].ToString();
            secondSubject1TextBlock.Text = schedule.Rows[1]["SubjectName"].ToString();
            secondSubject2TextBlock.Text = schedule.Rows[1]["SubjectName"].ToString();
            thirdSubject1TextBlock.Text = schedule.Rows[2]["SubjectName"].ToString();
            thirdSubject2TextBlock.Text = schedule.Rows[2]["SubjectName"].ToString();

            firstSubConsultationTextBox.Text = schedule.Rows[0]["ConsultationDate"].ToString();
            secondSubConsultationTextBox.Text = schedule.Rows[1]["ConsultationDate"].ToString();
            thirdSubConsultationTextBox.Text = schedule.Rows[2]["ConsultationDate"].ToString();

            firstSubExamTextBox.Text = schedule.Rows[0]["ExamDate"].ToString();
            secondSubExamTextBox.Text = schedule.Rows[1]["ExamDate"].ToString();
            thirdSubExamTextBox.Text = schedule.Rows[2]["ExamDate"].ToString();

            firstSubConsultationClassTextBox.Text = schedule.Rows[0]["ConsultationClassroom"].ToString();
            secondSubConsultationClassTextBox.Text = schedule.Rows[1]["ConsultationClassroom"].ToString();
            thirdSubConsultationClassTextBox.Text = schedule.Rows[2]["ConsultationClassroom"].ToString();

            firstSubExamClassTextBox.Text = schedule.Rows[0]["ExamClassroom"].ToString();
            secondSubExamClassTextBox.Text = schedule.Rows[1]["ExamClassroom"].ToString();
            thirdSubExamClassTextBox.Text = schedule.Rows[2]["ExamClassroom"].ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string firstSubjectID = SQLSelectQueries.GetSubjectID(firstSubject1TextBlock.Text);
            string secondSubjectID = SQLSelectQueries.GetSubjectID(secondSubject1TextBlock.Text);
            string thirdSubjectID = SQLSelectQueries.GetSubjectID(thirdSubject1TextBlock.Text);
         
            string firstSubConsultationDate = firstSubConsultationTextBox.Text;
            string secondSubConsultationDate = secondSubConsultationTextBox.Text;
            string thirdSubConsultationDate = thirdSubConsultationTextBox.Text;
            string firstSubExamDate = firstSubExamTextBox.Text;
            string secondSubExamDate = secondSubExamTextBox.Text;
            string thirdSubExamDate = thirdSubExamTextBox.Text;

            try
            {
                firstSubConsultationDate = firstSubConsultationDate != "" ? "'" + Convert.ToDateTime(firstSubConsultationDate).ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                secondSubConsultationDate = secondSubConsultationDate != "" ? "'" + Convert.ToDateTime(secondSubConsultationDate).ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                thirdSubConsultationDate = thirdSubConsultationDate != "" ? "'" + Convert.ToDateTime(thirdSubConsultationDate).ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                firstSubExamDate = firstSubExamDate != "" ? "'" + Convert.ToDateTime(firstSubExamDate).ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                secondSubExamDate = secondSubExamDate != "" ? "'" + Convert.ToDateTime(secondSubExamDate).ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                thirdSubExamDate = thirdSubExamDate != "" ? "'" + Convert.ToDateTime(thirdSubExamDate).ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
            }
            catch
            {
                MessageBox.Show("Некорректне значення дати");
                return;
            }

            SQLUpdateQueries.UpdateGroupSchedule(idGroup, firstSubjectID, firstSubConsultationDate,
                firstSubExamDate, firstSubConsultationClassTextBox.Text, firstSubExamClassTextBox.Text);
            SQLUpdateQueries.UpdateGroupSchedule(idGroup, secondSubjectID, secondSubConsultationDate,
                secondSubExamDate, secondSubConsultationClassTextBox.Text, secondSubExamClassTextBox.Text);
            SQLUpdateQueries.UpdateGroupSchedule(idGroup, thirdSubjectID, thirdSubConsultationDate,
                thirdSubExamDate, thirdSubConsultationClassTextBox.Text, thirdSubExamClassTextBox.Text);

            MessageBox.Show("Зміни збережено");
        }
    }
}
