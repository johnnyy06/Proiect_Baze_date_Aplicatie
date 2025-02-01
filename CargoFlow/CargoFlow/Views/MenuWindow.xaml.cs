using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CargoFlow.Views
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private string _username;

        public MenuWindow(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void MyVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new MyVehiclePage(_username);
            ContentFrame.Navigate(page);
        }

        private void MyRouteButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new MyRoutePage(_username);
            ContentFrame.Navigate(page);
        }

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new GenerateReportPage(_username);
            ContentFrame.Navigate(page);
        }

        private void MyReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new MyReportsPage(_username));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
