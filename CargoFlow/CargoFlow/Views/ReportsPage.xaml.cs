using CargoFlow.ViewModels;
using System.Windows.Controls;

namespace CargoFlow.Views
{
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
            DataContext = new VM_Reports();
        }
    }
}