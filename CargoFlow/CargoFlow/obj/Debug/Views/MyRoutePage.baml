   M S B A M L   `   `   `  ����  	CargoFlow!    CargoFlow.Views.MyRoutePage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  My Route��5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��My Route Details��6   $��24(�5      $
��Bold"�5      $��
Montserrat)�5      ���#D3D3D3$��0,0,0,20q�5      &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns .     
IsReadOnly . 
������    RowBackground �#3D3D3D   AlternatingRowBackground �#4D4D4D���#666666
�������   GridLinesVisibility$	 All=�5      ��5      �� *
MyRoutes+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType	 �� Property
 �� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType��%A  '        '      �� 5       "  6   .�5!      �� 	 � ��
 �#2B2B2B63   �� 5"      	 � ��

 �����63   �� 5#      	 � ��$

 10,5q�60   �� 5$      	 � ��
 �#66666664   �� 5%      	 � ��$
 0,0,1,1q�68   �� 5&      	 � ��$
 
Montserrat)�63   5'      �� 5(      "  6   .�5)      �� 	 � ��$
 0q�68   �� 5*      	 � ��$

 10,5q�60   �� 5+      	 � ��
 5,      �� 5-      "  6.   .R�5.   "   �� #��z��6)   $��0q�5/   )   ._�50   &   �� $��Center=�67   51   #   52      54      55      56         Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Route Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5;   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5:   #   �� *Route.RouteName+5;   #     5<      $ Start Location��6%   $
 Auto 5>   #    5=   #   �� *Route.StartLocation+5>   #     5?      $ End Location��6%   $
 Auto 5A   #    5@   #   �� *Route.EndLocation+5A   #     5B      $ 
Start Time��6%   $
 Auto 5D   #    5C   #   �� *EstimatedStartTime+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}��5D   #     5E      $ End Time��6%   $
 Auto 5G   #    5F   #   �� *EstimatedEndTime+$ {0:dd/MM/yyyy HH:mm}��5G   #   5I      5J      5K      