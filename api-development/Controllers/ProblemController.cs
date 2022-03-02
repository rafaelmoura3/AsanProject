using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AsanAPI.Data;
using AsanAPI.Data.DtoProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using AsanAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("problems")]
    public class ProblemController : ControllerBase
    {
        private AsanContext _context;
        private IMapper _mapper;
        public ProblemController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult AddProblem([FromBody] CreateProblemDTO problemDto)
        {
            //Criacao de obj com construtor implícito
            //Convertendo
            Problem problem = _mapper.Map<Problem>(problemDto);
            try
            {
                _context.Problems.Add(problem);//Adicionando problema ao banco
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetProblemPerId), new { Status = true, Message = "Problema adicionado com sucesso", Id = problem.Id }, problem);//201 criado 
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível adicionar o problema, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        public IEnumerable<Problem> GetProblem()
        {
            return _context.Problems;
        }

        [HttpGet("{id}")]
        public IActionResult GetProblemPerId(int id)
        {
            Problem problem = _context.Problems.FirstOrDefault(problem => problem.Id == id);
            if (problem != null)
            {
                //ReadProblemDTO problemDto = _mapper.Map<ReadProblemDTO>(problem);
                return Ok(new { problem, Status = true, Message = "Problema recuperado com sucesso." });//200
            }
            else
            {
                return NotFound(new { Status = false, Message = "Problema não encontrado." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult AttProblem(int id, [FromBody] UpdateProblemDTO updatedProblemDto)
        {
            Problem problem = _context.Problems.FirstOrDefault(problem => problem.Id == id);
            if (problem == null)
            {
                return NotFound(new { Status = false, Message = "Problema não encontrado." });
            }
            //Convertendo.
            try
            {
                _mapper.Map(updatedProblemDto, problem);
                _context.Update(problem);
                _context.SaveChanges();
                return Ok(new { problem, Status = true, Message = "Problema atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar o problema, ocorreu o erro: " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DelProblem(int id)
        {
            Problem problem = _context.Problems.FirstOrDefault(problem => problem.Id == id);
            if (problem == null)
            {
                return NotFound(new { Status = false, Message = "Problema não encontrado." });
            }
            try
            {
                _context.Remove(problem);
                _context.SaveChanges();
                return Ok(new { Status = true, Message = "Problema deletado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar o problema, ocorreu o erro: " + e.Message });
            }
        }


        // id nave
        [Obsolete("Deprecated. Use 'UpdateRecord'")]
        [HttpPost("random/{id}")]
        public IActionResult GenerateProblemId(int id)
        {
            var randomProblem = _context.Problems
                .FromSqlRaw(@"select top 1 * from Problems order by NEWID()")
                .FirstOrDefault();

            var randomPartsPerShips = _context.PartsPerShips
                .FromSqlRaw(@"select * from PartsPerShips")
                .Where(shipId => shipId.SpaceShipId == id)
                .FirstOrDefault();

            try
            {
                if (randomPartsPerShips.SpaceShip.Health < 2)
                {
                    return Ok(new { Status = "false", Message = "Nave já está com sua vida zerada, leve-a para manutenção!" });
                }
            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message = "Não foi possível atribuir um problema aleatório, ocorreu o erro: " + e.Message });
            }

            SpaceShipProblem spaceShipProblem = new SpaceShipProblem();
            spaceShipProblem.ProblemId = randomProblem.Id;
            spaceShipProblem.SpaceShipId = randomPartsPerShips.SpaceShipId;
            spaceShipProblem.PartId = randomPartsPerShips.PartId;

            spaceShipProblem.Damage = new Random().Next(0, randomPartsPerShips.SpaceShip.Health);
            randomPartsPerShips.SpaceShip.Health -= spaceShipProblem.Damage;

            _context.Add(spaceShipProblem);
            _context.SaveChanges();
            return Ok(new { Status = "true", spaceShipProblem });
        }

        [HttpGet]
        [Route("random")]
        public IActionResult GenerateProblem()
        {
            try{
                var randomProblem = _context.Problems
                .FromSqlRaw(@"select top 1 * from Problems order by NEWID()")
                .FirstOrDefault();

                var randomPartsPerShips = _context.PartsPerShips
                    .FromSqlRaw(@"select top 1 * from PartsPerShips pps 
                where exists (select 1 from spaceships naves where naves.Id = pps.SpaceShipId and health > 2) 
                order by NEWID()")
                    .FirstOrDefault();
                SpaceShipProblem spaceShipProblem = new SpaceShipProblem();
                spaceShipProblem.ProblemId = randomProblem.Id;
                spaceShipProblem.SpaceShipId = randomPartsPerShips.SpaceShipId;
                spaceShipProblem.PartId = randomPartsPerShips.PartId;

                spaceShipProblem.Damage = new Random().Next(0, randomPartsPerShips.SpaceShip.Health);
                randomPartsPerShips.SpaceShip.Health -= spaceShipProblem.Damage;

                _context.Add(spaceShipProblem);
                _context.SaveChanges();
                return Ok(new { Status = "true", spaceShipProblem });
            }
            catch (Exception e){
                return Ok(new { Status = false, SpaceShipProblem = new { }, Message = "Não foi possível atribuir um problema aleatório, ocorreu o erro: " + e.Message });
            }
        }

        [HttpPost]
        [Route("random")]
        public IActionResult GenerateProblemPerId(SpaceShipProblemRequest request)
        {
            try{
                var randomProblem = _context.Problems
                 .FromSqlRaw(@"select top 1 * from Problems order by NEWID()")
                 .FirstOrDefault();


                string condicao = " And SpaceShipId in (";
                foreach (int id in request.Ids)
                {
                    if (!condicao.Equals(" And SpaceShipId in ("))
                    {
                        condicao += ", ";
                    }
                    condicao += id.ToString();
                }
                condicao += ")";

                var randomPartsPerShips = _context.PartsPerShips
                    .FromSqlRaw($@"select top 1 * from PartsPerShips pps 
                where exists (select 1 from spaceships naves where naves.Id = pps.SpaceShipId and health > 2)
                {condicao} 
                order by NEWID()")
                    .FirstOrDefault();

                SpaceShipProblem spaceShipProblem = new SpaceShipProblem();
                spaceShipProblem.ProblemId = randomProblem.Id;
                spaceShipProblem.SpaceShipId = randomPartsPerShips.SpaceShipId;
                spaceShipProblem.PartId = randomPartsPerShips.PartId;

                spaceShipProblem.Damage = new Random().Next(0, randomPartsPerShips.SpaceShip.Health);
                randomPartsPerShips.SpaceShip.Health -= spaceShipProblem.Damage;

                _context.Add(spaceShipProblem);
                _context.SaveChanges();
                return Ok(new { Status = "true", spaceShipProblem });
            }
            catch (Exception e){
                return Ok(new { Status = false, SpaceShipProblem = new { }, Message = "Não foi possível atribuir um problema aleatório, ocorreu o erro: " + e.Message });
            }
        }
    }
}