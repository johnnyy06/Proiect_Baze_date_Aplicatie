using CargoFlow.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace CargoFlow.ViewModels
{
    internal class VM_GenerateReport : VM_Base
    {
        private ObservableCollection<RouteAssignment> _availableRoutes;
        private RouteAssignment _selectedRoute;
        private string _reportType;
        private string _content;
        private readonly string _username;

        public ICommand GenerateReportCommand { get; }
        public ICommand ExportPdfCommand { get; }

        public VM_GenerateReport(string username)
        {
            _username = username;
            GenerateReportCommand = new RelayCommand(GenerateReport);
            ExportPdfCommand = new RelayCommand(ExportToPdf);
            LoadAvailableRoutes();
        }

        public ObservableCollection<RouteAssignment> AvailableRoutes
        {
            get => _availableRoutes;
            set
            {
                _availableRoutes = value;
                OnPropertyChange(nameof(AvailableRoutes));
            }
        }

        public RouteAssignment SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;
                OnPropertyChange(nameof(SelectedRoute));
            }
        }

        public string ReportType
        {
            get => _reportType;
            set
            {
                _reportType = value;
                OnPropertyChange(nameof(ReportType));
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChange(nameof(Content));
            }
        }

        private void LoadAvailableRoutes()
        {
            AvailableRoutes = DatabaseManager.GetDriverRoutes(_username);
        }

        private void GenerateReport()
        {
            if (SelectedRoute == null)
            {
                MessageBox.Show("Please select a route.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(ReportType))
            {
                MessageBox.Show("Please select a report type.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                DatabaseManager.AddReport(ReportType, _username, Content ?? string.Empty);
                MessageBox.Show("Report generated successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportToPdf()
        {
            if (string.IsNullOrEmpty(Content))
            {
                MessageBox.Show("Please generate a report first.", "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show("PDF export feature coming soon!", "Information",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}