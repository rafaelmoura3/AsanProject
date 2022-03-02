using AsanAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsanAPI.Models
{
    public class Problem
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'problema conhecido' não pode estar vazio")]
        [StringLength(150, ErrorMessage = "O campo nome não pode passar de 150 caracteres.")]
        [DisplayName("Problema conhecido")]
        public string Name { get; set; }

        
        [Range(0,99)]
        [JsonIgnore]
        public int Damage { get; set; }

        [JsonIgnore]
        public virtual List<SpaceShipProblem> SpaceShipProblem { get; set; }



    }
}
