   M S B A M L   `   `   `  ����W  SUniversityAdmissionCommittee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:UniversityAdmissionCommitteeUniversityAdmissionCommittee  5      5    /UniversityAdmissionCommittee.SearchSchedulePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:UniversityAdmissionCommittee     5        N� Title$  SearchSchedulePage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �  5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $
��220* �6#   �� 5      $
��450* �6#   �� 5      $
��180* �6#   .+�5      �� $��0��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h   Предмет6q   �� 5      $��1��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h   Факультет6s   �� 5      -   5         ��Name$ facultyNameComboBox��5      $��1��64   $��1��6A   $��14(�6Q   $��Center=�6_    �� 
IsReadOnly .   �� 
IsEditable .  �� IsTextSearchEnabled . $��3q�6�   6�   �� 5      -   5        $ subjectNameComboBox��5      $��1��64   $��0��6A   $��14(�6Q   $��Center=�6_    .   .  . $��3q�6�   6�   5      � 5   
   $��1��6    5       �� 5!      �� 5"       5$      �� 5%      $
��560* �6#   �� 5&      $
��110* �6#   �� 5'      $
��180* �6#   .+�5)      �� $��0��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h   Кафедра6q   �� 5*      $��1��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h   
Група6o   �� 5+      -   5        $ departmentNameComboBox��5+      $��1��67   $��0��6D   $��14(�6T   $��Center=�6b    .   .  . $��3,0,3,0q�6�   6  �� 5,      -   5        $ groupNameComboBox��5,      $��1��62   $��1��6?   $��14(�6O   $��Center=�6]    .   .  . $��3,0,3,0q�6�   6�   5-      5.      5/      