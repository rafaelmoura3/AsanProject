using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoTools
{
    public class UpdateToolDto
    {
        [Required(ErrorMessage = "O campo nome da ferramenta não pode estar vazio")]///notacao de validacao
        public string Name { get; set; }
    }
}
