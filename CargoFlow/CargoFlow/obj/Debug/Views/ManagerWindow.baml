   M S B A M L   `   `   `  ����D  @CargoFlow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CargoFlow.ViewsCargoFlow.Views  5   	   #    CargoFlow.Views.ManagerWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CargoFlow.Views     5   	     � Title$  ManagerWindow��5   	   $	��720��6   $
��1280��6,    � WindowStyle$
 None=�5	   	    � AllowsTransparency . 
������ .��5      ��  �� CornerRadius$ 12��6   ._�5   
   �� $ 10��6   $��2q�5       J� Opacity$
 0.95Q�5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #003300��6#    � Offset$ 0Q�63   � 5      $ #336600��6#   $
 0.75Q�63   � 5      $ #996633��6#   $ 1Q�63   5      ��5      �� 5      $	 0,1&�6&   $	 1,0&�67   .��5      � $ #000000��6#   $ 0Q�63   � 5      $ #003300��6#   $ 1Q�63   5      ._�5      � 	 � ColumnDefinitions	 5      �� 5       $	��200 �6'   �� 5!      $��* �6'   .+�5%      �� ���#2B2B2B$��0��6.   ._�5&      � .+�5'      �� $��10, 20, 10, 20q�6%   .+�5(      �� $��Manager Panel��6(   
�������$��20(�5*       $
��Bold"�5+       $��Center=�5,       $��Courier New)�5-       $��0 0 0 20q�69   �� 5.      -   5        $��Route Planning��5.   %      
MenuButton#��[  6>   $��32��6�   $��Courier New)�6�   �� 5/      -   5        $��Manage Vehicles��5/   %   #��[  6?   $��32��6�   $��Courier New)�6�   �� 50      -   5        $��Reports��50   %   #��[  67   $��32��6w   $��Courier New)�6�   51      �� 52      -   5        
 ��Name$
 btnExit��52   !   $��         Exit��53   "   #��[  54   !    � Cursor$
 Hand��56   !   $	��Top=�57      $��
0,679,10,0q�58      5:      5;       � 5?      -   5          �Name$ ContentFrame��5?      $��1��5@        � NavigationUIVisibility$ Hidden=�5A      $��10,10,10,10q�5B      5D      5E      5F      5G      