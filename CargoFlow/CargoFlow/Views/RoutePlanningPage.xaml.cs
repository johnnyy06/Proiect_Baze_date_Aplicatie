using CargoFlow.ViewModels;
using System.Windows.Controls;

namespace CargoFlow.Views
{
    public partial class RoutePlanningPage : Page
    {
        public RoutePlanningPage()
        {
            InitializeComponent();
            var viewModel = new VM_RoutePlanning();

            // face update la status-ul vehiculului (asta in caz ca o ruta a trecut de timpul de final)
            DatabaseManager.UpdateVehicleStatusForCompletedRoutes();

            viewModel.AddRouteAction = () =>
            {
                var addWindow = new AddRouteWindow();
                addWindow.Closed += (s, e) =>
                {
                    DatabaseManager.UpdateVehicleStatusForCompletedRoutes();
                    viewModel.LoadActiveRoutes();
                };
                addWindow.Show();
            };

            DataContext = viewModel;
        }
    }
}