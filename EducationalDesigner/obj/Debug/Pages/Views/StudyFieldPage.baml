   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      4    .EducationalDesigner.Pages.Views.StudyFieldPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5      -   5          N� Title$  Направления��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��
cboxSortBy��5      $	��150��6X   .@�5      �� $!��Без сортировки��6   6:   �� 5      $!��По возрастанию��6   6:   �� 5      $��По убыванию��6   67   5      �� 5      -   5        $��	cboxOrdBy��5       �� DisplayMemberPath$ DepartmentName��6V    �� SelectedIndex$ 0��6y   $	��150��6�   �� 5      -   5         ��Name$ tbSearch��5      6M   5      �� 5   
   $��1��6   .+�5      �� -   5        $��tbkItemCounter��5   T      BlockCommon#��[  6    �� TextAlignment$ Center=�6=   $
��auto��6j   5      �� 5   
   -   5        $��LViewStudyFields��5       $��2��6   ��5      �� 5        �� 
TargetType" ��6   .�5!      -   5        �� 5"       �� Property � ��	 �� Value$	 50��6/   �� 5#       � ��$	 14(�61   �� 5$       � ��$
	 Bold"�63   5%      
 �� View
 5'      �� 5(      .P�5)      �� $-��'Название направления��6U    �� Width$
 auto��6s    �� DisplayMemberBinding 6%   �� *StudyFieldName+6s   �� 5*      $+��%Название факультета��6a   $
 auto��6~    6%   �� *Department1.DepartmentName+6~   5+      5-      �� 5.   
   $��3��6   $	��Top=�6"   $ 
Horizontal=�6:   $��Center=�6S   .+�5/      �� -   5        $��btnPagePrev��5/   F   $��35��6   $��50��6!   $	��←��6,   $��22(�68   6Y   �� 50      -	   5        $��cboxCurrentPageSelection��50   $   $
��auto��6   $ 0��6�   �� 51      -
   5        $��btnPageNext��51   F   $��35��6   $��50��6!   $	��→��6,   $��22(�68   6Y   52      �� 53   
   -   5        $��btnAdd��54   ;   $��Right=�53      $��3��6-   $��Добавить��54      $y�	Collapsed=�6$   6I   �� 55   
   -   5        $��	btnDelete��56   :   $
��Left=�55      $��3��6,   $��Удалить��56      $y�	Collapsed=�6#   6K   57      58      