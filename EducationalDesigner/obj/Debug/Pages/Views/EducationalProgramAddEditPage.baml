   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      C    =EducationalDesigner.Pages.Views.EducationalProgramAddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5        N� Title$   ОП. Добавление��5	      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      �� $��Center=�6   .+�5      �� $ 
Horizontal=�6   $��Right=�66   .+�5      ��    BlockCommon#��[  6    $��Направление*��6E   $
��auto��6Y   �� 5      -   5        $��cboxStudyField��5   C    �� DisplayMemberPath$ StudyFieldName��6Y    �� SelectedItem 6   �� *
StudyField+6Y   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $��Квалификация*��6E   $
��auto��6Z   �� 5      -   5        $��cboxQualification��5   G   $ QualificationName��6`    6   �� *Qualification1+6`   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $��Название*��6E   $
��auto��6V   �� 5      -   5         �� 	MaxLength$	 200��5   d   ��6   �� *ProgramName+6d   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $ ��Дата создания*��6E   $
��auto��6[   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpickCreationDate��5   !   $	��180��6:   $��0q�6F      SelectedDate 6Q   �� *CreationDate+5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $��
Автор��6E   $
��auto��6R   �� 5       -   5        $��cboxAuthors��5    @    6   �� *	Authors+��5!      �� 5"      .R�5#   "   �� ��5$   &   `� 5%   *    �� StringFormat$ {0} {1} {2}��67   .1�5&   .   ��  �� Path$
 Name�66   �� 5'   .   $ Surname�66   �� 5(   .   $ 
Patronymic�66   5)   +   5+   #   5,      5.      5/      �� 50      $ 
Horizontal=�6   $��Center=�66   .+�51      �� -   5        $��btnSave��51   A   $��30��6   $	��200��6)   $��15q�65   $��Coxpанить��6f   52      53      54      55      56      