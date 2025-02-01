using CargoFlow.ViewModels;
using System.Windows.Controls;

namespace CargoFlow.Views
{
    public partial class MyReportsPage : Page
    {
        public MyReportsPage(string username)
        {
            InitializeComponent();
            DataContext = new VM_MyReports(username);
        }
    }
}