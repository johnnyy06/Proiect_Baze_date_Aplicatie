   M S B A M L   `   `   `  ����D  @CargoFlow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CargoFlow.ViewsCargoFlow.Views  5      (    "CargoFlow.Views.ManageVehiclesPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CargoFlow.Views     5        N� Title$  ManageVehiclesPage��5      .��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Vehicle Management��6   $��24(�5      $
��Bold"�5      $��
Montserrat)�5      ���#D3D3D3$��0,0,0,20q�5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�5      $��0,0,0,10q�5      .+�5      �� $��Add New Vehicle��6      ModernButton#��[  5      $	��150��5       $��32��5!      $��0,0,10,0q�5"      ��5      �� *AddVehicleCommand+5"      �� 5%      $	��200��6   $��5q�5&      $��13(�5(      $��Medium"�5)      $��
Montserrat)�5*      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5.      $��28��5/      $��Center=�50      ��5'      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��50   8   ��51      !� 52       j� TileMode$
 None=�6"    �� Opacity$	 0.5Q�53   !    j� Stretch$
 None=�54   !    j� 
AlignmentX$
 Left=�55   !   	 !� Visual	 56      �� 57      $��Search vehicles...��6(   
�������$��5,0,0,0q�59   &   5;      .��5<   &   5=      5>      &   System.Windows.Controls.DataGrid  5A   
   $��2��6   
   AutoGenerateColumns
 .     
IsReadOnly . 
������    RowBackground �#3D3D3D   AlternatingRowBackground �#4D4D4D���#666666
�������   GridLinesVisibility$	 All=�5J      "   VerticalScrollBarVisibility$
 Auto=�5K      $   HorizontalScrollBarVisibility$
 Auto=�5L         CanUserResizeRows .     CanUserReorderColumns .     HeadersVisibility$ Column=�5O      ��5B      �� *
Vehicles+ � 	Resources 5P      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType��%A  '        '      �� 5Q      "  6   .�5R      ��  � �� �#2B2B2B63   �� 5S       � ��
 �����63   �� 5T       � ��$
 10,5q�60   �� 5U       � �� �#66666664   �� 5V       � ��$ 0,0,1,1q�68   �� 5W       � ��$ 
Montserrat)�63   5X      �� 5Y      "  6   .�5Z      ��  � ��$ 0q�68   �� 5[       � ��$
 10,5q�60   �� 5\       � �� 5]      �� 5^      "  6.   .R�5_   "   �� #��z��6)   $��0q�5`   )   ._�5a   &   �� $��Center=�67   5b   #   5c      5e      5f      5g         Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn   Header$ License Plate��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5l   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5k   #   �� *LicensePlate+5l   #     5m      $ Vehicle Type��6%   $
 Auto 5o   #    5n   #   �� *VehicleType+5o   #     5p      $ 	Fuel Type��6%   $
 Auto 5r   #    5q   #   �� *
FuelType+5r   #     5s      $ Fuel Consumption��6%   $
 Auto 5u   #    5t   #   �� *FuelConsumptionRate+5u   #     5v      $ Status��6%   $
 Auto 5x   #    5w   #   �� *Status+5x   #   4  .System.Windows.Controls.DataGridTemplateColumn  5y      $ Actions��6)   $
 Auto 6:      CellTemplate 5z      �� 5{      .R�5|      �� $��Delete��6%   $��80��5�   %   $��25��5�   %   $��5q�5�   %   ��5}   %   �� *" DataContext.DeleteVehicleCommand+ �� RelativeSource ��  �� AncestorType$ DataGridL���5   %   �� ��5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� �#FF44446G   �� 5�   *    � ��
 �����6G   �� 5�   *    � ��$ 0q�6L   �� 5�   *    � �� 5�   .   �� 5�   2   " ��6B   .R�5�   6   �� #��z��6=   $��0q�5�   =     �� CornerRadius$  3��5�   =   ._�5�   :   �� $��Center=�6K   $��Center=�5�   I   5�   7   5�   3   5�   +   ! �� Triggers! 5�   *   P� 5�   .   " P� Property" �@J�IsMouseOver# P� Value# . . �5�   2   ��  � �� �#FF00006O   5�   /   5�   '   5�      5�      5�      5�      5�      5�      