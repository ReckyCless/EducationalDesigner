   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      4    .EducationalDesigner.Pages.Views.CurriculumPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5      -   5          N� Title$  Учебные планы��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��
cboxSortBy��5      $	��150��6X   .@�5      �� $!��Без сортировки��6   6:   �� 5      $4��.По возрастанию (Название)��6   6E   �� 5      $.��(По убыванию (Название)��6   6B   �� 5      $,��&По возрастанию (Дата)��6   6A   �� 5      $&�� По убыванию (Дата)��6   6>   �� 5      $,��&По возрастанию (Балл)��6   6A   �� 5      $&�� По убыванию (Балл)��6   6>   5      �� 5      -   5        $!��cboxOrdByEducationalProgram��5       �� DisplayMemberPath$ ProgramName��6z    �� SelectedIndex$ 0��6�   $	��150��6�   �� 5      -   5         ��Name$ tbSearch��5      6(   5      �� 5   
   $��1��6   .+�5       �� -   5        $��tbkItemCounter��5    T      BlockCommon#��[  6    �� TextAlignment$ Center=�6=   $
��auto��6j   5!      �� 5"   
   -   5        $��LViewCurriculum��5"       $��2��6   $��Stretch=�67   ��5#      �� 5$       �� 
TargetType" ��6   .�5%      -   5        5&      ��5(      �� 5)      .R�5*      ��   ColorAccent#��[ 6   ._�5+      �  � ColumnDefinitions 5,      �� 5-   "   $��50 �63   �� 5.   "   $��* �63   �� 5/   "   $��* �63   .+�51      �� $��1��6)   .+�52   "   �� $ 
Horizontal=�6-   .+�53   &   ��   BlockStrechMain#��[ 60   ��54   0   �� *!EducationalProgram1.ProgramName+55   #   �� 56   "   $ 
Horizontal=�6-   .+�57   &   ��   BlockCommonSub#��[ 60   $��Часов в год:��6X   �� 58   &     BlockStrechSub#��[ 60   ��59   ,   �� *
HourInYear+5:   #   �� 5;   "   $ 
Horizontal=�6-   .+�5<   &   �� #��[ 60   $!��Часов в неделю:��6X   �� 5=   &   #��[ 60   ��5>   ,   �� *HoursInWeek+5?   #   �� 5@   "   $ 
Horizontal=�6-   .+�5A   &   ��   BlockCommonLeft#��[ 60   $��Дата начала:��6Y   �� 5B   &     BlockStrech#��[ 60   ��5C   ,   �� *	StartDate+	 �� StringFormat$	 
dd.MM.yyyy��5D   #   �� 5E   "   $ 
Horizontal=�6-   .+�5F   &   �� #��[ 60   $&�� Минимальный балл:��6Y   �� 5G   &   #��[ 60   #��[ 6Y   ��5H   -   �� *
MinScore+5I   #   5J      5K      5L      5M      5O      �� 5P   
   $��3��6   $	��Top=�6"   $ 
Horizontal=�6:   $��Center=�6S   .+�5Q      �� -   5        $��btnPagePrev��5Q   F   $��35��6   $��50��6!   $	��←��6,   $��22(�68   6Y   �� 5R      -	   5        $��cboxCurrentPageSelection��5R   $   $
��auto��6   $ 0��6�   �� 5S      -
   5        $��btnPageNext��5S   F   $��35��6   $��50��6!   $	��→��6,   $��22(�68   6Y   5T      �� 5U   
   -   5        $��btnAdd��5V   ;   $��Right=�5U      $��3��6-   $��Добавить��5V      $y�	Collapsed=�6$   6I   �� 5W   
   -   5        $��	btnDelete��5X   :   $
��Left=�5W      $��3��6,   $��Удалить��5X      $y�	Collapsed=�6#   6K   5Y      5Z      