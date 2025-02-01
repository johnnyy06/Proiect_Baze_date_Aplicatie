using CargoFlow.Models;
using System.Collections.ObjectModel;

namespace CargoFlow.ViewModels
{
    internal class VM_MyReports : VM_Base
    {
        private ObservableCollection<Report> _reports;
        private readonly string _username;

        public VM_MyReports(string username)
        {
            _username = username;
            LoadReports();
        }

        public ObservableCollection<Report> Reports
        {
            get => _reports;
            set
            {
                _reports = value;
                OnPropertyChange(nameof(Reports));
            }
        }

        private void LoadReports()
        {
            Reports = DatabaseManager.GetDriverReports(_username);
        }
    }
}