using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsanAPI.Data.DtoProblem
{
    public class ReadProblemDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome não pode estar vazio")]
        [StringLength(150, ErrorMessage = "O campo nome não pode passar de 150 caracteres.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ConsultationTime => DateTime.UtcNow.ToLocalTime();
    }
}
