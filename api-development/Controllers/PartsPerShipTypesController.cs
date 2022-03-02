using AsanAPI.Data;
using AsanAPI.Data.DtoPartsPerShipType;
using AsanAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("partsPerShipTypes")]//rota
    public class PartsPerShipTypesController : ControllerBase
    {
        private AsanContext _context;
        private IMapper _mapper;

        public PartsPerShipTypesController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[FromBody] define de onde vem a informação que vamos capturar
        [HttpPost]//define o tipo do http request
        public IActionResult AddPartsPerShips([FromBody] CreatePartsPerShipTypeDto partsPerShipTypesDto)
        {
            PartsPerShipType partsPerShipTypes = _mapper.Map<PartsPerShipType>(partsPerShipTypesDto);
            try
            {
                _context.PartsPerShipTypes.Add(partsPerShipTypes);
                _context.SaveChanges();//salva as alterações no banco
                return CreatedAtAction(nameof(GetPartsPerShipTypesPerId), new { Id = partsPerShipTypes.Id }, partsPerShipTypes);
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível vincular peça a nave, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        public IEnumerable<PartsPerShipType> GetPartsPerShipTypes()
        {
            return (_context.PartsPerShipTypes);
        }

        [HttpGet("{id}")]//coloquei um parametro
        public IActionResult GetPartsPerShipTypesPerId(int id)
        {
            PartsPerShipType partsPerShipTypes = _context.PartsPerShipTypes.FirstOrDefault(partsPerShipTypes => partsPerShipTypes.Id == id);
            if (partsPerShipTypes != null)
            {
                return Ok(new { partsPerShipTypes, Status = true, Message = "Peças e naves recuperadas com sucesso." });//200
            }
            return NotFound(new { Status = false, Message = "Peças e naves não foram encontrados." });
        }

        [HttpPut("{id}")]
        public IActionResult AttPartsPerShipTypes(int id, [FromBody] UpdatePartsPerShipTypeDto partsPerShipTypesDto)
        {
            PartsPerShipType partsPerShipTypes = _context.PartsPerShipTypes.FirstOrDefault(partsPerShipTypes => partsPerShipTypes.Id == id);
            if (partsPerShipTypes == null)
            {
                return NotFound(new { Status = false, Message = "Peças e naves não foram encontradas." });
            }
            try
            {
            _mapper.Map(partsPerShipTypesDto, partsPerShipTypes);
             _context.Update(partsPerShipTypes);
            _context.SaveChanges();
            return Ok(new { partsPerShipTypes, Status = true, Message = "Peça e nave atualizadas com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar a nave e a peça, ocorreu o erro: " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DelPartsPerShipTypes(int id)
        {
            PartsPerShipType partsPerShipTypes = _context.PartsPerShipTypes.FirstOrDefault(partsPerShipTypes => partsPerShipTypes.Id == id);
            if (partsPerShipTypes == null)
            {
               return NotFound(new { Status = false, Message = "Peças e naves não encontradas." });
            }
            try
            {
            _context.Remove(partsPerShipTypes);
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
