using System.Collections.ObjectModel;
using CargoFlow.Models;

namespace CargoFlow.ViewModels
{
    internal class VM_MyRoute : VM_Base
    {
        private ObservableCollection<RouteAssignment> _myRoutes;

        public ObservableCollection<RouteAssignment> MyRoutes
        {
            get => _myRoutes;
            set
            {
                _myRoutes = value;
                OnPropertyChange(nameof(MyRoutes));
            }
        }

        public VM_MyRoute(string username)
        {
            LoadRoutes(username);
        }

        private void LoadRoutes(string username)
        {
            MyRoutes = DatabaseManager.GetDriverRoutes(username);
        }
    }
}