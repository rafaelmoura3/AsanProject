using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoToolPerPart
{
    public class UpdateToolPerPartDto
    {
        [Required(ErrorMessage = "O campo eficiencia não pode estar vazio")]
        public int Efficiency {get; set;}
        public int PartId { get; set; }
        public int ToolId { get; set; }
    }
}
