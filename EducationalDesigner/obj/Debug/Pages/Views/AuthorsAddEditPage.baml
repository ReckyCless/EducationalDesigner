   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      N JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EducationalDesigner.Pages.ViewsEducationalDesigner.Pages.Views 5      8   2EducationalDesigner.Pages.Views.AuthorsAddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9System&clr-namespace:System;assembly=mscorlib     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:EducationalDesigner.Pages.Views     5        N� Title$(  "Авторы. Добавление��5
      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      �� $��Center=�6   .+�5      �� -   5        $��PasswordValidationErr��5   �   $
��Wrap=�6   $	��180��60   $y�	Collapsed=�6<   $���zТолько латиница, числа и спец. символы (!, _, $...), как минимум 4 символа��6S   $��Right=�6�   
���  ��6�   �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      ��    BlockCommon#��[  6    $��Имя*��6E   $
��auto��6Q   �� 5      -   5         �� 	MaxLength$	 150��5   �   ��6   �� *Name+6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $��Фамилия*��6E   $
��auto��6U   �� 5      -   5        $	 150��5   �   ��6   �� *	Surname+6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $��Отчество��6E   $
��auto��6U   �� 5      -   5        $	 150��5   �   ��6   �� *
Patronymic+6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� #��[  6    $ ��Дата рождения*��6E   $
��auto��6[   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpickBirthDate��5   !   $	��180��67   $��0q�6C      SelectedDate 6N   �� *DateOfBirth+5      �� 5       $ 
Horizontal=�6   $��Right=�66   .+�5!      �� #��[  6    $��Факультет*��6E   $
��auto��6W   �� 5"      -   5        $��cboxDepartment��5"   D    �� DisplayMemberPath$ DepartmentName��6Z   $
��auto��6}    �� SelectedItem 6   �� *Department1+6}   5#      5$      �� 5%      $ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5&      �� $��Center=�6   .+�5'      �� $��Center=�6!   $��Center=�6>   .+�5(      �� $��5q�6!   $	��350��6,   $	��400��69     ColorAccent#��[ 6E   $��1q�6p   ._�5)      �� -   5        $��ImageService��5)   $   5*      �� 5+      -   5        $��btnSelectImage��5+   D   $��30��6!   $	��200��6-   $��5q�69   $)��#Выбрать фотографию��6w   �� 5,      -	   5        $��btnSave��5,   D   $��30��6!   $	��200��6-   $��5q�69   $��Coxpанить��6i   5-      5.      5/      50      52      53      