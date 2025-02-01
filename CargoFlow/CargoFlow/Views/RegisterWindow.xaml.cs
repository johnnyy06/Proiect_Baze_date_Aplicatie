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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            var viewModel = new VM_Register();
            DataContext = viewModel;

            // Setam actiunea pentru inchiderea ferestrei
            viewModel.CloseWindowAction = () => this.Close();

            viewModel.SetWindowStateAction = (state) => this.WindowState = state;

            // Setează acțiunea de login
            viewModel.RegisterAction = () =>
            {
                // Deschide fereastra principala
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close(); //Close login window
            };
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                if (DataContext is VM_Register viewModel)
                {
                    viewModel.Password = passwordBox.Password;  // Actualizeaza valoarea din ViewModel
                }
            }
        }
    }
}
