using AsanAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AsanAPI.Data.DtoSpaceShip
{
    public class ReadSpaceShipDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome não pode estar vazio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo cor não pode estar vazio")]
        public string Color { get; set; }
        [Required(ErrorMessage = "O campo ano não pode estar vazio")]
        public int Year { get; set; }
        public string Description { get; set; }
        public SpaceShipType SpaceShipType { get; set; }
    }
}
