using CargoFlow.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace CargoFlow.ViewModels
{
    internal class VM_Reports : VM_Base
    {
        private ObservableCollection<Report> _reports;
        private ObservableCollection<Report> _allReports;
        private string _searchText;

        public VM_Reports()
        {
            LoadReports();
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChange(nameof(SearchText));
                FilterReports();
            }
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

        public void LoadReports()
        {
            _allReports = DatabaseManager.GetAllReports();
            Reports = _allReports;
        }

        private void FilterReports()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Reports = new ObservableCollection<Report>(_allReports);
                return;
            }

            var filtered = _allReports.Where(r =>
                (r.ReportType != null && r.ReportType.IndexOf(SearchText, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                (r.User.FullName != null && r.User.FullName.IndexOf(SearchText, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                (r.Content != null && r.Content.IndexOf(SearchText, System.StringComparison.OrdinalIgnoreCase) >= 0)
            );

            Reports = new ObservableCollection<Report>(filtered);
        }
    }
}