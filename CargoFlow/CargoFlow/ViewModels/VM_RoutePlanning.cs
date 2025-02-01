using CargoFlow.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System;

namespace CargoFlow.ViewModels
{
    internal class VM_RoutePlanning : VM_Base
    {
        private ObservableCollection<RouteAssignment> _activeRoutes;

        public ICommand AddRouteCommand { get; }
        public Action AddRouteAction { get; set; }

        public VM_RoutePlanning()
        {
            AddRouteCommand = new RelayCommand(AddRoute);
            LoadActiveRoutes();
        }

        public ObservableCollection<RouteAssignment> ActiveRoutes
        {
            get => _activeRoutes;
            set
            {
                _activeRoutes = value;
                OnPropertyChange(nameof(ActiveRoutes));
            }
        }

        public void LoadActiveRoutes()
        {
            ActiveRoutes = DatabaseManager.GetActiveRoutes();
        }

        private void AddRoute()
        {
            AddRouteAction?.Invoke();
        }
    }
}