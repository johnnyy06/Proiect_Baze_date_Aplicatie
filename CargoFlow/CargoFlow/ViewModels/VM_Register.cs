using CargoFlow.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CargoFlow.ViewModels
{
    internal class VM_Register : VM_Base
    {
        private string _username;
        private string _password;
        private string _role;
        private string _fullName;
        private string _email;
        private string _phone;


        public ICommand RegisterCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }


        public Action RegisterAction { get; set; }
        public Action CloseWindowAction { get; set; }

        public VM_Register()
        {
            RegisterCommand = new RelayCommand(Register);
            CloseCommand = new RelayCommand(Close);
            MinimizeCommand = new RelayCommand(Minimize);
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

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChange(nameof(Password));
            }
        }

        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChange(nameof(Role));
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChange(nameof(FullName));
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

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChange(nameof(Phone));
            }
        }


        private void Register()
        {
            DatabaseManager.AddUser(Username, Password, Role, FullName, Email, Phone);
            RegisterAction?.Invoke();
        }

        private void Close()
        {
            //inchide fereastra
            CloseWindowAction?.Invoke();
        }

        private void Minimize()
        {
            // pune fereastra in bara
            SetWindowStateAction?.Invoke(WindowState.Minimized);
        }
    }
}
