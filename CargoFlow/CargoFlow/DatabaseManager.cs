using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CargoFlow.Helpers;
using CargoFlow.Models;
using System.Transactions;

namespace CargoFlow
{
    internal class DatabaseManager
    {
        private static TransportManagementDataContext _dbContext;

        public DatabaseManager()
        {
            _dbContext = new TransportManagementDataContext();
        }

        // Registration Page
        public static void AddUser(string username, string password, string role, string full_name, string email, string phone)
        {
            if(_dbContext == null) _dbContext = new TransportManagementDataContext();
            string encryptedPassword = Helpers.Hash.EncryptPassword(password);
            User user = new User
            {
                Username = username,
                PasswordHash = encryptedPassword,
                Role = role,
                FullName = full_name,
                Email = email,
                PhoneNumber = phone
            };
            _dbContext.Users.InsertOnSubmit(user);
            _dbContext.SubmitChanges();
        }
        //--------------------------------------------------------------------------------



        // Login Page
        public static bool ValidateUser(string username, string password)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            User user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return false;
            }

            return Helpers.Hash.VerifyPassword(password, user.PasswordHash);
        }

        public static string GetUserRole(string username)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();
            User user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return null;
            }
            return user.Role;
        }
        //--------------------------------------------------------------------------------



        public static ObservableCollection<User> GetAllDrivers()
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();
            var drivers = _dbContext.Users.Where(u => u.Role == "Driver").ToList();
            return new ObservableCollection<User>(drivers);
        }


        // ManageVehicle Page
        public static void AddVehicle(string licensePlate, string vehicleType, string fuelType, decimal fuelConsumptionRate, string status)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            // verifica daca numarul de inmatriculare exista deja
            if (_dbContext.Vehicles.Any(v => v.LicensePlate == licensePlate))
            {
                throw new Exception("A vehicle with this license plate already exists.");
            }

            Vehicle vehicle = new Vehicle
            {
                LicensePlate = licensePlate,
                VehicleType = vehicleType,
                FuelType = fuelType,
                FuelConsumptionRate = fuelConsumptionRate,
                Status = status
            };

            try
            {
                _dbContext.Vehicles.InsertOnSubmit(vehicle);
                _dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving vehicle to database: " + ex.Message);
            }
        }
        //--------------------------------------------------------------------------------



        // RoutePlanning Page
        public static ObservableCollection<Vehicle> GetAllVehicles()
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();
            try
            {
                var vehicles = _dbContext.Vehicles.ToList();
                return new ObservableCollection<Vehicle>(vehicles);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<Vehicle>();
            }
        }

        public static ObservableCollection<RouteAssignment> GetActiveRoutes()
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var currentDate = DateTime.Now;
                // Instead of creating new objects, just load the existing ones
                var activeRoutes = _dbContext.RouteAssignments
                    .Where(ra => ra.EstimatedEndTime >= currentDate)  // Filter for active routes
                    .OrderBy(ra => ra.EstimatedStartTime)
                    .ToList();  // Execute the query first

                return new ObservableCollection<RouteAssignment>(activeRoutes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading active routes: {ex.Message}", "Error",
                               MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<RouteAssignment>();
            }
        }

        public static ObservableCollection<Driver> GetAvailableDrivers()
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var drivers = _dbContext.Users
                    .Where(u => u.Role == "Driver")
                    .Select(u => new Driver
                    {
                        DriverID = u.UserID,
                        Name = u.FullName
                    })
                    .ToList();

                return new ObservableCollection<Driver>(drivers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading drivers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<Driver>();
            }
        }

        public static ObservableCollection<Vehicle> GetAvailableVehicles()
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                // Simplified query to just filter available vehicles
                var availableVehicles = _dbContext.Vehicles
                    .Where(v => v.Status == "Available")
                    .ToList();

                return new ObservableCollection<Vehicle>(availableVehicles);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<Vehicle>();
            }
        }


        //adauga o noua ruta in baza de date
        public static void AddRoute(string routeName, string startLocation, string endLocation,
    int driverID, int vehicleID, DateTime startTime, DateTime endTime)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                // Check if vehicle is available
                var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID);
                if (vehicle == null)
                    throw new Exception("Vehicle not found.");

                if (vehicle.Status != "Available")
                    throw new Exception("Selected vehicle is not available.");

                // Create new route
                var route = new Route
                {
                    RouteName = routeName,
                    StartLocation = startLocation,
                    EndLocation = endLocation,
                    Distance = 0 // You might want to calculate this
                };

                _dbContext.Routes.InsertOnSubmit(route);
                _dbContext.SubmitChanges();

                // Create route assignment
                var assignment = new RouteAssignment
                {
                    RouteID = route.RouteID,
                    VehicleID = vehicleID,
                    DriverID = driverID,
                    AssignmentDate = DateTime.Now,
                    EstimatedStartTime = startTime,
                    EstimatedEndTime = endTime
                };

                _dbContext.RouteAssignments.InsertOnSubmit(assignment);

                // Set vehicle status to "In Use"
                vehicle.Status = "In Use";

                _dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding route: " + ex.Message);
            }
        }
        //--------------------------------------------------------------------------------



        // MyVehicle Page
        public static Vehicle GetDriverVehicle(string username)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user == null) return null;

                var currentAssignment = _dbContext.RouteAssignments
                    .Where(ra => ra.DriverID == user.UserID && ra.EstimatedEndTime >= DateTime.Now)
                    .OrderBy(ra => ra.EstimatedStartTime)
                    .FirstOrDefault();

                return currentAssignment?.Vehicle;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicle: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        //--------------------------------------------------------------------------------



        // MyRoute Page
        public static ObservableCollection<RouteAssignment> GetDriverRoutes(string username)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user == null) return new ObservableCollection<RouteAssignment>();

                var routes = _dbContext.RouteAssignments
                    .Where(ra => ra.DriverID == user.UserID && ra.EstimatedEndTime >= DateTime.Now)
                    .OrderBy(ra => ra.EstimatedStartTime)
                    .ToList();

                return new ObservableCollection<RouteAssignment>(routes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading routes: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<RouteAssignment>();
            }
        }
        //--------------------------------------------------------------------------------



        // MyReport Page
        public static void AddReport(string reportType, string username, string content)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                    throw new Exception("User not found");

                var report = new Report
                {
                    ReportType = reportType.ToString(),  // Convert to string explicitly
                    GeneratedBy = user.UserID,
                    GeneratedAt = DateTime.Now,
                    Content = content
                };

                _dbContext.Reports.InsertOnSubmit(report);
                _dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving report: " + ex.Message);
            }
        }
        //--------------------------------------------------------------------------------



        // Reports Page
        public static ObservableCollection<Report> GetAllReports()
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var reports = _dbContext.Reports
                    .OrderByDescending(r => r.GeneratedAt)
                    .ToList();
                return new ObservableCollection<Report>(reports);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<Report>();
            }
        }
        //--------------------------------------------------------------------------------



        // MyReports Page
        public static ObservableCollection<Report> GetDriverReports(string username)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user == null) return new ObservableCollection<Report>();

                var reports = _dbContext.Reports
                    .Where(r => r.GeneratedBy == user.UserID)
                    .OrderByDescending(r => r.GeneratedAt)
                    .ToList();

                return new ObservableCollection<Report>(reports);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<Report>();
            }
        }
        //--------------------------------------------------------------------------------



        public static bool ResetPassword(string username, string email, string newPassword)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var user = _dbContext.Users.FirstOrDefault(u =>
                    u.Username == username && u.Email == email);

                if (user == null)
                    return false;

                user.PasswordHash = Hash.EncryptPassword(newPassword);
                _dbContext.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static void DeleteVehicle(int vehicleId)
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.VehicleID == vehicleId);
                if (vehicle == null)
                {
                    throw new Exception("Vehicle not found.");
                }

                // Verifică dacă vehiculul este "In Use"
                if (vehicle.Status == "In Use")
                {
                    MessageBox.Show("Cannot delete vehicle: It is currently in use.",
                        "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Dacă nu este "In Use", verifică dacă are route assignments în trecut
                var hasRouteAssignments = _dbContext.RouteAssignments
                    .Any(ra => ra.VehicleID == vehicleId);

                if (!hasRouteAssignments)
                {
                    // Dacă nu are nicio atribuire, îl putem șterge
                    _dbContext.Vehicles.DeleteOnSubmit(vehicle);
                    _dbContext.SubmitChanges();
                    MessageBox.Show("Vehicle deleted successfully!",
                        "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cannot delete vehicle: It has historical route assignments.",
                        "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing vehicle: " + ex.Message);
            }
        }



        public static void UpdateVehicleStatusForCompletedRoutes()
        {
            if (_dbContext == null) _dbContext = new TransportManagementDataContext();

            try
            {
                var currentDateTime = DateTime.Now;

                // Get all current route assignments (where end time hasn't passed)
                var activeVehicles = _dbContext.RouteAssignments
                    .Where(ra => ra.EstimatedEndTime > currentDateTime)
                    .Select(ra => ra.VehicleID)
                    .Distinct()
                    .ToList();

                // Get vehicles that are marked as In Use but have no active routes
                var vehiclesToUpdate = _dbContext.Vehicles
                    .Where(v => v.Status == "In Use" && !activeVehicles.Contains(v.VehicleID))
                    .ToList();

                foreach (var vehicle in vehiclesToUpdate)
                {
                    vehicle.Status = "Available";
                }

                _dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating vehicle statuses: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




    }
}
