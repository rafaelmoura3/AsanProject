using System.ComponentModel.DataAnnotations;
using AsanAPI.Models;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class PartsPerShip
    {
        [Key]
        [Required]
        public int Id { get; set; }
       
        public virtual PartsPerShipType PartsPerShipType{ get; set; }
        [JsonIgnore]
        public int PartsPerShipTypeId { get; set; }
        public virtual SpaceShip SpaceShip { get; set; }
        [JsonIgnore]
        public int SpaceShipId { get; set; }
        [JsonIgnore]
        public virtual Part Part { get; set; }
        [JsonIgnore]
        public int PartId { get; set; }
        public int Health { get; set; }
    }
}