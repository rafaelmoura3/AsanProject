using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class Maintenance
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Efficiency { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } //vai ser um daqueles enum

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public virtual ToolPerPart ToolPerPart { get; set; }
        [JsonIgnore]
        public int ToolPerPartId { get; set; }

        public virtual  SpaceShipProblem SpaceShipProblem { get; set; }
        [JsonIgnore]
        public int SpaceShipProblemId { get; set; }
        
    }
}