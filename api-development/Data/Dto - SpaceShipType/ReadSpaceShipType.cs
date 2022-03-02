using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoSpaceShipTypeDto
{
    public class ReadSpaceShipTypeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual int CountSpaceShip {get;set;}
    }
}
