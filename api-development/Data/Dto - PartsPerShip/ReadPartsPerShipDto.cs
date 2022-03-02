

using System;
using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoPartsPerShip
{
    public class ReadPartsPerShipDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int SpaceShipTypeId { get; set; }
        public int SpaceShipId { get; set; }
        public int PartId { get; set; }
        public int Health { get; set; }
    }
}
