using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Data.DtoMaintenance
{
    public class UpdateMaintenanceDto
    {
        public int Efficiency { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } //vai ser um daqueles enum
        public DateTime StartDate { get; private set; }    
        public DateTime EndDate { get; private set; }
        public int SpaceShipProblemId { get; set; }
        public int ToolPerPartId { get; set; }
    }
}
