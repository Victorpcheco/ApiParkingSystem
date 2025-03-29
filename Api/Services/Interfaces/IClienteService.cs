using Api.Dto;
using Api.Models;

namespace Api.Services;

public interface IClienteService 
{
    Task<CreatedClienteDto>  CreateCliente(CreateClienteDto dto);
    Task<IEnumerable<Cliente>> GetAllClientesAsync();
    Task<bool> UpdateClienteAsync(int id, CreateClienteDto dto);
    Task<bool> DeleteClienteAsync(int id);
}