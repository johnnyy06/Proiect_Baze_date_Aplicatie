   M S B A M L   `   `   `  ����  	CargoFlow(    "CargoFlow.Views.GenerateReportPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Generate Report��5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��Generate Report��6   $��24(�5      $
��Bold"�5      $��
Montserrat)�5      ���#D3D3D3$��0,0,0,20q�5      �� 5   
   $��1��6   .��5      �� $��0,0,0,20q�6   .+�5      �� $��Select Route:��6   ���#D3D3D3$��
Montserrat)�5      $��0,0,0,5q�5      �� 5      $��0,0,0,15q�5      ���#3D3D3D
���   �$��
Montserrat)�5"      ��5      �� *AvailableRoutes+ �� SelectedItem 5      �� *SelectedRoute+��5#      �� 5$      .R�5%      �� �� 5&   "   �6&   �� *Route.RouteName+ �� 5'   "   $� (��6&    �� 5(   "   �6&   �� *EstimatedStartTime+ �� StringFormat$ {0:dd/MM/yyyy}�� �� 5)   "   $�)��6&   5*      5+      5-      �� 50      $��Report Type:��6   ���#D3D3D3$��
Montserrat)�52      $��0,0,0,5q�53      �� 54       �� SelectedValuePath$ Content��55      ���#3D3D3D
���   �$��
Montserrat)�58      $��0,0,0,15q�59       �� SelectedValue 54      �� *
ReportType+.@�5:      �� $
��Fuel��6#   �� 5;      $��Route��6#   �� 5<      $��Maintenance��6#   �� 5=      $��Performance��6#   5>      �� 5A      $��Additional Notes:��6   ���#D3D3D3$��
Montserrat)�5C      $��0,0,0,5q�5D      �� 5E      $	��100��5F       �� TextWrapping$
 Wrap=�5G       �� AcceptsReturn . $��0,0,0,15q�5I      ���#3D3D3D
�������$��
Montserrat)�5L      $��5q�5M      ��5E      �� *	Content+5M      5N      5O      �� 5R   
   $��2��6    �� Orientation$ 
Horizontal=�5S      $��Right=�5T      .+�5U      �� $��Generate Report��6      ModernButton#��[  5W      $��0,0,10,0q�5X      ��5V      �� *GenerateReportCommand+5X      �� 5Y      $��
Export PDF��6   #��[  5[      ��5Z      �� *ExportPdfCommand+5[      5\      5]      5^      