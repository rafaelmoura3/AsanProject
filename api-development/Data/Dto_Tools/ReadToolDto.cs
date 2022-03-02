using System;
using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoTools
{
    public class ReadToolDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome da ferramenta não pode estar vazio")]///notacao de validacao
        public string Name { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
