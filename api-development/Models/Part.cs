using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AsanAPI.Models
{
    public class Part
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Name { get; set; }
        [Range(1,100)]
        public int Health { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [JsonIgnore]
         public virtual List<ToolPerPart> ToolPerParts { get; set; }
        [JsonIgnore]
        public virtual List<SpaceShipProblem> SpaceShipProblem { get; set; }
        [JsonIgnore]
        public virtual List<PartsPerShipType> PartsPerShipType { get; set; }
        [JsonIgnore]
        public virtual List<PartsPerShip> PartsPerShip { get; set; }

    }
}
