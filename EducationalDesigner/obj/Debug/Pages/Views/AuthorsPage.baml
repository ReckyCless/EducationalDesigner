   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      1    +EducationalDesigner.Pages.Views.AuthorsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5      -   5          N� Title$  Авторы��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��
cboxSortBy��5      $	��150��6X   .@�5      �� $!��Без сортировки��6   �� 5      $*��$По возрастанию (ФИО)��6   �� 5      $$��По убыванию (ФИО)��6   5      �� 5      -   5        $��	cboxOrdBy��5       �� DisplayMemberPath$ DepartmentName��6V    �� SelectedIndex$ 0��6y   $	��150��6�   �� 5      -   5         ��Name$ tbSearch��5      6(   5      �� 5   
   $��1��6   .+�5      �� -   5        $��tbkItemCounter��5   T      BlockCommon#��[  6    �� TextAlignment$ Center=�6=   $
��auto��6j   5      �� 5   
   -   5        $��LViewAuthors��5       $��2��6   $��Disabled=�64   ��5      �� 5        �� 
TargetType" ��6   .�5!      -   5        �� 5"       �� Property � ��	 �� Value$
	 Left=�6C   �� 5#       � ��$	 Center=�6A   5$      ��5&      �� 5'      .R�5(      � $��Center=�6    
 � Orientation$
 
Horizontal=�6=   5)      ��5+      �� 5,      .R�5-      �  � ColumnDefinitions 5.      �� 50   "   $��* �63   .+�53      �� $��1��6)   .+�54   "   �� $ 
Horizontal=�6-   $��Center=�6F   .+�55   &   ��  	 Photo#��[ 6,   ��56   *   �� 57   .    �� Path$ Photo�66    �� TargetNullValue 58   2   ��59   6   /Resources/default.png��6Z   5;   /   5=   '   5>   #   �� 5?   "   $ 
Horizontal=�6-   .+�5@   &   �� #��[  60   $��Имя:��6U   �� 5A   &     BlockAuthor#��[ 60   ��5B   0   �� *Name+5C   #   �� 5D   "   $ 
Horizontal=�6-   .+�5E   &   �� #��[  60   $��Фамилия:��6U   �� 5F   &   #��[ 60   ��5G   ,   �� *	Surname+5H   #   �� 5I   "   $ 
Horizontal=�6-   .+�5J   &   �� #��[  60   $��Отчество:��6U   �� 5K   &   #��[ 60   ��5L   ,   �� *
Patronymic+5M   #   �� 5N   "   $ 
Horizontal=�6-   .+�5O   &   �� #��[  60   $ ��Дата рождения:��6U   �� 5P   &   #��[ 60   ��5Q   ,   �� *DateOfBirth+ �� StringFormat$ 
dd.MM.yyyy��5R   #   �� 5S   "   $ 
Horizontal=�6-   .+�5T   &   �� #��[  60   $��Факультет:��6U   �� 5U   &   #��[ 60   ��6U   �� *Department1.DepartmentName+5V   #   5W      5X      5Y      5[      �� 5\   
   $��3��6   $	��Top=�6"   $ 
Horizontal=�6:   $��Center=�6S   .+�5]      �� -   5        $��btnPagePrev��5]   F   $��35��6   $��50��6!   $	��←��6,   $��22(�68   6Y   �� 5^      -	   5        $��cboxCurrentPageSelection��5^   $   $
��auto��6   $ 0��6�   �� 5_      -
   5        $��btnPageNext��5_   F   $��35��6   $��50��6!   $	��→��6,   $��22(�68   6Y   5`      �� 5a   
   -   5        $��btnAdd��5b   ;   $��Right=�5a      $��3��6-   $��Добавить��5b      $y�	Collapsed=�6$   6I   �� 5c   
   -   5        $��	btnDelete��5d   :   $
��Left=�5c      $��3��6,   $��Удалить��5d      $y�	Collapsed=�6#   6K   5e      5f      