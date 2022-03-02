using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using AsanAPI.Data;
using AsanAPI.Models;
using AutoMapper;
using AsanAPI.Data.DtoSpaceShipTypeDto;
using Microsoft.EntityFrameworkCore;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("spaceshiptype")]

    public class SpaceShipTypeController : Controller
    {
        private IMapper _mapper;
        private AsanContext _context;

        public SpaceShipTypeController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSpaceShipsType([FromBody] CreateSpaceShipTypeDto shipTypeDto)
        {
            SpaceShipType spaceShipType = _mapper.Map<SpaceShipType>(shipTypeDto);
            try
            {
                _context.SpaceShipTypes.Add(spaceShipType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(AddSpaceShipsType), new { Id = spaceShipType.Id }, spaceShipType);
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível adicionar o tipo de nave, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        public IEnumerable<SpaceShipType> GetSpaceShipsType()
        {
            return _context.SpaceShipTypes;
        }

        [HttpGet("{id}")]
        public IActionResult GetSpaceShipsTypePerId(int id)
        {
            SpaceShipType spaceShipType = _context.SpaceShipTypes.FirstOrDefault(spaceShipType => spaceShipType.Id == id);
            if (spaceShipType != null)
            {
                ReadSpaceShipTypeDto shipDto = _mapper.Map<ReadSpaceShipTypeDto>(spaceShipType);

                return Ok(new { spaceShipType, Status = true, Message = "Tipo de nave recuperado com sucesso." });//200
            }
            else
            {
                return NotFound(new { Status = false, Message = "Tipo de nave não encontrado." });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSpaceShipsType(int id, [FromBody] UpdateSpaceShipTypeDto shipTypeDto)
        {
            SpaceShipType spaceShipType = _context.SpaceShipTypes.FirstOrDefault(spaceShipType => spaceShipType.Id == id);
            if (spaceShipType == null)
            {
                return NotFound(new{ Status = false, Message = "Tipo de nave não encontrado"});
            }
            try
            {
                _mapper.Map(shipTypeDto, spaceShipType);
                _context.Update(spaceShipType);
                _context.SaveChanges();
                return Ok(new{spaceShipType, Status = true, Message = "Tipo de nave atualizado com sucesso."});
            }
            catch(Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar o tipo de nave, ocorreu o erro: " + e.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DelSpaceShipsType(int id)
        {
            SpaceShipType spaceShipType = _context.SpaceShipTypes.FirstOrDefault(spaceShipType => spaceShipType.Id == id);
            if (spaceShipType == null)
            {
                return NotFound(new{ Status = false, Message = "Tipo de nave não encontrado"});
            }
            try
            {
                _context.Remove(spaceShipType);
                _context.SaveChanges();
                return Ok(new { Status = true, Message = "Tipo de nave deletado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar o tipo de nave, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        [Route("count")]
        public IEnumerable<ReadSpaceShipTypeDto> CountAllShips()
        {

            var types = _context.SpaceShipTypes
                .FromSqlRaw(@"select tipo.Id, tipo.Name, tipo.Description, count(nave.Id) QuantidadeNaves
                from SpaceShipTypes tipo
                left join SpaceShips nave on (tipo.Id = nave.SpaceShipTypeId)
                group by tipo.Id, tipo.Name, tipo.Description")
                .ToList();

            return _mapper.Map<IEnumerable<ReadSpaceShipTypeDto>>(types);
            //Para o front: Fazer um v-if>0 desabilitar botao -> porém garantir que o btn nao vai exec nada -> tirar func do OnClick + disable
            //   v-else habilitar
        }
    }
}
