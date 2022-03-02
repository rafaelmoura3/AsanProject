using AsanAPI.Data;
using AsanAPI.Data.DtoSpaceShip;
using AsanAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("spaceShipProblems")]
    public class SpaceShipProblemController:ControllerBase
    {
        private readonly IMapper _mapper;
        private AsanContext _context;
        
        public SpaceShipProblemController(IMapper mapper, AsanContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateSpaceShipProblemDto shipProblemDto)
        {
            SpaceShipProblem spaceShipProblem = _mapper.Map<SpaceShipProblem>(shipProblemDto);
            try
            {
                _context.SpaceShipProblems.Add(spaceShipProblem);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Add), new { Id = spaceShipProblem.Id }, spaceShipProblem);
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível adicionar o problema a nave, ocorreu o erro: " + e.Message });
            }

        }

        [HttpGet]
        public IEnumerable<SpaceShipProblem> GetAll()
        {
            return _context.SpaceShipProblems;
        }

        [HttpGet("{id}")]
        public IActionResult GetPerId(int id)
        {
            SpaceShipProblem spaceShipProblem = _context.SpaceShipProblems.FirstOrDefault(spaceShipProblem => spaceShipProblem.Id == id);
            if (spaceShipProblem != null)
            {
                ReadSpaceShipProblemDto shipDto = _mapper.Map<ReadSpaceShipProblemDto>(spaceShipProblem);

                return Ok(new { spaceShipProblem, Status = true, Message = "Problema da nave recuperado com sucesso." });//200
            }
            else
            {
                return NotFound(new { Status = false, Message = "Problema da nave não encontrado." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpaceShipProblems(int id, [FromBody] UpdateSpaceShipProblemDto spaceShipProblemDto)
        {
            SpaceShipProblem spaceShipProblem = _context.SpaceShipProblems.FirstOrDefault(spaceShipProblem => spaceShipProblem.Id == id);
            if (spaceShipProblem == null)
            {
                return NotFound(new { Status = false, Message = "Problema da nave não encontrado" });
            }
            try
            {
                _mapper.Map(spaceShipProblemDto, spaceShipProblem);
                _context.Update(spaceShipProblem);
                _context.SaveChanges();
                return Ok(new { spaceShipProblem, Status = true, Message = "Problema da nave atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar o problema da nave, ocorreu o erro: " + e.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DelSpaceShipProblems(int id)
        {
            SpaceShipProblem spaceShipProblem = _context.SpaceShipProblems.FirstOrDefault(spaceShipProblem => spaceShipProblem.Id == id);
            if (spaceShipProblem == null)
            {
                return NotFound(new { Status = false, Message = "Problema da nave não encontrado" });
            }
            try
            {
                _context.Remove(spaceShipProblem);
                _context.SaveChanges();
                return Ok(new { Status = true, Message = "Problema da nave deletado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar o problema da nave, ocorreu o erro: " + e.Message });
            }
        }

    }
}
