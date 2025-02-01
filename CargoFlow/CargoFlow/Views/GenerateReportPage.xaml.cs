using CargoFlow.ViewModels;
using System.Windows.Controls;

namespace CargoFlow.Views
{
    public partial class GenerateReportPage : Page
    {
        public GenerateReportPage(string username)
        {
            InitializeComponent();
            var viewModel = new VM_GenerateReport(username);
            DataContext = viewModel;
        }
    }
}