   M S B A M L   `   `   `  ����D  @CargoFlow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CargoFlow.ViewsCargoFlow.Views  5      '    !CargoFlow.Views.RoutePlanningPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CargoFlow.Views     5        N� Title$  Route Planning��5      .��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Route Planning��5      $��24(�5      $
��Bold"�5      $��
Montserrat)�5      ���#D3D3D3$��0,0,0,20q�5      �� 5   
   $��1��6   $��Add New Route��5         ModernButton#��[  5      $
��Left=�5      $��0,0,0,10q�5       ��5      �� *AddRouteCommand+5       &   System.Windows.Controls.DataGrid  5#   
   $��2��6      AutoGenerateColumns .     
IsReadOnly . 
������    RowBackground �#3D3D3D   AlternatingRowBackground �#4D4D4D���#666666
�������   GridLinesVisibility$	 All=�5,      "   VerticalScrollBarVisibility$
 Auto=�5-      $   HorizontalScrollBarVisibility$
 Auto=�5.      	   CanUserResizeRows	 .  
   CanUserReorderColumns
 .     HeadersVisibility$ Column=�51      ��5$      �� *ActiveRoutes+ � 	Resources 52      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType��%A  '        '      �� 53      "  6   .�54      ��  � �� �#2B2B2B63   �� 55       � ��
 �����63   �� 56       � ��$
 10,5q�60   �� 57       � �� �#66666664   �� 58       � ��$ 0,0,1,1q�68   �� 59       � ��$ 
Montserrat)�63   5:      �� 5;      "  6   .�5<      ��  � ��$ 0q�68   �� 5=       � ��$
 10,5q�60   �� 5>       � �� 5?      �� 5@      "  6.   .R�5A   "   �� #��z��6)   $��0q�5B   )   ._�5C   &   �� $��Center=�67   5D   #   5E      5G      5H      5I         Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Route Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5N   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   #   �� *Route.RouteName+5N   #     5O      $ Driver��6%   $
 Auto 5Q   #    5P   #   �� *Driver.Name+5Q   #     5R      $ Vehicle��6%   $
 Auto 5T   #    5S   #   �� *Vehicle.LicensePlate+5T   #     5U      $ Start Location��6%   $
 Auto 5W   #    5V   #   �� *Route.StartLocation+5W   #     5X      $ End Location��6%   $
 Auto 5Z   #    5Y   #   �� *Route.EndLocation+5Z   #     5[      $ 
Start Time��6%   $
 Auto 5]   #    5\   #   �� *EstimatedStartTime+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}��5]   #     5^      $ End Time��6%   $
 Auto 5`   #    5_   #   �� *EstimatedEndTime+$ {0:dd/MM/yyyy HH:mm}��5`   #   5b      5c      5d      