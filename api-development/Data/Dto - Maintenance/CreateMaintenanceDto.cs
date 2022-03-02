using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Data.DtoMaintenance
{
    public class CreateMaintenanceDto
    { 
        public int Efficiency { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } //vai ser um daqueles enum
        public DateTime StartDate { get; private set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
        public int ToolPerPartId { get; set; }
        public int SpaceShipProblemId { get; set; }
    }
}
