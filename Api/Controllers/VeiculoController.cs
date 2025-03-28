using Api.Dto;
using Api.Models;
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
    public async Task<ActionResult<CreateVeiculoDto>> CreateVeiculo(CreateVeiculoDto dto)
    {
        try
        {
            var veiculo = await _veiculoService.CreateVeiculoAsync(dto);
            return CreatedAtAction(nameof(CreateVeiculo), new { id = veiculo.Id }, veiculo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CreateVeiculoDto>> GetVeiculoByIdAsync(int id)
    {
        try
        {
            var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
            return Ok(veiculo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CreateVeiculoDto>>> GetAll()
    {
        var veiculos = await _veiculoService.GetVeiculosAsync();
        return Ok(veiculos);
            
    }

    [HttpPut("{id}")]
    public async Task<bool> UpdateVeiculoAsync(int id, CreateVeiculoDto dto)
    {
            var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
            await _veiculoService.UpdateVeiculoAsync(id, dto);
            return true;
    }


    [HttpDelete("{id}")]
    public async Task<bool> DeleteVeiculoAsync(int id)
    {
        var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
        await _veiculoService.DeleteVeiculoAsync(id);
        return true;    
        
    }
}