   M S B A M L   `   `   `  ����  	CargoFlow)    #CargoFlow.Views.ResetPasswordWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Reset Password��5   	   $	��450��6    $	��400��6-    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������ .��5      ��  �� CornerRadius$ 12��6   ._�5	   
   �� $ 10��6   $��2q�5
       J� Opacity$
 0.95Q�5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #003300��6#    � Offset$ 0Q�63   � 5      $ #336600��6#   $
 0.75Q�63   � 5      $ #996633��6#   $ 1Q�63   5      ��5      �� 5      $	 0,1&�6&   $	 1,0&�67   .��5      � $ #000000��6#   $ 0Q�63   � 5      $ #003300��6#   $ 1Q�63   5      ._�5      � 	 � RowDefinitions	 5      �� 5      $��30 �6$   �� 5      .+�5!      � 
 � ColumnDefinitions
 5"      �� 5#      �� 5$      $��25 �6+   �� 5%      $��25 �6+   �� 5&      $��5 �6+   .+�5)      �� $��RESET PASSWORD��6    
�������$��10(�5+      $��
Montserrat)�5,      $��Center=�5-      $��10,0,0,0q�5.      �� 50      -   5         ��Name$ btnClose��50      $��2��51      $��X��52      
�������$��12(�54      $��
Montserrat)�55         CloseButton#��[  57      ��56      �� *CloseCommand+57      58      �� 5;      $��1��6   $��30q�6*   .+�5<      �� $��Reset Password��6    
�������$��24(�5>      $��
Montserrat)�5?      $��Center=�5@      $��0,0,0,20q�5A      �� 5D      $��Username��6    
�������$��
Montserrat)�5F      $
��0,10q�5G      �� 5H        ModernTextbox#��[ 5I      ��5H      �� *
Username+5I      �� 5L      $��Email��6    
�������$��
Montserrat)�5N      $
��0,10q�5O      �� 5P      #��[ 5Q      ��5P      �� *Email+5Q      �� 5T      $��New Password��6    
�������$��
Montserrat)�5V      $
��0,10q�5W      G� 5X      -   5         G�Name$ 
txtNewPass��5X   "     ModernPasswordBox#��[ 5Y       5Z       �� 5]      $��Confirm Password��6    
�������$��
Montserrat)�5_      $
��0,10q�5`      G� 5a      -   5        $ txtConfirmPass��5a   "   #��[ 5b       5c       �� 5f      $��Reset Password��6     ModernButton#��[ 5h      $��0,30,0,0q�5i      ��5g      �� *ResetPasswordCommand+5i      5j      5k      5l      5m      5n      