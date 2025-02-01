using CargoFlow.ViewModels;
using System;
using System.Windows;

namespace CargoFlow.Views
{
    public partial class AddNewVehicleWindow : Window
    {
        public AddNewVehicleWindow(Action refreshCallback = null)
        {
            InitializeComponent();

            var viewModel = new VM_AddNewVehicle
            {
                CloseWindowAction = () => this.Close(),
                VehicleAddedCallback = refreshCallback
            };

            DataContext = viewModel;
        }
    }
}