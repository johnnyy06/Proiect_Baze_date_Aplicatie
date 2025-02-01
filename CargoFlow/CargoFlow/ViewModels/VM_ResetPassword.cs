using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows;
using System.Windows.Input;

namespace CargoFlow.ViewModels
{
    internal class VM_ResetPassword : VM_Base
    {
        private string _username;
        private string _email;
        private string _newPassword;
        private string _confirmPassword;

        public ICommand ResetPasswordCommand { get; }
        public ICommand CloseCommand { get; }
        public Action CloseWindowAction { get; set; }

        public VM_ResetPassword()
        {
            ResetPasswordCommand = new RelayCommand(ResetPassword);
            CloseCommand = new RelayCommand(Close);
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChange(nameof(Username));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChange(nameof(Email));
            }
        }

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChange(nameof(NewPassword));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChange(nameof(ConfirmPassword));
            }
        }

        private void ResetPassword()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(NewPassword) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NewPassword != ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (DatabaseManager.ResetPassword(Username, Email, NewPassword))
                {
                    MessageBox.Show("Password reset successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseWindowAction?.Invoke();
                }
                else
                {
                    MessageBox.Show("Invalid username or email.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting password: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close()
        {
            CloseWindowAction?.Invoke();
        }
    }
}