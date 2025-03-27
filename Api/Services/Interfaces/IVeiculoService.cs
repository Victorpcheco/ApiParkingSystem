using Api.Dto;
using Api.Models;

namespace Api.Services;

public interface IVeiculoService
{
    Task<CreateVeiculoDto>  CreateVeiculoAsync(CreateVeiculoDto createVeiculoDto);
    
}