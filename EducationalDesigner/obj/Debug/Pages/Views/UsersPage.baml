   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views  5      /    )EducationalDesigner.Pages.Views.UsersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5      -   5          N� Title$  Пользователи��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��
cboxSortBy��5      $	��150��6X   .@�5      �� $!��Без сортировки��6   6:   �� 5      $.��(По возрастанию (Логин)��6   6B   �� 5      $(��"По убыванию (Логин)��6   6?   �� 5      $*��$По возрастанию (ФИО)��6   6@   �� 5      $$��По убыванию (ФИО)��6   6=   5      �� 5      -   5        $��	cboxOrdBy��5       �� DisplayMemberPath$ RoleName��6V    �� SelectedIndex$ 0��6s   $	��150��6�   �� 5      -   5         ��Name$ tbSearch��5      6M   5      �� 5   
   $��1��6   .+�5      �� -   5        $��tbkItemCounter��5   T      BlockCommon#��[  6    �� TextAlignment$ Center=�6=   $
��auto��6j   5      �� 5    
   -   5        $��
LViewUsers��5        $��2��6   ��5!      �� 5"       �� 
TargetType" ��6   .�5#      -   5        �� 5$       �� Property � ��	 �� Value$	 50��6/   �� 5%       � ��$	 14(�61   �� 5&       � ��$
	 Bold"�63   5'      
 �� View
 5)      �� 5*      .P�5+      �� $��
Логин��6L    �� Width$
 auto��6[    �� DisplayMemberBinding 6%   �� *Login+6[   �� 5,      $��Пароль��6O   $
 auto��6_    6%   �� *
Password+6_   �� 5-      $��Имя��6K   $
 auto��6X    6%   �� *Name+6X   �� 5.      $��Фамилия��6N   $
 auto��6_    6%   �� *	Surname+6_   �� 5/      $��Отчество��6Q   $
 auto��6c    6%   �� *
Patronymic+6c   �� 50      $��
Почта��6L   $
 auto��6[    6%   �� *Email+6[   �� 51      $��Роль��6U   $
 auto��6c    6%   �� *Roles.RoleName+6c   52      54      �� 55   
   $��3��6   $	��Top=�6"   $ 
Horizontal=�6:   $��Center=�6S   .+�56      �� -   5        $��btnPagePrev��56   F   $��35��6   $��50��6!   $	��←��6,   $��22(�68   6Y   �� 57      -	   5        $��cboxCurrentPageSelection��57   $   $
��auto��6   $ 0��6�   �� 58      -
   5        $��btnPageNext��58   F   $��35��6   $��50��6!   $	��→��6,   $��22(�68   6Y   59      �� 5:   
   -   5        $��btnAdd��5;   ;   $��Right=�5:      $��3��6-   $��Добавить��5;      $y�	Collapsed=�6$   6I   �� 5<   
   -   5        $��	btnDelete��5=   :   $
��Left=�5<      $��3��6,   $��Удалить��5=      $y�	Collapsed=�6#   6K   5>      5?      