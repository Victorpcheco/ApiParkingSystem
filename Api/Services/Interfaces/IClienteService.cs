using Api.Dto;
using Api.Models;

namespace Api.Services;

public interface IClienteService 
{
    Task<CreatedClienteDto>  CreateCliente(CreateClienteDto dto);
}