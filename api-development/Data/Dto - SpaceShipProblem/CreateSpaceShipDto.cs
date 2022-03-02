using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsanAPI.Data.DtoSpaceShip
{
    public class CreateSpaceShipProblemDto
    {
        public string Date { get; set; }
        public int Status { get; private set; }
        public int Damage { get; private set; }
        public int ProblemId { get; set; }
        public int SpaceShipId { get; set; }
        public int PartId { get; set; }
    }
}