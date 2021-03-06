using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoSpaceShipTypeDto
{
    public class UpdateSpaceShipTypeDto
    {
        [Required(ErrorMessage = "O campo nome não pode estar vazio")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
