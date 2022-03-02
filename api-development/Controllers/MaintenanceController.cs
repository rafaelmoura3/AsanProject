using AsanAPI.Data;
using AsanAPI.Data.DtoMaintenance;
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
    [Route("maintenances")]//rota

    //teste de commit
    public class MaintenanceController : ControllerBase
    {
        private AsanContext _context;
        private IMapper _mapper;

        public MaintenanceController(AsanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMaintenance([FromBody] CreateMaintenanceDto maintenanceDto)
        {
            Maintenance maint = _mapper.Map<Maintenance>(maintenanceDto);
            try
            {
                _context.Maintenances.Add(maint);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetMaintenaceById), new { Status = true, Message = "Manutenção adicionada com sucesso", Id = maint.Id }, maint);
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível adicionar a manutenção, ocorreu o erro: " + e.Message });
            }
        }

        [HttpGet]
        public IEnumerable<Maintenance> GetMaintenace()
        {
            return _context.Maintenances;
        }

        [HttpGet("{id}")]
        public object GetMaintenaceById(int id)
        {
            Maintenance maint = _context.Maintenances.FirstOrDefault(maint => maint.Id == id);
            if (maint != null)
            {
                ReadMaintenanceDto maintDto = _mapper.Map<ReadMaintenanceDto>(maint);
                return Ok(new { maint, Status = true, Message = "Manutenção recuperada com sucesso." });
            }
            else
            {
                return NotFound(new { Status = false, Message = "Manutenção não encontrada." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult AttMaintenance(int id, [FromBody] UpdateMaintenanceDto updateMaintenanceDto)
        {
            Maintenance maint = _context.Maintenances.FirstOrDefault(maint => maint.Id == id);
            if (maint == null)
            {
                return NotFound(new { Status = false, Message = "Manutenção não encontrada." });
            }
            try
            {
                _mapper.Map(updateMaintenanceDto, maint);
                _context.Update(maint);
                _context.SaveChanges();
                return Ok(new { maint, Status = true, Message = "Manutenção atualizada com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível atualizar a manutenção, ocorreu o erro: " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DelMaintenance(int id)
        {
            Maintenance maint = _context.Maintenances.FirstOrDefault(maint => maint.Id == id);
            if (maint == null)
            {
                return NotFound(new {Status = false, Message = "Manutenção não encontrada" });
            }
            try
            {
                _context.Remove(maint);
                _context.SaveChanges();
                return Ok(new { Status = true, Message = "Manutenção deletada com sucesso." });
            }
            catch (Exception e)
            {
                return Conflict(new { Status = false, Message = "Não foi possível deletar a manutenção, ocorreu um erro: " + e.Message });
            }


        }

        /*
        Quais ferramentas (quais peças ?)
        atribuir com base nos cadastros de peça por ferramenta ou por problema,
        que vao ter um percentual de eficiencia, que vao curar um percentual de vida
        Ex: dano 10 pontos de vida, eficiencia 70%, vai curar 7 pontos de vida;
        */

        //Só teste
        [HttpPut("repair/{id}")]
        public IActionResult Repair(int id)
        {

            //Na pior, se não der tempo de fazer a lógica completa tem essa meia boca:
            try
            {
                var spaceShip = _context.SpaceShips
                    .Where(key => key.Id == id)
                    .FirstOrDefault();

                var spaceShipProblem = _context.SpaceShipProblems
                    .Where(key => key.SpaceShipId == id && key.Status != 2)
                    .FirstOrDefault();

                //problemas nas peças

                if (spaceShip == null || spaceShipProblem == null)
                {
                    return NotFound(new { Status = "false", Message = "Nave ou problema não encontrado." });
                }
                else
                {
                    var oldHealth = spaceShip.Health;
                    spaceShip.Health += spaceShipProblem.Damage;
                    //Retorna vida reparada
                    double healthRepaired = spaceShip.Health - oldHealth;

                    //corrigir = 2 -> status
                    spaceShipProblem.Corrigir();

                    //alterar status maintenance para corrigido
                    _context.SaveChanges();
                    return Ok(new { spaceShip, healthRepaired = healthRepaired, Warn = "Vida da nave antes da manutenção: " + oldHealth, Status = "true", Message = "Manutenção realizada com sucesso." }); ;
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Status = "false", Message = "Não foi possível realizar a manutenção na nave, ocorreu o erro:" + e.Message });
            }
        }
    }
}