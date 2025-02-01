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
using System.Collections.ObjectModel;

namespace CargoFlow.ViewModels
{
    internal class VM_ManageVehiclesPage : VM_Base
    {
        private ObservableCollection<Vehicle> _vehicles;
        private ObservableCollection<Vehicle> _allVehicles;
        private string _searchText;
        public ICommand AddVehicleCommand { get; }
        public ICommand DeleteVehicleCommand { get; }

        public Action AddVehicleAction { get; set; }

        public VM_ManageVehiclesPage()
        {
            DeleteVehicleCommand = new RelayCommand<Vehicle>(DeleteVehicle);
            AddVehicleCommand = new RelayCommand(AddVehicle);
            LoadVehicles();
        }

        private void DeleteVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return;

            var result = System.Windows.MessageBox.Show(
                $"Are you sure you want to delete vehicle {vehicle.LicensePlate}?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DatabaseManager.DeleteVehicle(vehicle.VehicleID);
                    LoadVehicles(); // Refresh the list
                    System.Windows.MessageBox.Show("Vehicle deleted successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Error deleting vehicle: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChange(nameof(SearchText));
                FilterVehicles();
            }
        }

        public ObservableCollection<Vehicle> Vehicles
        {
            get => _vehicles;
            set
            {
                _vehicles = value;
                OnPropertyChange(nameof(Vehicles));
            }
        }

        public void LoadVehicles()
        {
            _allVehicles = DatabaseManager.GetAllVehicles();
            Vehicles = DatabaseManager.GetAllVehicles();
        }

        private void FilterVehicles()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Vehicles = new ObservableCollection<Vehicle>(_allVehicles);
                return;
            }

            var filtered = _allVehicles.Where(v =>
            (v.LicensePlate != null && v.LicensePlate.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
            (v.VehicleType != null && v.VehicleType.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
            (v.FuelType != null && v.FuelType.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
            (v.Status != null && v.Status.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0)
        );

            Vehicles = new ObservableCollection<Vehicle>(filtered);
        }

        private void AddVehicle()
        {
            AddVehicleAction?.Invoke();
        }
    }
}
