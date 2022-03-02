using AsanAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AsanAPI.Data.DtoSpaceShip
{
    public class ReadSpaceShipProblemDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Date { get; set; }
        public int Status { get; private set; }
        public Problem Problem { get; set; }
        public SpaceShip SpaceShip { get; set; }
        public Part Part { get; set; }
    }
}
