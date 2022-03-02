using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoPartsPerShip
{
    public class UpdatePartsPerShipDto
    {
        public int SpaceShipTypeId { get; set; }
        public int SpaceShipId { get; set; }
        public int PartId { get; set; }
    }
}
