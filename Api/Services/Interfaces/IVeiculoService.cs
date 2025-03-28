using Api.Dto;
using Api.Models;

namespace Api.Services;

public interface IVeiculoService
{
    Task<CreatedVeiculoDto> CreateVeiculoAsync(CreateVeiculoDto dto);
    Task<CreateVeiculoDto> GetVeiculoByIdAsync(int id);
    Task<IEnumerable<Veiculo>> GetVeiculosAsync();
    Task<bool> UpdateVeiculoAsync(int id, CreateVeiculoDto dto);
    Task<bool> DeleteVeiculoAsync(int id);
    
}