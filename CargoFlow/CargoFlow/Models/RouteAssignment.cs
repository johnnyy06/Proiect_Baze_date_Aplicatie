using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoFlow.Models
{
    public class RouteAssignment
    {
        public int AssignmentID { get; set; }
        public int RouteID { get; set; }
        public int VehicleID { get; set; }
        public int DriverID { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? EstimatedStartTime { get; set; }
        public DateTime? EstimatedEndTime { get; set; }

        public virtual Route Route { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
