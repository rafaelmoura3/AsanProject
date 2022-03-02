using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class SpaceShipType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tipo de Nave é obrigatório")]
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<SpaceShip> SpaceShip { get; set; }
        [JsonIgnore]
        public virtual List<PartsPerShipType> PartsPerShipType { get; set; }
    }
}
