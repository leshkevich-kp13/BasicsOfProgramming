   M S B A M L   `   `   `  ����W  SUniversityAdmissionCommittee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:UniversityAdmissionCommitteeUniversityAdmissionCommittee  5      <    6UniversityAdmissionCommittee.DetailedApplicantInfoPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:UniversityAdmissionCommittee     5        N� Title$  DetailedInfoPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $
��2.5* �6   �� 5      $
��2.5* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5!   
   �� 5"      �� 5#      .+�5%   
   �� $��0��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   ID:6f   �� 5&   
   $��1��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   Прізвище:6l   �� 5'   
   $��2��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   
Ім'я:6h   �� 5(   
   $��3��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   По батькові:6o   �� 5)   
   $��4��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   Паспортні дані:6r   �� 5*   
   $��5��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   $"Навчальний заклад:6u   �� 5+   
   $��6��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a    Дата закінчення:6s   �� 5,   
   $��7��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   Медаль:6j   �� 5-   
   $��8��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   Факультет:6m   �� 5.   
   $��9��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   Кафедра:6k   �� 5/   
   $��10��6   $��14(�6   $��Center=�6,   $
��Left=�6G   .��6b   Група:6j   �� 50   
   $��11��6   $��14(�6   $��Center=�6,   $
��Left=�6G   $��2��6b   $	��236��6v   .��6�   ><Розклад консультацій (каб./дата)):6�   �� 51   
   -   5         ��Name$ firstSubject1TextBlock��51      $��12��64   $��14(�6B   $��Center=�6P   $
��Left=�6k   $��5,0,0,0q�6�   6�   �� 52   
   -   5        $ secondSubject1TextBlock��52      $��13��65   $��14(�6C   $��Center=�6Q   $
��Left=�6l   $��5,0,0,0q�6�   6�   �� 53   
   -   5        $ thirdSubject1TextBlock��53      $��14��64   $��14(�6B   $��Center=�6P   $
��Left=�6k   $��5,0,0,0q�6�   6�   �� 54   
   $��15��6   $��14(�6   $��Center=�6,   $
��Left=�6G   $��2��6b   $	��211��6v   .��6�   86Розклад екзаменів (каб./дата)):6�   �� 55   
   -   5        $ firstSubject2TextBlock��55      $��16��64   $��14(�6B   $��Center=�6P   $
��Left=�6k   $��5,0,0,0q�6�   6�   �� 56   
   -   5        $ secondSubject2TextBlock��56      $��17��65   $��14(�6C   $��Center=�6Q   $
��Left=�6l   $��5,0,0,0q�6�   6�   �� 57   
   -   5        $ thirdSubject2TextBlock��57      $��18��64   $��14(�6B   $��Center=�6P   $
��Left=�6k   $��5,0,0,0q�6�   6�   �� 59   
   -   5        $ idApplicantTextBlock��59      $��0��62   $��1��6?   $��14(�6O   $��Center=�6]   $
��Left=�6x   $
��Wrap=�6�   6�   �� 5:   
   -   5        $ surnameTextBlock��5:      $��1��6.   $��1��6;   $��14(�6K   $��Center=�6Y   $
��Left=�6t   $
��Wrap=�6�   6�   �� 5;   
   -	   5        $ nameTextBlock��5;      $��2��6+   $��1��68   $��14(�6H   $��Center=�6V   $
��Left=�6q   $
��Wrap=�6�   6�   �� 5<   
   -
   5        $ middleNameTextBlock��5<      $��3��61   $��1��6>   $��14(�6N   $��Center=�6\   $
��Left=�6w   $
��Wrap=�6�   6�   �� 5=   
   -   5        $ passportDataTextBlock��5=      $��4��63   $��1��6@   $��14(�6P   $��Center=�6^   $
��Left=�6y   $
��Wrap=�6�   6�   �� 5>   
   -   5        $" educationInstitutonTextBlock��5>      $��5��6:   $��1��6G   $��14(�6W   $��Center=�6e   $
��Left=�6�   $
��Wrap=�6�   6�   �� 5?   
   -   5        $ graduationDateTextBlock��5?      $��6��65   $��1��6B   $��14(�6R   $��Center=�6`   $
��Left=�6{   $
��Wrap=�6�   6�   �� 5@   
   -   5        $ medalTextBlock��5@      $��7��6,   $��1��69   $��14(�6I   $��Center=�6W   $
��Left=�6r   $
��Wrap=�6�   6�   �� 5A   
   -   5        $ facultyTextBlock��5A      $��8��6.   $��1��6;   $��14(�6K   $��Center=�6Y   $
��Left=�6t   $
��Wrap=�6�   6�   �� 5B   
   -   5        $ departmentTextBlock��5B      $��9��61   $��1��6>   $��14(�6N   $��Center=�6\   $
��Left=�6w   $
��Wrap=�6�   6�   �� 5C   
   -   5        $ groupTextBlock��5C      $��10��6,   $��1��6:   $��14(�6J   $��Center=�6X   $
��Left=�6s   $
��Wrap=�6�   6�   �� 5D   
   -   5        $' !firstSubjectConsultationTextBlock��5D      $��12��6?   $��1��6M   $��14(�6]   $��Center=�6k   $
��Left=�6�   $
��Wrap=�6�   6�   �� 5E   
   -   5        $( "secondSubjectConsultationTextBlock��5E      $��13��6@   $��1��6N   $��14(�6^   $��Center=�6l   $
��Left=�6�   $
��Wrap=�6�   6�   �� 5F   
   -   5        $' !thirdSubjectConsultationTextBlock��5F      $��14��6?   $��1��6M   $��14(�6]   $��Center=�6k   $
��Left=�6�   $
��Wrap=�6�   6�   �� 5G   
   -   5        $ firstSubjectExamTextBlock��5G      $��16��67   $��1��6E   $��14(�6U   $��Center=�6c   $
��Left=�6~   $
��Wrap=�6�   6�   �� 5H   
   -   5        $  secondSubjectExamTextBlock��5H      $��17��68   $��1��6F   $��14(�6V   $��Center=�6d   $
��Left=�6   $
��Wrap=�6�   6�   �� 5I   
   -   5        $ thirdSubjectExamTextBlock��5I      $��18��67   $��1��6E   $��14(�6U   $��Center=�6c   $
��Left=�6~   $
��Wrap=�6�   6�   5J      5K      