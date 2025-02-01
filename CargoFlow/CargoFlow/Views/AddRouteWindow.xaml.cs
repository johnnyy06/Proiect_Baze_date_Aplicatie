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
    /// Interaction logic for AddRouteWindow.xaml
    /// </summary>
    public partial class AddRouteWindow : Window
    {
        public AddRouteWindow()
        {
            InitializeComponent();
            var viewModel = new VM_AddRoute();

            viewModel.CloseWindowAction = () => this.Close();

            DataContext = viewModel;
        }
    }
}
