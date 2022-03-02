using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Data.DtoPartsPerShip
{
    public class CreatePartsPerShipDto
    {
        public int PartsPerShipTypeId { get; set; }
        public int SpaceShipId { get; set; }
        public int PartId { get; set; }
        [JsonIgnore]
        public int Health { get; set; }

    }
}
