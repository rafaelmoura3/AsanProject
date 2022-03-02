

using System;
using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoToolPerPart
{
    public class ReadToolPerPartDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Efficiency {get; set;} 
        public int PartId { get; set; }
        public int ToolId { get; set; }
        [DataType(DataType.Date)]
        public DateTime ConsultationTime => DateTime.UtcNow.ToLocalTime();
    }
}
