using CargoFlow.ViewModels;
using System.Windows.Controls;

namespace CargoFlow.Views
{
    public partial class MyVehiclePage : Page
    {
        public MyVehiclePage(string username)
        {
            InitializeComponent();
            var viewModel = new VM_MyVehicle(username);
            DataContext = viewModel;
        }
    }
}