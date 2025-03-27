using Api.Dto;
using Api.Models;

namespace Api.Repository;

public interface IVeiculosRepository
{
    Task AddVeiculoAsync(Veiculo veiculo);
    Task <Veiculo> GetByPlacaAsync(string placa);
}