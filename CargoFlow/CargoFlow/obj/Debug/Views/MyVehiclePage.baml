   M S B A M L   `   `   `  ����D  @CargoFlow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CargoFlow.ViewsCargoFlow.Views  5      #    CargoFlow.Views.MyVehiclePage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CargoFlow.Views     5        N� Title$  
My Vehicle��5      .��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��My Vehicle Details��6   $��24(�5      $
��Bold"�5      
�������$��0,0,0,20q�5      �� 5   
   $��1��6   ���#3D3D3D �� CornerRadius$ 10��5       �� Padding$ 20q�5      ._�5      �� .+�5      � $
��0,10q�6    � ColumnDefinitions 5      �� 5      $	��150 �6+   �� 5       $��* �6+    5"      �� 5#      $
��Auto �6(   �� 5$      $
��Auto �6(   �� 5%      $
��Auto �6(   �� 5&      $
��Auto �6(   �� 5'      $
��Auto �6(   .+�5*      �� $��License Plate:��6    ���#CCCCCC$��0��5,      $��0��6+   �� 5-      
�������$��0��5/      $��1��6+   ��5-       �� *Vehicle.LicensePlate+5/   +   �� 51      $��Vehicle Type:��6    ���#CCCCCC$��1��53      $��0��6+   $��0,10,0,0q�6;   �� 54      
�������$��1��56      $��1��6+   $��0,10,0,0q�6;   ��54       �� *Vehicle.VehicleType+56   ;   �� 58      $��
Fuel Type:��6    ���#CCCCCC$��2��5:      $��0��6+   $��0,10,0,0q�6;   �� 5;      
�������$��2��5=      $��1��6+   $��0,10,0,0q�6;   ��5;       �� *Vehicle.FuelType+5=   ;   �� 5?      $��Fuel Consumption:��6    ���#CCCCCC$��3��5A      $��0��6+   $��0,10,0,0q�6;   �� 5B      
�������$��3��5D      $��1��6+   $��0,10,0,0q�6;   ��5B       �� *Vehicle.FuelConsumptionRate+ �� StringFormat$ {0} L/100km��5D   ;   �� 5F      $��Status:��6    ���#CCCCCC$��4��5H      $��0��6+   $��0,10,0,0q�6;   �� 5I      
�������$��4��5K      $��1��6+   $��0,10,0,0q�6;   ��5I       �� *Vehicle.Status+5K   ;   5L      5M      5N      5O      5P      