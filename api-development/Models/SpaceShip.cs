using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class SpaceShip
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da nave é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A cor da nave é obrigatória")]
        public string Color { get; set; }
        [Required(ErrorMessage = "O ano da nave é obrigatório")]
        public int Year { get; set; }
        public string Description { get; set; }
        public int Health { get; set; }

        public virtual SpaceShipType SpaceShipType { get; set; }
        [JsonIgnore]
        public int SpaceShipTypeId { get; set; }

        [JsonIgnore]
        public virtual List<SpaceShipProblem> SpaceShipProblem { get; set; }
        [JsonIgnore]
        public virtual List<PartsPerShip> PartsPerShip { get; set; }

        public bool YearIsValid()
        {
            if (Year < 1900 || Year > DateTime.UtcNow.Year)
            {
                return false; //invalido
            }
            return true;
        }
    }
}