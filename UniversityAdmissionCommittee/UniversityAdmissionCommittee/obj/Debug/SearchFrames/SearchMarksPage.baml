   M S B A M L   `   `   `  ����W  SUniversityAdmissionCommittee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:UniversityAdmissionCommitteeUniversityAdmissionCommittee  5      2    ,UniversityAdmissionCommittee.SearchMarksPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:UniversityAdmissionCommittee     5        N� Title$  SearchMarksPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �  5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $	��70* �6#   �� 5      $
��110* �6#   �� 5      $
��110* �6#   �� 5      $
��110* �6#   �� 5      $
��450* �6#   .+�5      �� $��0��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6i   ID6m   �� 5      $��1��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6i   Прізвище6s   �� 5      $��2��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6i   	Ім'я6o   �� 5      $��3��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6i   По батькові6v   �� 5       $��4��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6i   Факультет6t   �� 5!      -   5         ��Name$ idApplicantTextBox��5!      $��1��62   $��0��6?   $��14(�6O   $��Center=�6]   $��3q�6x   6�   �� 5"      -   5        $ surnameTextBox��5"      $��1��6.   $��1��6;   $��14(�6K   $��Center=�6Y   $��3q�6t   6�   �� 5#      -   5        $ nameTextBox��5#      $��1��6+   $��2��68   $��14(�6H   $��Center=�6V   $��3q�6q   6~   �� 5$      -   5        $ middleNameTextBox��5$      $��1��61   $��3��6>   $��14(�6N   $��Center=�6\   $��3q�6w   6�   �� 5%      -   5         ��Name$ facultyNameComboBox��5%      $��1��64   $��4��6A   $��14(�6Q   $��Center=�6_    �� 
IsReadOnly .   �� 
IsEditable .  �� IsTextSearchEnabled . $��3q�6�   6�   5&      � 5'   
   $��1��6    5(      �� 5)      �� 5*       5,      �� 5-      $
��180* �6#   �� 5.      $
��560* �6#   �� 5/      $
��110* �6#   .+�51      �� $��1��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h   Кафедра6q   �� 52      $��3��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h   
Група6o   �� 53      $��0��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h   Предмет6q   �� 54      -   5        $ subjectNameComboBox��54      $��1��64   $��0��6A   $��14(�6Q   $��Center=�6_   $��3,0,3,0q�6z   6�   �� 55      -   5        $ departmentNameComboBox��55      $��1��67   $��1��6D   $��14(�6T   $��Center=�6b   $��3,0,3,0q�6}   6�   �� 56      -   5        $ groupNameComboBox��56      $��1��62   $��3��6?   $��14(�6O   $��Center=�6]   $��3,0,3,0q�6x   6�   57      58      59      