   M S B A M L   `   `   `  ����W  SUniversityAdmissionCommittee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:UniversityAdmissionCommitteeUniversityAdmissionCommittee  5   	   ;    5UniversityAdmissionCommittee.AddNEditDepartmentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:UniversityAdmissionCommittee     5   	     � Title$  AddNEditDepartmentWindow��5   	   $	��230��6*   $	��560��67    � Icon$" /AddWindows/mainicon (2).png��6C   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   Назва кафедри:6q   �� 5   
   $��2��6   $��14(�6   $��Center=�6+   $
��Left=�6F   .��6a   Факультет:6m   �� 5   
   -   5         ��Name$ departmentNameTextBox��5      $��1��61   $��0��6>   $��14(�6N    �� 	MaxLength$ 80��6\   $��3q�6k   6x   �� 5   
   -   5         ��Name$ facultyComboBox��5      $��3��6,   $��14(�69   $��3q�6G   6T   � 5   
   $��4��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��14(�6   $��Center=�6"   $
��Left=�6=   .��6X   Назва груп:6e   �� 5      $��2��6   $��14(�6$   $��Center=�62   $
��Left=�6M   .��6h    Кількість місць:6z   �� 5      -   5        $ groupsNameTextBox��5      $��1��61   $��14(�6A   $ 15��6O   $��3q�6^   6k   �� 5       -   5        $ studentsNumberTextBox��5       $��3��65   $��14(�6E   $��3q�6S   $ 5��6^   6�   5!      � 5"   
   $��5��6    5#      �� 5$      $��3* �6#   �� 5%      .+�5'      �� -   5         ��Name$ 
saveButton��5'      $��1��6)   $��2q�69   $��14(�6D   6T   5(      5*      5+      