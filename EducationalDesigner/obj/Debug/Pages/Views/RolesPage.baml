   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      /    )EducationalDesigner.Pages.Views.RolesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5      -   5          N� Title$  Роли��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��
cboxSortBy��5      $	��150��6X   .@�5      �� $!��Без сортировки��6   6:   �� 5      $!��По возрастанию��6   6:   �� 5      $��По убыванию��6   67   5      �� 5      -   5         ��Name$ tbSearch��5      6M   5      �� 5   
   $��1��6   .+�5      �� -   5        $��tbkItemCounter��5   T      BlockCommon#��[  6    �� TextAlignment$ Center=�6=   $
��auto��6j   5      �� 5   
   -   5        $��
LViewRoles��5       $��2��6   ��5      �� 5       �� 
TargetType" ��6   .�5       -   5        �� 5!       �� Property � �� �� Value$ 50��6/   �� 5"       � ��$ 14(�61   �� 5#       � ��$
 Bold"�63   5$       �� View 5&      �� 5'      .P�5(      �� $��Название роли��6O   	 �� Width$
	 auto��6f   
 �� DisplayMemberBinding
 6%   �� *
RoleName+6f   5)      5+      �� 5,   
   $��3��6   $	��Top=�6"   $ 
Horizontal=�6:   $��Center=�6S   .+�5-      �� -   5        $��btnPagePrev��5-   F   $��35��6   $��50��6!   $	��←��6,   $��22(�68   6Y   �� 5.      -   5        $��cboxCurrentPageSelection��5.   $   $
��auto��6    �� SelectedIndex$ 0��6�   �� 5/      -	   5        $��btnPageNext��5/   F   $��35��6   $��50��6!   $	��→��6,   $��22(�68   6Y   50      �� 51   
   -
   5        $��btnAdd��52   ;   $��Right=�51      $��3��6-   $��Добавить��52      $y�	Collapsed=�6$   6I   �� 53   
   -   5        $��	btnDelete��54   :   $
��Left=�53      $��3��6,   $��Удалить��54      $y�	Collapsed=�6#   6K   55      56      