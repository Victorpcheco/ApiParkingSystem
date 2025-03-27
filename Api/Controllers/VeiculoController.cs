using Api.Dto;
using Api.Repository;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("api/veiculos")]
public class VeiculoController : ControllerBase
{
    private readonly IVeiculoService  _veiculoService;

    public VeiculoController(IVeiculoService veiculoService)
    {
      _veiculoService = veiculoService;  
    }

    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> CreateVeiculo(CreateVeiculoDto createVeiculoDto)
    {
        var veiculo = await _veiculoService.CreateVeiculoAsync(createVeiculoDto);
        
        if  (veiculo == null) {
            return BadRequest();
        }
        return Ok(veiculo);
    
    }
}