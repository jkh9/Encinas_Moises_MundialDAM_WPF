   M S B A M L   `   `   `  ����L  Hcapa_presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:capa_presentacioncapa_presentacion  5   	   #    capa_presentacion.LogInWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:capa_presentacion     5   	   -   5        $	��450��5   	   $	��800��6     � WindowStartupLocation$  CenterScreen=�6"    � 
ResizeMode$ NoResize=�6G   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   � $��0��6   ��5      �� 5       �� ImageSource$ imgs/mundial_rusia.jpg��6   5      � 5   
   $��1��6   ��5      �� 5      $&  imgs/Fondo rojo claro-653345.png��6    j� Stretch$ UniformToFill=�6L   .+�5      �� $��Black"�6   $��Arial)�5      $��Center=�6(   $��160,46,192,315q�5      $��50(�6-   LOGIN5      �� 5!      -   5         ��Name$ 
txtUsuario��5!      $��Georgia)�6*   $��Center=�6?   $��20(�5"      
���""��$��10q�5#   -   $	��350��5$      $��50��6"   $��
0,-100,0,0q�6.   .��6B   5%      G� 5&      -   5         G�Name$ txtPass��5&      $��Georgia)�6+   $��Center=�6@   $��20(�5'      
���""��$��10q�5(   -   $	��350��5)      $��50��6"   $��0,80,0,0q�6.    G� PasswordChar$ *��6@   5*      �� 5+      -   5         ��Name$ 
btnAcceder��5+      $��Arial)�6)   $��30(�6<   ���	#FFC97676
���""��$��1q�5-   -   $��
0,334,0,32q�5.      $	��350��6)   ��5,   ,   Z� .��5.   N   	Acceder50      52      53      54      