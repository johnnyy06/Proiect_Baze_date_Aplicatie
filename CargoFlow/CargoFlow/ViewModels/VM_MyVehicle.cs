using System.Collections.ObjectModel;
using CargoFlow.Models;

namespace CargoFlow.ViewModels
{
    internal class VM_MyVehicle : VM_Base
    {
        private Vehicle _vehicle;

        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                _vehicle = value;
                OnPropertyChange(nameof(Vehicle));
            }
        }

        public VM_MyVehicle(string username)
        {
            LoadVehicle(username);
        }

        private void LoadVehicle(string username)
        {
            Vehicle = DatabaseManager.GetDriverVehicle(username);
        }
    }
}