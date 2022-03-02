using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoPartsPerShipType
{
    public class CreatePartsPerShipTypeDto
    {
        
        [Required(ErrorMessage = "O campo quantidade não pode estar vazio")]
        public int Amount { get; set; }
        public int PartId { get; set; }
        public int SpaceShipTypeId { get; set; }

    }
}
