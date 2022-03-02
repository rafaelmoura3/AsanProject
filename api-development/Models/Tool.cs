using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class Tool
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Nome da ferramenta não pode estar vazio")]///notacao de validacao
        public string Name { get; set; }
        [JsonIgnore]
         public virtual List<ToolPerPart> ToolPerParts { get; set; }
    }
}

