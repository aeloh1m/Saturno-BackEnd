using Microsoft.AspNetCore.Mvc;
using SATURNO_V2.Services;
using SATURNO_V2.Data.SaturnoModels;
using SATURNO_V2.Data.DTOs;

namespace SATURNO_V2.Controllers;

[ApiController]
[Route("[controller]")]

public class ServicioController : ControllerBase
{
    private readonly ServicioService _service;
    public ServicioController(ServicioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Servicio>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("cuted/{n}")]
    public async Task<IEnumerable<Servicio>> GetFour(int n)
    {
        return await _service.GetFour(n);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Servicio>> GetById(int id)
    {
        var servicio = await _service.GetById(id);
       
        if (servicio is not null) 
        { 
            return servicio; 
        }
        else
        { 
            return NotFound();
        }

    }

    [HttpPost]
    public async Task<IActionResult> Create(Servicio servicio)
    {
        var servicioNuevo = await _service.Create(servicio);

        if (servicioNuevo is not null )
        {
            return CreatedAtAction(nameof(GetById), new {id = servicioNuevo.Id}, servicioNuevo);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Servicio servicio)
    {
        if (id != servicio.Id){
            return BadRequest();
        }

        await _service.Update(id, servicio);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var servicioDelete = await _service.GetById(id);

        if (servicioDelete is not null )
        {
            await _service.Delete(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}
