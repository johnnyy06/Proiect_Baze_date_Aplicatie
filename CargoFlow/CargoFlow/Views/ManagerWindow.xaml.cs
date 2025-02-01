using System;
using System.Windows;
using System.Windows.Controls;

namespace CargoFlow.Views
{
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void RoutePlanningButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new RoutePlanningPage());
        }

        private void ManageVehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new ManageVehiclesPage());
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new ReportsPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}