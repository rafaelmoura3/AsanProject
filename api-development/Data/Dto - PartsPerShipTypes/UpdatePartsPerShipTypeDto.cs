using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoPartsPerShipType
{
    public class UpdatePartsPerShipTypeDto
    {

        public int Amount { get; set; }
        public int PartId { get; set; }
        public int SpaceShipTypeId { get; set; }

    }
}
