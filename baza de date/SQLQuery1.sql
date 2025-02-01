-- Crearea bazei de date
CREATE DATABASE TransportManagement;
GO

USE TransportManagement;
GO

-- Tabel pentru utilizatori
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Dispecer', 'Sofer', 'Manager')) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(15)
);
GO

-- Tabel pentru vehicule
CREATE TABLE Vehicles (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    LicensePlate NVARCHAR(15) NOT NULL UNIQUE,
    VehicleType NVARCHAR(50),
    FuelType NVARCHAR(20) CHECK (FuelType IN ('Diesel', 'Petrol', 'Electric', 'Hybrid')),
    FuelConsumptionRate DECIMAL(5, 2), -- Consum mediu de combustibil (litri/100km)
    Status NVARCHAR(20) DEFAULT 'Available' CHECK (Status IN ('Available', 'In Use', 'Under Maintenance'))
);
GO

-- Tabel pentru rute
CREATE TABLE Routes (
    RouteID INT IDENTITY(1,1) PRIMARY KEY,
    RouteName NVARCHAR(100) NOT NULL,
    StartLocation NVARCHAR(100) NOT NULL,
    EndLocation NVARCHAR(100) NOT NULL,
    Distance DECIMAL(10, 2) NOT NULL -- Distanta in kilometri
);
GO

-- Tabel pentru asignarea rutelor catre vehicule si soferi
CREATE TABLE RouteAssignments (
    AssignmentID INT IDENTITY(1,1) PRIMARY KEY,
    RouteID INT NOT NULL,
    VehicleID INT NOT NULL,
    DriverID INT NOT NULL,
    AssignmentDate DATE NOT NULL,
    EstimatedStartTime DATETIME,
    EstimatedEndTime DATETIME,
    FOREIGN KEY (RouteID) REFERENCES Routes(RouteID),
    FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (DriverID) REFERENCES Users(UserID)
);
GO

-- Tabel pentru monitorizare GPS
CREATE TABLE GPSMonitoring (
    GPSID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleID INT NOT NULL,
    Timestamp DATETIME NOT NULL,
    Latitude DECIMAL(9, 6) NOT NULL,
    Longitude DECIMAL(9, 6) NOT NULL,
    Speed DECIMAL(5, 2),
    FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID)
);
GO

-- Tabel pentru consum combustibil
CREATE TABLE FuelConsumption (
    ConsumptionID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleID INT NOT NULL,
    RouteID INT NOT NULL,
    FuelUsed DECIMAL(10, 2) NOT NULL, -- Combustibil consumat (litri)
    ConsumptionDate DATE NOT NULL,
    FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (RouteID) REFERENCES Routes(RouteID)
);
GO

-- Tabel pentru rapoarte
CREATE TABLE Reports (
    ReportID INT IDENTITY(1,1) PRIMARY KEY,
    ReportType NVARCHAR(20) CHECK (ReportType IN ('Fuel', 'Route', 'Maintenance', 'Performance')) NOT NULL,
    GeneratedBy INT NOT NULL,
    GeneratedAt DATETIME NOT NULL DEFAULT GETDATE(),
    Content NVARCHAR(MAX),
    FOREIGN KEY (GeneratedBy) REFERENCES Users(UserID)
);
GO
