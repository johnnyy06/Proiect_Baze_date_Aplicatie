   M S B A M L   `   `   `  ����D  @CargoFlow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CargoFlow.ViewsCargoFlow.Views  5      #    CargoFlow.Views.MyReportsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CargoFlow.Views     5        N� Title$  
My Reports��5      .��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��
My Reports��6   $��24(�5      $
��Bold"�5      $��
Montserrat)�5      ���#D3D3D3$��0,0,0,20q�5      &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns .     
IsReadOnly . 
������    RowBackground �#3D3D3D   AlternatingRowBackground �#4D4D4D���#666666
�������   GridLinesVisibility$	 All=�5"      ��5      �� *	Reports+ � 	Resources 5#      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType	 �� Property
 �� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType��%A  '        '      �� 5$      "  6   .�5%      �� 	 � ��
 �#2B2B2B63   �� 5&      	 � ��

 �����63   �� 5'      	 � ��$

 10,5q�60   �� 5(      	 � ��
 �#66666664   �� 5)      	 � ��$
 0,0,1,1q�68   �� 5*      	 � ��$
 
Montserrat)�63   5+      �� 5,      "  6   .�5-      �� 	 � ��$
 0q�68   �� 5.      	 � ��$

 10,5q�60   �� 5/      	 � ��
 50      �� 51      "  6.   .R�52   "   �� #��z��6)   $��0q�53   )   ._�54   &   �� $��Center=�67   55   #   56      58      59      5:         Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ Report Type��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5?   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5>   #   �� *
ReportType+5?   #     5@      $ Generated At��6%   $
 Auto 5B   #    5A   #   �� *GeneratedAt+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}��5B   #     5C      $ Content��6%   $ * 5E   #    5D   #   �� *	Content+5E   #   5G      5H      5I      