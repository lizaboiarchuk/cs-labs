   M S B A M L   `   `   `  ����  	PeopleApp     PeopleApp.Views.PersonView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��First Name:��6   $��0��6&   $��0��63   �� 5   
   $��0��6a   $��1��6n   ��6   �� *SelectedPerson.FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6n   �� 5   
   $��
Last Name:��6   $��1��6%   $��0��62   �� 5   
   $��1��6`   $��1��6m   ��6   �� *SelectedPerson.LastName+$ PropertyChanged=�6m   �� 5   
   $��Date of Birth:��6   $��2��6)   $��0��66   (  "System.Windows.Controls.DatePicker  5   
   $��2��6n   $��1��6{      SelectedDate 6   �� *SelectedPerson.DateOfBirth+$ PropertyChanged=�6{   5      5       