using Api.Dto;
using Api.Models;

namespace Api.Repository;

public interface IClienteRepository
{
    Task<Cliente> GetByIdAsync(int id);
    Task<Cliente> GetByCpfAsync(string cpf);
    Task AddClienteAsync(Cliente cliente);
    Task<IEnumerable<Cliente>> GetAllClientesAsync();
    Task UpdateClienteAsync(Cliente cliente);
    Task DeleteClienteAsync(int id);
}