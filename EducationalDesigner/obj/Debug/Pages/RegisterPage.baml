   M S B A M L   `   `   `  ����N  JEducationalDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EducationalDesigner.PagesEducationalDesigner.Pages  5      ,    &EducationalDesigner.Pages.RegisterPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:EducationalDesigner.Pages     5        N� Title$  Регистрация��5	   	   .��5      � .+�5   
   �� $��Center=�6   $��Center=�62   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      ��    BlockCommon#��[  6   $��Логин*��6A   $
��auto��6O   �� 5      -   5        $��11 5 0 5q�5       �� 	MaxLength$	 150��6�   ��6,   �� *Login+6�   5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� #��[  6   $��Пароль*��6A   $
��auto��6P   G� 5      -   5        $��
tbPassword��5       G� 	MaxLength$	 150��6�   5      �� 5      -   5        $��PasswordValidationErr��5   k   $
��Wrap=�6   $	��180��6,   $y�	Collapsed=�68   $��Right=�6O   
���  ��6�   �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� #��[  6   $��Повтор*��6A   $
��auto��6P   G� 5      -   5        $��tbPasswordRepeat��5      $	 150��6�   5      �� 5      -   5        $!��PasswordRepeatValidationErr��5   k   $
��Wrap=�6   $	��180��6,   $y�	Collapsed=�68   $��Right=�6O   
���  ��6�   �� 5      $��27 5 0 5q�6   $ 
Horizontal=�6+   $��Center=�6D   .+�5      �� #��[  6   $��Имя*��6A   $
��auto��6M   �� 5      -   5        $	 150��5   �   ��6   �� *Name+6�   5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5       �� $��0 5 0 5q�6   #��[  6-   $��Фамилия*��6R   $
��auto��6b   �� 5!      -   5        $	 150��5!   �   ��6   �� *	Surname+6�   5"      �� 5#      $ 
Horizontal=�6   $��Center=�62   .+�5$      �� $��7 5 0 5q�6   #��[  6-   $��Отчество��6R   $
��auto��6b   �� 5%      -   5        $	 150��5%   �   ��6   �� *
Patronymic+6�   5&      �� 5'      $ 
Horizontal=�6   $��Center=�62   .+�5(      �� #��[  6   $��Почта*��6A   $
��auto��6O   �� 5)      -	   5        $��tbEmail��5)   C   $��11 5 0 5q�6   $	 150��6�   ��6,   �� *Email+6�   5*      �� 5+      -
   5        $��EmailValidationErr��5+   l   $
��Wrap=�6   $	��180��6,   $y�	Collapsed=�68   $��Right=�6P   
���  ��6�   �� 5,      $��Center=�6   .+�5-      �� -   5        $��btnRegister��5-      $&�� Зарегистрировать��6F   �� 5.      -   5        $��
btnToLogin��5.   N   #��[  6   $
��auto��6A   �� 6a   -   5        .�5.   �   Войти в аккаунт?6�   6�   5/      50      51      52      