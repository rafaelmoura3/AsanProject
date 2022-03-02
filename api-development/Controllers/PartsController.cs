using AsanAPI.Data;
using AsanAPI.Data.DtoPart;
using AsanAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("parts")]
    public class PartsController : ControllerBase
    //IBaseGenerico (contexto, modelo), ControllerGenerico:ControllerBase<Model>(Context context, IMapper mapper) 
    {
        private AsanContext _context;
        private IMapper _mapper;

        public PartsController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddPart([FromBody] CreatePartDTO partDto)
        {
            Part part = _mapper.Map<Part>(partDto);
            try
            {
                _context.Parts.Add(part);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetPartPerId), new { Status = true, Message = "Peça adicionada com sucesso", Id = part.Id }, part);

            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível adicionar a peça, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        public IEnumerable<Part> GetPart()
        {
            return _context.Parts;
        }

        [HttpGet("{id}")]
        public object GetPartPerId(int id)
        {
            Part part = _context.Parts.FirstOrDefault(part => part.Id == id);
            if (part != null)
            {
                ReadPartDTO partDto = _mapper.Map<ReadPartDTO>(part);
                partDto.ConsultationTime = DateTime.Now;
                return Ok(new { part, Status = true, Message = "Peça recuperada com sucesso." });
            }
            else
            {
                return NotFound(new { Status = false, Message = "Peça não encontrada." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult AttPart(int id, [FromBody] UpdatePartDTO updatedPartDTO)
        {
            Part part = _context.Parts.FirstOrDefault(part => part.Id == id);
            if (part == null)
            {
                return NotFound(new { Status = false, Message = "Peça não encontrado." });
            }
            try
            {
                _mapper.Map(updatedPartDTO, part);
                _context.Update(part);
                _context.SaveChanges();
                return Ok(new { part, Status = true, Message = "Peça atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar a peça, ocorreu o erro: " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DelPart(int id)
        {
            Part part = _context.Parts.FirstOrDefault(part => part.Id == id);
            if (part == null)
            {
                return NotFound(new { Status = false, Message = "Peça não encontrada." });
            }
            try
            {
                _context.Remove(part);
                _context.SaveChanges();
                return Ok(new { Status = true, Message = "Peça deletado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar a peça, ocorreu o erro: " + e.Message });
            }
        }

    }
}
