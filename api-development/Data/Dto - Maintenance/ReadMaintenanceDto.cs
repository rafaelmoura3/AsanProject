using System;
using System.ComponentModel.DataAnnotations;
using AsanAPI.Models;

namespace AsanAPI.Data.DtoMaintenance
{
    public class ReadMaintenanceDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Efficiency { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } //vai ser um daqueles enum

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public SpaceShipProblem SpaceShipProblem { get; set; }
        public ToolPerPart ToolPerPart { get; set; }

    }
}
