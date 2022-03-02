using AsanAPI.Data;
using AsanAPI.Data.DtoPartsPerShip;
using AsanAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("partsPerShips")]//rota
    public class PartsPerShipsController : ControllerBase
    {
        private AsanContext _context;
        private IMapper _mapper;

        public PartsPerShipsController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[FromBody] define de onde vem a informação que vamos capturar
        [HttpPost]//define o tipo do http request
        public IActionResult AddPartsPerShips([FromBody] CreatePartsPerShipDto partsPerShipsDto)
        {
            PartsPerShip partsPerShips = _mapper.Map<PartsPerShip>(partsPerShipsDto);
            try
            {
                _context.PartsPerShips.Add(partsPerShips);
                _context.SaveChanges();//salva as alterações no banco
                return CreatedAtAction(nameof(GetPartsPerShipsPerId), new { Id = partsPerShips.Id }, partsPerShips);
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível vincular peça a nave, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        public IEnumerable<PartsPerShip> GetPartsPerShips()
        {
            return (_context.PartsPerShips);
        }

        [HttpGet("{id}")]//coloquei um parametro
        public IActionResult GetPartsPerShipsPerId(int id)
        {
            PartsPerShip partsPerShips = _context.PartsPerShips.FirstOrDefault(partsPerShips => partsPerShips.Id == id);
            if (partsPerShips != null)
            {
                return Ok(new { partsPerShips, Status = true, Message = "Peças e naves recuperadas com sucesso." });//200
            }
            return NotFound(new { Status = false, Message = "Peças e naves não foram encontrados." });
        }

        [HttpPut("{id}")]
        public IActionResult AttPartsPerShips(int id, [FromBody] UpdatePartsPerShipDto partsPerShipsDto)
        {
            PartsPerShip partsPerShips = _context.PartsPerShips.FirstOrDefault(partsPerShips => partsPerShips.Id == id);
            if (partsPerShips == null)
            {
                return NotFound(new { Status = false, Message = "Peças e naves não foram encontradas." });
            }
            try
            {
            _mapper.Map(partsPerShipsDto, partsPerShips);
             _context.Update(partsPerShips);
            _context.SaveChanges();
            return Ok(new { partsPerShips, Status = true, Message = "Peça e nave atualizadas com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar a nave e a peça, ocorreu o erro: " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DelPartsPerShips(int id)
        {
            PartsPerShip partsPerShips = _context.PartsPerShips.FirstOrDefault(partsPerShips => partsPerShips.Id == id);
            if (partsPerShips == null)
            {
               return NotFound(new { Status = false, Message = "Peças e naves não encontradas." });
            }
            try
            {
            _context.Remove(partsPerShips);
            _context.SaveChanges();
            return Ok(new { Status = true, Message = "Peças e naves deletadas com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar a peça e a nave, ocorreu o erro: " + e.Message });
            }
        }
    }
}
