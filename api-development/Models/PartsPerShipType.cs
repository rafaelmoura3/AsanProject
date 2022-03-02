using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class PartsPerShipType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo quantidade não pode estar vazio")]
        public int Amount {get; set;} 
        public int PartId { get; set; }
        [JsonIgnore]
        public virtual Part Part { get; set; }
        public int SpaceShipTypeId { get; set; }
        [JsonIgnore]
        public virtual SpaceShipType SpaceShipType { get; set; }
        [JsonIgnore]
        public virtual List<PartsPerShip> PartsPerShip { get; set; }
    }
}
