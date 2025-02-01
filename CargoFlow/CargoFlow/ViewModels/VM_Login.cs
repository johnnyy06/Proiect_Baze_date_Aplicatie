using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using CargoFlow.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CargoFlow.ViewModels
{
    internal class VM_Login : VM_Base
    {
        private string _username;
        private string _password;

        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand CreateOneCommand { get; set; }

        public Action CloseWindowAction { get; set; }
        public Action LoginAction { get; set; }
        public Action CreateOneAction { get; set; }

        public VM_Login()
        {
            LoginCommand = new RelayCommand(Login);
            CloseCommand = new RelayCommand(Close);
            MinimizeCommand = new RelayCommand(Minimize);
            CreateOneCommand = new RelayCommand(CreateOne);
        }

        private void Login()
        {
            if (DatabaseManager.ValidateUser(Username, Password) is true)
            {
                if(DatabaseManager.GetUserRole(Username) == "Driver")
                {
                    //deschide fereastra principala
                    var menuWindow = new MenuWindow(Username);
                    menuWindow.Show();
                }
                else
                {
                    //deschide fereastra principala
                    var managerWindow = new ManagerWindow();
                    managerWindow.Show();
                }

                Close(); //inchide fereastra de login
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Username or password incorrect", "Error",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Close()
        {
            //inchide fereastra de login
            CloseWindowAction?.Invoke();
        }

        private void Minimize()
        {
            // pune fereastra in bara
            SetWindowStateAction?.Invoke(WindowState.Minimized);
        }

        private void CreateOne()
        {
            //Open register page
            CreateOneAction?.Invoke();
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
    }
}
