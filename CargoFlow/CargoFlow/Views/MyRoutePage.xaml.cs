using CargoFlow.ViewModels;
using System.Windows.Controls;

namespace CargoFlow.Views
{
    public partial class MyRoutePage : Page
    {
        public MyRoutePage(string username)
        {
            InitializeComponent();
            var viewModel = new VM_MyRoute(username);
            DataContext = viewModel;
        }
    }
}