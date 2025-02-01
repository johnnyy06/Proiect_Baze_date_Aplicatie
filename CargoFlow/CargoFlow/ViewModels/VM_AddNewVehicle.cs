using System;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CargoFlow.ViewModels
{
    internal class VM_AddNewVehicle : VM_Base
    {
        private string _licensePlate;
        private string _vehicleType;
        private string _fuelType = "Diesel"; // Default value
        private decimal _fuelConsumptionRate;
        private string _status = "Available"; // Default value

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public Action CloseWindowAction { get; set; }
        public Action VehicleAddedCallback { get; set; }

        public VM_AddNewVehicle()
        {
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        public string LicensePlate
        {
            get => _licensePlate;
            set
            {
                _licensePlate = value;
                OnPropertyChange(nameof(LicensePlate));
            }
        }

        public string VehicleType
        {
            get => _vehicleType;
            set
            {
                _vehicleType = value;
                OnPropertyChange(nameof(VehicleType));
            }
        }

        public string FuelType
        {
            get => _fuelType;
            set
            {
                _fuelType = value;
                OnPropertyChange(nameof(FuelType));
            }
        }

        public decimal FuelConsumptionRate
        {
            get => _fuelConsumptionRate;
            set
            {
                _fuelConsumptionRate = value;
                OnPropertyChange(nameof(FuelConsumptionRate));
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChange(nameof(Status));
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(LicensePlate))
            {
                MessageBox.Show("License plate is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(VehicleType))
            {
                MessageBox.Show("Vehicle type is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(FuelType))
            {
                MessageBox.Show("Fuel type is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (FuelConsumptionRate < 0)
            {
                MessageBox.Show("Fuel consumption rate cannot be negative.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Save()
        {
            if (!ValidateInput())
                return;

            try
            {
                DatabaseManager.AddVehicle(
                    LicensePlate.Trim(),
                    VehicleType.Trim(),
                    FuelType,
                    FuelConsumptionRate,
                    Status
                );

                MessageBox.Show("Vehicle added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                
                // Call the callback to refresh the vehicles list
                VehicleAddedCallback?.Invoke();
                
                // Close the window
                CloseWindowAction?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel()
        {
            CloseWindowAction?.Invoke();
        }
    }
}