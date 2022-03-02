using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoSpaceShip
{
    public class CreateSpaceShipDto
    {
        [Required(ErrorMessage = "O campo nome não pode estar vazio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo cor não pode estar vazio")]
        public string Color { get; set; }
        [Required(ErrorMessage = "O campo ano não pode estar vazio")]
        public int Year { get; set; }
        public string Description { get; set; }
        public int Health { get; private set; } = 100;
        public int SpaceShipTypeId { get; set; }
    }
}