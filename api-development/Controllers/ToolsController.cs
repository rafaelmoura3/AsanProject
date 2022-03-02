using AsanAPI.Data;
using AsanAPI.Data.DtoTools;
using AsanAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsanAPI.Controllers
{
    [ApiController]
    [Route("tools")]//rota
    public class ToolsController : ControllerBase
    {
        private AsanContext _context;
        private IMapper _mapper;

        public ToolsController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[FromBody] define de onde vem a informação que vamos capturar
        [HttpPost]//define o tipo do http request
        public IActionResult AddTool([FromBody] CreateToolDto toolDto)
        {
            Tool tool = _mapper.Map<Tool>(toolDto);

            _context.Tools.Add(tool);
            _context.SaveChanges();//salva as alterações no banco
            return CreatedAtAction(nameof(GetToolPerId), new { Id = tool.Id }, tool);
        }
            
        [HttpGet]
        public IEnumerable<Tool> GetTool()
        {
            return (_context.Tools);
            //jogador caro
        }

        [HttpGet("{id}")]//coloquei um parametro
        public IActionResult GetToolPerId(int id)
        {
            Tool tool = _context.Tools.FirstOrDefault(tool => tool.Id == id);
            if (tool != null)
            { 
                return Ok(new { tool, Status = true, Message = "Ferramenta recuperada com sucesso." });//200
            }
           return NotFound(new { Status = false, Message = "Ferramenta não encontrada." });
        }

        [HttpPut("{id}")]
        public IActionResult AttTool(int id, [FromBody] UpdateToolDto toolDto)
        {
            Tool tool = _context.Tools.FirstOrDefault(tool => tool.Id == id);
            if (tool == null)
            {
                return NotFound(new { Status = false, Message = "Ferramenta não encontrada." });
            }
            try
            {
            _mapper.Map(toolDto, tool);
            _context.Update(tool);
            _context.SaveChanges();
            return Ok(new { tool, Status = true, Message = "Ferramenta atualizada com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar a ferramenta, ocorreu o erro: " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DelTool(int id)
        {
            Tool tool = _context.Tools.FirstOrDefault(tool => tool.Id == id);
            if (tool == null)
            {
               return NotFound(new { Status = false, Message = "Ferramenta não encontrada." });
            }
            try
            {
            _context.Remove(tool);
            _context.SaveChanges();
            return Ok(new { Status = true, Message = "Ferramenta deletada com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar o ferramenta, ocorreu o erro: " + e.Message });
            }
        }
    }
}
