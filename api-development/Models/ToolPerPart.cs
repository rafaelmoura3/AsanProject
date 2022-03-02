using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class ToolPerPart
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo eficiencia não pode estar vazio")]
        public int Efficiency {get; set;} 
        public int PartId { get; set; }
        public virtual Part Part { get; set; }
        public int ToolId { get; set; }
        public virtual Tool Tool { get; set; }
        [JsonIgnore]
        public virtual List<Maintenance> Maintenance { get; set; }
    }
}
