using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsanAPI.Models
{
    public class SpaceShipProblem
    {
        [Key]
        [Required]
        public int Id { get; set; }        
        public string Date { get; set; }
        public int Status { get; private set; }
        public int Damage { get; set; }

        [JsonIgnore]        
        public int ProblemId { get; set; }
        public virtual Problem Problem { get; set; }

        [JsonIgnore]
        public int SpaceShipId { get; set; }
        public virtual SpaceShip SpaceShip { get; set; }

        [JsonIgnore]
        public int  PartId{ get; set; }
        public virtual Part Part { get; set; }
        [JsonIgnore]
        public virtual List<Maintenance> Maintenance { get; set; }

        public void Corrigir()
        {
            Status = 2;
        }

    }
}
