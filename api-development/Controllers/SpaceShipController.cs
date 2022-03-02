using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AsanAPI.Data;
using AsanAPI.Data.DtoProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using AsanAPI.Models;
using AsanAPI.Data.DtoSpaceShip;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("ships")]

public class SpaceShipController : ControllerBase
{
    private IMapper _mapper;
    private AsanContext _context;

    public SpaceShipController(AsanContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddSpaceShips([FromBody] CreateSpaceShipDto shipDto)
    {
        SpaceShip spaceShip = _mapper.Map<SpaceShip>(shipDto);
        //Verificar com regra de negócio
        //Se o if estivesse dentro do try seria redundante
        try
        {
            if (!spaceShip.YearIsValid())
            {
                return BadRequest(new { Status = false, Message = "Ano da nave inválido" });
            }
            else
            {
                _context.Add(spaceShip);

                var spaceShipType = _context.SpaceShipTypes
                .Where(tipo => tipo.Id == spaceShip.SpaceShipTypeId)
                .Include(tipo => tipo.PartsPerShipType)
                .FirstOrDefault();

                foreach (PartsPerShipType peca in spaceShipType.PartsPerShipType)
                {

                    PartsPerShip partsPerShip = new PartsPerShip();
                    partsPerShip.SpaceShip = spaceShip;
                    partsPerShip.Part = peca.Part;
                    partsPerShip.Health = peca.Part.Health;
                    partsPerShip.PartsPerShipType = peca;


                    _context.Add(partsPerShip);
                }

                _context.SaveChanges();
                return CreatedAtAction(nameof(GetSpaceShipsPerId), new { Id = spaceShip.Id }, spaceShip);
            }
        }
        catch (Exception e)
        {
            return Conflict(new { Status = false, Message = "Não foi possível criar a nave, ocorreu o erro: " + e.Message });
        }
    }

    [HttpGet]
    public IEnumerable<SpaceShip> GetSpaceShips()
    {
        return _context.SpaceShips;
    }

    [HttpGet]
    [Route("verifyWitchSpaceShipCanRecieveAProblem")]
    public IActionResult VerifyWitchSpaceShipCanRecieveAProblem()
    {
        try
        {
            var shipsCanProblem = _context.SpaceShips
                .FromSqlRaw(@"select ss.Id, ss.Name, ss.SpaceShipTypeId, ss.Color, ss.Year, ss.Description, ss.Health from SpaceShips ss
                join PartsPerShips pps on(ss.Id = pps.SpaceShipId)
                join Parts p on (pps.PartId = p.Id)
                group by ss.Id, ss.Name, ss.Color, ss.SpaceShipTypeId, ss.Year, ss.Description, ss.Health")
                .ToList();

            int contadorDeNaves = shipsCanProblem.Count();
            Console.WriteLine(contadorDeNaves);

            if(contadorDeNaves == 0)
                return BadRequest(new { Status = "false", Message = "Não há naves que possam receber problemas."});
            else
                return Ok(new { Status = "true", Message = "Naves que podem receber problemas recuperadas com sucesso.",shipsCanProblem });

        }
        catch (Exception e)
        {
            return BadRequest(new { Status = "false", Message = "Erro: " + e.Message });
        }
    }


    [HttpGet("{id}")]
    public IActionResult GetSpaceShipsPerId(int id)
    {
        SpaceShip spaceShip = _context.SpaceShips.FirstOrDefault(spaceShip => spaceShip.Id == id);
        if (spaceShip != null)
        {
            ReadSpaceShipDto shipDto = _mapper.Map<ReadSpaceShipDto>(spaceShip);
            return Ok(new { spaceShip, Status = true, Message = "Nave recuperada com sucesso." });
        }
        else
        {
            return NotFound(new { Status = false, Message = "Nave não encontrada." });
        }
    }

    [HttpPut("{id}")]
    public IActionResult AttSpaceShips(int id, [FromBody] UpdateSpaceShipDto shipDto)
    {
        SpaceShip spaceShip = _context.SpaceShips.FirstOrDefault(spaceShip => spaceShip.Id == id);
        if (spaceShip == null)
        {
            return NotFound(new { Status = false, Message = "Nave não encontrada." });
        }
        try
        {
            _mapper.Map(shipDto, spaceShip);
            _context.Update(spaceShip);
            _context.SaveChanges();
            return Ok(new { spaceShip, Status = true, Message = "Nave atualizada com sucesso." });
        }
        catch (Exception e)
        {
            return Conflict(new { Status = false, Message = "Não foi possível atualizar a nave, ocorreu o erro: " + e.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DelSpaceShips(int id)
    {
        SpaceShip spaceShip = _context.SpaceShips.FirstOrDefault(spaceShip => spaceShip.Id == id);
        if (spaceShip == null)
        {
            return NotFound(new { Status = false, Message = "Nave não encontrada." });
        }
        try
        {
           foreach( PartsPerShip partPerShip in _context.PartsPerShips.Where( part => part.SpaceShipId == spaceShip.Id)){
               _context.Remove(partPerShip);
           }

            _context.Remove(spaceShip);
            _context.SaveChanges();
            return Ok(new { Status = true, Message = "Nave deletada com sucesso." });
        }
        catch (Exception e)
        {
            if(e.InnerException.Message.Contains("FK_SpaceShipProblems_SpaceShips_SpaceShipId"))
                return Conflict(new { Status = false, Message = "Não foi possível deletar a nave, pois existem problemas associados a esta nave"});

            return Conflict(new { Status = false, Message = "Não foi possível deletar a nave, ocorreu o erro: " + e.Message });
        }
    }
}