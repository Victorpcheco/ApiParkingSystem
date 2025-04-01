using Api.Models;

namespace Api.Repository;

public interface IRegistroRepository
{
    Task<Registro> GetByIdAsync(int id);
    Task<IEnumerable<Registro>> GetAllAsync();
    Task<Registro> GetRegistroAbertoPorPlacaAsync(string placaVeiculo);
    Task AddAsync(Registro registro);
    Task UpdateAsync(Registro registro);
    Task<bool> ExistsRegistroAbertoAsync(string placaVeiculo);
}