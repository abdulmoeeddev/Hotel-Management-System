   M S B A M L   `   `   `  ����G  CHotelBooking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HotelBooking.MainHotelBooking.Main  5          HotelBooking.Main.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HotelBooking.Main     5      
�������.��5
      �   � ColumnDefinitions  5   
   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   �� 5      $
��0.5* �6   6.   �� 5      $��2* �6   6,   �� 5      $��3* �6   6,    � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��2* �6   6*   .+�5   
   �� -   5        $��lblTitle��5      $��Welcome Back...��5      $��0��5      $��1��5       $��3��5!      $��Center=�5"      $��Center=�5#      $��20(�5$      $
��Bold"�5%      5'      � 5*   
   $��1��6   $��1��6   .+�5+      �� -   5        $��lblUsername��5+      ���	#FF6D0000$��Username��5-      $��12(�5.      $��Center=�5/      $��Right=�50      $��0,0,10,0q�51      6$   52      � 53   
   $��1��6   $��3��6   .+�54      �� -   5        $��txtName��56      ���	#FF6D0000 J� Opacity$ 1Q�55       �� SelectionBrush �	#FF6D0000
�������.��58   $   5:      5;      � 5?   
   $��3��6   $��1��6   .+�5@      �� -   5        $��lblPassword��5@      ���	#FF6D0000$��Password��5B      $��12(�5C      $��Center=�5D      $��Right=�5E      $��0,0,10,0q�5F      6$   5G      � 5H   
   $��3��6   $��3��6   .+�5I      �� -   5        $��txtPassword��5K      ���	#FF6D0000$ 1Q�5J       �	#FF6D0000
�������.��5M   $   5N      5O      �� 5R   
   -   5        $��	lblCreate��5R      $��Create a New One !��5S      $��4��5T      $��3��5U      $��Center=�5V      $��Center=�5W      $��Right=�5X      
����  �5[      � 5]   
   $��5��6   $��3��6     5^      �� 5_      6%   �� 5`      6%   .+�5c      �� -   5        $��btnLogin��5c      $��0��5d      $��3q�5e      $��Log In��5f      ���	#FF6D0000
�������
�������5l      �� 5m      -   5        $��btnBack��5m      $��1��5n      $��3q�5o      $��Cancel��5p      ���	#FF6D0000
�������
�������5v      5w      5x      5y      