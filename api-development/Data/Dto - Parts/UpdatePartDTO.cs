using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsanAPI.Data.DtoPart
{
    public class UpdatePartDTO
    {

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo nome não pode estar vazio")]
        public string Name { get; set; }
        [Range(1,100, ErrorMessage = "O campo vida não pode ser menor que 1")]
         public int Health { get; set;}

        [DisplayName("Descrição")]
        public string Description { get; set; }

        public DateTime LastUpdated => DateTime.UtcNow.ToLocalTime();
    }
}
