using Api.Models;

namespace Api.Repository;

public interface IClienteRepository
{
    Task<Cliente> GetByCpfAsync(string cpf);
    Task AddClienteAsync(Cliente cliente);
}