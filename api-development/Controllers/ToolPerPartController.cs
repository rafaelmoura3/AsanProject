using AsanAPI.Data;
using AsanAPI.Data.DtoToolPerPart;
using AsanAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("toolperpart")]//rota
    public class ToolPerPartController : ControllerBase
    {
        private AsanContext _context;
        private IMapper _mapper;

        public ToolPerPartController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[FromBody] define de onde vem a informação que vamos capturar
        [HttpPost]//define o tipo do http request
        public IActionResult AddToolPerPart([FromBody] CreateToolPerPartDto toolperpartDto)
        {
            ToolPerPart toolperpart = _mapper.Map<ToolPerPart>(toolperpartDto);
            try
            {
                _context.ToolPerParts.Add(toolperpart);
                _context.SaveChanges();//salva as alterações no banco
                return CreatedAtAction(nameof(GetToolPerPartPerId), new { Id = toolperpart.Id }, toolperpart);
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível vincular ferramenta a peça, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        public IEnumerable<ToolPerPart> GetToolPerPart()
        {
            return (_context.ToolPerParts);
        }

        [HttpGet("{id}")]//coloquei um parametro
        public IActionResult GetToolPerPartPerId(int id)
        {
            ToolPerPart toolperpart = _context.ToolPerParts.FirstOrDefault(toolperpart => toolperpart.Id == id);
            if (toolperpart != null)
            {
                return Ok(new { toolperpart, Status = true, Message = "Ferramentas e peças recuperadas com sucesso." });//200
            }
            return NotFound(new { Status = false, Message = "Ferramenta e peça não foram encontradas." });
        }

        [HttpPut("{id}")]
        public IActionResult AttToolPerPart(int id, [FromBody] UpdateToolPerPartDto toolperpartDto)
        {
            ToolPerPart toolperpart = _context.ToolPerParts.FirstOrDefault(toolperpart => toolperpart.Id == id);
            if (toolperpart == null)
            {
                return NotFound(new { Status = false, Message = "Ferramenta e peça não foram encontradas." });
            }
            try
            {
            _mapper.Map(toolperpartDto, toolperpart);
             _context.Update(toolperpart);
            _context.SaveChanges();
            return Ok(new { toolperpart, Status = true, Message = "Ferramenta e peça atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar o ferramenta e peça, ocorreu o erro: " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DelToolPerPart(int id)
        {
            ToolPerPart toolperpart = _context.ToolPerParts.FirstOrDefault(toolperpart => toolperpart.Id == id);
            if (toolperpart == null)
            {
               return NotFound(new { Status = false, Message = "Ferramenta e peça não encontrada." });
            }
            try
            {
            _context.Remove(toolperpart);
            _context.SaveChanges();
            return Ok(new { Status = true, Message = "Ferramenta e peça deletada com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar ferramenta e peça, ocorreu o erro: " + e.Message });
            }
        }
    }
}
