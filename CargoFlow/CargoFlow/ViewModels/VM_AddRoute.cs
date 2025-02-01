using CargoFlow.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace CargoFlow.ViewModels
{
    internal class VM_AddRoute : VM_Base
    {
        private string _routeName;
        private Driver _selectedDriver;
        private Vehicle _selectedVehicle;
        private string _startLocation;
        private string _endLocation;
        private DateTime? _startDate;
        private string _startTime;
        private DateTime? _endDate;
        private string _endTime;
        private ObservableCollection<Driver> _availableDrivers;
        private ObservableCollection<Vehicle> _availableVehicles;

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public Action CloseWindowAction { get; set; }

        public VM_AddRoute()
        {
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
            LoadAvailableDrivers();
            LoadAvailableVehicles();
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }

        public string RouteName
        {
            get => _routeName;
            set
            {
                _routeName = value;
                OnPropertyChange(nameof(RouteName));
            }
        }

        public Driver SelectedDriver
        {
            get => _selectedDriver;
            set
            {
                _selectedDriver = value;
                OnPropertyChange(nameof(SelectedDriver));
            }
        }

        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set
            {
                _selectedVehicle = value;
                OnPropertyChange(nameof(SelectedVehicle));
            }
        }

        public string StartLocation
        {
            get => _startLocation;
            set
            {
                _startLocation = value;
                OnPropertyChange(nameof(StartLocation));
            }
        }

        public string EndLocation
        {
            get => _endLocation;
            set
            {
                _endLocation = value;
                OnPropertyChange(nameof(EndLocation));
            }
        }

        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChange(nameof(StartDate));
            }
        }

        public string StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChange(nameof(StartTime));
            }
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChange(nameof(EndDate));
            }
        }

        public string EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                OnPropertyChange(nameof(EndTime));
            }
        }

        public ObservableCollection<Driver> AvailableDrivers
        {
            get => _availableDrivers;
            set
            {
                _availableDrivers = value;
                OnPropertyChange(nameof(AvailableDrivers));
            }
        }

        public ObservableCollection<Vehicle> AvailableVehicles
        {
            get => _availableVehicles;
            set
            {
                _availableVehicles = value;
                OnPropertyChange(nameof(AvailableVehicles));
            }
        }

        private void LoadAvailableDrivers()
        {
            AvailableDrivers = DatabaseManager.GetAvailableDrivers();
        }

        private void LoadAvailableVehicles()
        {
            AvailableVehicles = DatabaseManager.GetAvailableVehicles();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(RouteName))
            {
                MessageBox.Show("Please enter a route name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (SelectedDriver == null)
            {
                MessageBox.Show("Please select a driver.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (SelectedVehicle == null)
            {
                MessageBox.Show("Please select a vehicle.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(StartLocation))
            {
                MessageBox.Show("Please enter a start location.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(EndLocation))
            {
                MessageBox.Show("Please enter an end location.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!StartDate.HasValue || string.IsNullOrWhiteSpace(StartTime))
            {
                MessageBox.Show("Please enter a start date and time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!EndDate.HasValue || string.IsNullOrWhiteSpace(EndTime))
            {
                MessageBox.Show("Please enter an end date and time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Save()
        {
            if (!ValidateInput()) return;

            try
            {
                // Parse the date and time
                if (!DateTime.TryParse($"{StartDate:yyyy-MM-dd} {StartTime}", out DateTime startDateTime))
                {
                    MessageBox.Show("Invalid start time format. Please use HH:mm format.",
                                  "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!DateTime.TryParse($"{EndDate:yyyy-MM-dd} {EndTime}", out DateTime endDateTime))
                {
                    MessageBox.Show("Invalid end time format. Please use HH:mm format.",
                                  "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate that end time is after start time
                if (endDateTime <= startDateTime)
                {
                    MessageBox.Show("End time must be after start time.",
                                  "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DatabaseManager.AddRoute(
                    RouteName,
                    StartLocation,
                    EndLocation,
                    SelectedDriver.DriverID,
                    SelectedVehicle.VehicleID,
                    startDateTime,
                    endDateTime
                );

                MessageBox.Show("Route added successfully!", "Success",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                CloseWindowAction?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding route: {ex.Message}",
                              "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel()
        {
            CloseWindowAction?.Invoke();
        }
    }
}
