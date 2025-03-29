using Api.Dto;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("api/cliente")]
public class ClienteController : ControllerBase 
{
    private readonly IClienteService _service;

    public ClienteController(IClienteService service)
    {
            _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<CreatedClienteDto>> CreateCliente([FromBody] CreateClienteDto dto)
    {
        try
        {
            var cliente = await _service.CreateCliente(dto);
            return Created($"api/cliente/{cliente.Id}", cliente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet] // Get clientes
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAllClientesAsync()
    {
        try
        {
            var clientes = await _service.GetAllClientesAsync();
            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<bool> UpdateCliente(int id, [FromBody] CreateClienteDto dto)
    {
        var cliente = await _service.UpdateClienteAsync(id, dto);
        return true;
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteCliente(int id)
    {
        var  cliente = await _service.DeleteClienteAsync(id);
        return true;
    }
    
    
}