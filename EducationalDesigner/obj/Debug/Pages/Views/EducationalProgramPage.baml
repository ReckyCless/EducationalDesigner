   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      <    6EducationalDesigner.Pages.Views.EducationalProgramPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5      -   5          N� Title$7  1Образовательные программы��5	   	   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��
cboxSortBy��5      $	��150��6X   .@�5      �� $!��Без сортировки��6   6:   �� 5      $4��.По возрастанию (Название)��6   6E   �� 5      $.��(По убыванию (Название)��6   6B   �� 5      $,��&По возрастанию (Дата)��6   6A   �� 5      $&�� По убыванию (Дата)��6   6>   5      �� 5      -   5         ��Name$ tbSearch��5      6(   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��1��6K   .+�5       �� -   5        $��cboxOrdByStudyField��5        �� DisplayMemberPath$ StudyFieldName��6j    �� SelectedIndex$ 0��6�   $	��150��6�   �� 5!      -   5        $��cboxOrdByQualification��5!      $ QualificationName��6p   $ 0��6�   $	��150��6�   �� 5"      -   5        $��cboxOrdByAuthor��5"      $ 0��6b   $	��150��6t   ��5#      �� 5$      .R�5%      �� ��5&      `� 5'   "    �� StringFormat$ {0} {1} {2}��6/   .1�5(   &   ��  �� Path$
 Name�6.   �� 5)   &   $ Surname�6.   �� 5*   &   $ 
Patronymic�6.   5+   #   5-      5.      50      51      �� 53   
   $��2��6   .+�54      �� -   5        $��tbkItemCounter��54   T      BlockCommon#��[  6    �� TextAlignment$ Center=�6=   $
��auto��6j   55      �� 56   
   -   5        $��LViewEducationalProgram��56       $��3��6   $��Stretch=�6?   ��57      �� 58      	 �� 
TargetType"	 ��6   .�59      -	   5        5:      ��5<      �� 5=      .R�5>      ��   ColorAccent#��[ 6   ._�5?      � 
 � ColumnDefinitions
 5@      �� 5A   "   $��50 �63   �� 5B   "   $��* �63   �� 5C   "   $��* �63   .+�5E      �� $��2��6)   .+�5F   "   �� $ 
Horizontal=�6-   .+�5G   &   ��   BlockStrechMain#��[ 60   ��5H   -   �� *ProgramName+5I   #   �� 5J   "   $ 
Horizontal=�6-   .+�5K   &   ��   BlockCommonSub#��[ 60   $��Направление:��6X   �� 5L   &     BlockStrechSub#��[ 60   ��5M   0   �� *StudyField.StudyFieldName+5N   #   �� 5O   "   $ 
Horizontal=�6-   .+�5P   &   ��   BlockCommonLeft#��[ 60   $��Квалификация:��6Y   �� 5Q   &     BlockStrech#��[ 60   ��5R   ,   �� *" Qualification1.QualificationName+5S   #   �� 5T   "   $ 
Horizontal=�6-   .+�5U   &   �� #��[ 60   $ ��Дата создания:��6Y   �� 5V   &   #��[ 60   ��5W   ,   �� *CreationDate+$ 
dd.MM.yyyy��5X   #   �� 5Y   "   $ 
Horizontal=�6-   .+�5Z   &   �� #��[ 60   $��Автор:��6Y   �� 5[   &   #��[ 60   ��5\   *   `� 5]   .   $ {0} {1} {2}��6;   .1�5^   2   �� $ Authors.Name�6:   �� 5_   2   $ Authors.Surname�6:   �� 5`   2   $ Authors.Patronymic�6:   5a   /   5c   '   5d   #   5e      5f      5g      5h      5j      �� 5k   
   $��4��6   $	��Top=�6"   $ 
Horizontal=�6:   $��Center=�6S   .+�5l      �� -
   5        $��btnPagePrev��5l   F   $��35��6   $��50��6!   $	��←��6,   $��22(�68   6Y   �� 5m      -   5        $��cboxCurrentPageSelection��5m   $   $
��auto��6   $ 0��6�   �� 5n      -   5        $��btnPageNext��5n   F   $��35��6   $��50��6!   $	��→��6,   $��22(�68   6Y   5o      �� 5p   
   -   5        $��btnAdd��5q   ;   $��Right=�5p      $��4��6-   $��Добавить��5q      $y�	Collapsed=�6$   6I   �� 5r   
   -   5        $��	btnDelete��5s   :   $
��Left=�5r      $��4��6,   $��Удалить��5s      $y�	Collapsed=�6#   6K   5t      5u      