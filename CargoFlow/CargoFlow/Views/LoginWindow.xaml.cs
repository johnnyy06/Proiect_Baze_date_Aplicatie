using CargoFlow.ViewModels;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            var viewModel = new VM_Login();
            DataContext = viewModel;

            // Setam actiunea pentru inchiderea ferestrei
            viewModel.CloseWindowAction = () => this.Close();

            viewModel.SetWindowStateAction = (state) => this.WindowState = state;

            viewModel.CreateOneAction = () =>
            {
                // Open register page
                var registerWindow = new RegisterWindow();
                registerWindow.Show();
                this.Close(); 
            };
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                if (DataContext is VM_Login viewModel)
                {
                    viewModel.Password = passwordBox.Password;
                }
            }
        }

        private void ResetPassword_Click(object sender, MouseButtonEventArgs e)
        {
            var resetWindow = new ResetPasswordWindow();
            resetWindow.ShowDialog();
        }
    }
}
