   M S B A M L   `   `   `  ����L  Hcapa_presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:capa_presentacioncapa_presentacion  5   	   '    !capa_presentacion.PrincipalWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:capa_presentacion     5   	   -   5          � Title$  FormPrincipal��5   	   $	��960��6   $
��1280��6,    � WindowStartupLocation$ CenterScreen=�69    � 
ResizeMode$ NoResize=�5	   	   .��5
      � .+�5   
   � $	��891��6   $	��Top=�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��3* �6#   .+�5      o� $��Gill Sans Ultra Bold)�6   $��25(�65   $��0��6C   
���������5      �� 5      .R�5      $�  $� Orientation$ Vertical=�61   5      .@�5      m� -   5         m�Name$ lblUsuarioAPP��5      $��80��64   $
��0,20q�6@   $��        _Usuarios APP��5       m� Icon 5      �� 5      $��imgs/mundial_rusia.jpg��5      $��0,-22,-57,-20q�5       $
��Fill=�67   5       m� 5!      -   5        $��        _Jugadores��5!   3   $��80��5"      $
��0,20q�6'    5#      �� 5$      $&�� imgs/Fondo rojo claro-653345.png��5%      $��0,-22,-57,-20q�5&       $
��Fill=�67   5(      m� 5)      -   5        $��        _Equipos��5)   1   $��80��5*      $
��0,20q�6'    5+      �� 5,      $6��0imgs/noticia-mundial-rusia-2018-inauguracion.png��5-      $��0,-22,-57,-20q�5.       $
��Fill=�67   50      m� 51      -   5        $��        _Partidos��51   2   $��80��52      $
��0,20q�6'    53      �� 54      $��imgs/mundial-futuro.jpg��55      $��0,-22,-57,-20q�56       $
��Fill=�67   58      m� 59      $��        _Informes��6   $��80��5:      $
��0,20q�6'    5;      �� 5<      $��imgs/mundial_rusia.jpg��5=      $��0,-22,-57,-20q�5>       $
��Fill=�67   .@�5@      m� -   5        $��        _Un partido��5@   <   $��80��5A        5B      �� 5C      $z��tC:\Users\jkh9L\Desktop\Repositories\Encinas_Moises_MundialDAM_WPF\capa_presentacion\imgs\Fondo rojo claro-653345.png��5D   !   $��0,-22,-57,-20q�5E   $   $
��Fill=�6;   5G      m� 5H      -   5        $+��%        _Clasificación de un mundial��5I      $��80��5J        5K      �� 5L      $z��tC:\Users\jkh9L\Desktop\Repositories\Encinas_Moises_MundialDAM_WPF\capa_presentacion\imgs\Fondo rojo claro-653345.png��5M   !   $��0,-22,-57,-20q�5N   $   $
��Fill=�6;   5P      5Q      5R      � 5T      -   5         �Name$ VentanaContenedora��5T      $��1��6/   
���  ��6?   5U      �� 5W   
   $��Bottom=�6   $��40��6/   $��Arial)�6;   $��15(�6N   .@�5X      �� $	��100��6   .��5Y      �� -	   5         ��Name$ lblHoraSistema��5Y      
00:00:005[      5\      �� 5]      $	��100��6   .��5^      �� -
   5        $ lblHorasUso��5^      
00:00:005`      5a      �� 5b      $	��100��6   .��5c      �� -   5        $ 	lblNombre��5c      Moisex5e      5f      �� 5g      $	��100��6   .��5h      �� -   5        $ lblTipo��5h      Administrador5j      5k      �� 5l      $��Center=�6   .��5m      �� -   5        $ 	lblStatus��5m      $	��867��5n      $��10,0,0,0q�6(   5o      5p      �� 5q      5r      5s      5t      5u      