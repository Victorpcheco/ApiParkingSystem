using Api.Dto.Registro;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/registros")]
public class RegistroController : ControllerBase
{
    
    private readonly IRegistroService _registroService;

    public RegistroController(IRegistroService registroService)
    {
        _registroService = registroService;
    }

    [HttpPost("entrada")]
    public async Task<ActionResult<Registro>> RegistrarEntrada([FromBody] EntradaRequest request)
    {
        try
        {
            var registro = await _registroService.RegistrarEntradaAsync(request.PlacaVeiculo, request.UsuarioId);
            return Ok(registro);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = $"Erro ao registrar entrada: {ex.Message}" });
        }
    }

    [HttpPost("saida")]
    public async Task<ActionResult<Registro>> RegistrarSaida([FromBody] SaidaRequest request)
    {
        try
        {
            var registro = await _registroService.RegistrarSaidaAsync(request.PlacaVeiculo);
            return Ok(registro);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = $"Erro ao registrar saída: {ex.Message}" });
        }
    }
}

