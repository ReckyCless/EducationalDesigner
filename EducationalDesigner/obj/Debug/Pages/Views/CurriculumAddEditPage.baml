   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      ;    5EducationalDesigner.Pages.Views.CurriculumAddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5        N� Title$   УП. Добавление��5	      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      �� $��Center=�6   .+�5      �� $ 
Horizontal=�6   $��Right=�66   .+�5      ��    BlockCommon#��[  6    $8��2Образовательная программа*��6E   $
��auto��6g   �� 5      -   5        $��cboxEducationalProgram��5   L    �� DisplayMemberPath$ ProgramName��6j    �� SelectedItem 6   �� *EducationalProgram1+6j   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $��Часов в год*��6E   $
��auto��6Y   �� 5      -   5        ��5      �� *
HourInYear+6e   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $!��Часов в неделю*��6E   $
��auto��6\   �� 5      -   5        ��5      �� *HoursInWeek+6f   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $��Дата начала*��6E   $
��auto��6Y   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpickStartDate��5   !   $	��180��67   $��0q�6C      SelectedDate 6N   �� *	StartDate+5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $&�� Минимальный балл*��6E   $
��auto��6^   �� 5       -   5        ��5       �� *
MinScore+6c   5!      �� 5"      $ 
Horizontal=�6   $��Center=�66   .+�5#      �� -   5        $��btnSave��5#   A   $��30��6   $	��200��6)   $��15q�65   $��Coxpанить��6f   5$      5%      5&      5'      5(      