using CargoFlow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CargoFlow.Views
{
    /// <summary>
    /// Interaction logic for ManageVehiclesPage.xaml
    /// </summary>
    public partial class ManageVehiclesPage : Page
    {
        public ManageVehiclesPage()
        {
            InitializeComponent();
            var viewModel = new VM_ManageVehiclesPage();

            // update la status-ul vehiculelor pentru rutele completate
            DatabaseManager.UpdateVehicleStatusForCompletedRoutes();

            // Set up the action to open the AddNewVehicle window
            viewModel.AddVehicleAction = () =>
            {
                var addWindow = new AddNewVehicleWindow();
                addWindow.Closed += (s, e) => viewModel.LoadVehicles();
                addWindow.Show();
            };


            DataContext = viewModel;
        }
    }
}
