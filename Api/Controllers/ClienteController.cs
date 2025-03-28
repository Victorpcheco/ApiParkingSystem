using Api.Dto;
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
    
}