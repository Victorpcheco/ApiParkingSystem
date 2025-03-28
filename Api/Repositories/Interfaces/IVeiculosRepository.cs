using Api.Dto;
using Api.Models;

namespace Api.Repository;

public interface IVeiculosRepository
{
    Task AddVeiculoAsync(Veiculo veiculo);
    Task <Veiculo> GetByPlacaAsync(string placa);
    Task<Veiculo> GetVeiculoById(int id);
    Task<IEnumerable<Veiculo>> GetVeiculosAsync();
    Task UpdateVeiculoAsync(Veiculo veiculo);
    Task DeleteVeiculoAsync(Veiculo veiculo);
}