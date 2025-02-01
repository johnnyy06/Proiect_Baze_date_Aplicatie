using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoFlow.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
        public string FuelType { get; set; }
        public decimal FuelConsumptionRate { get; set; }
        public string Status { get; set; }
    }
}
