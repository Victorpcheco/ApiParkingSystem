using Api.Dto;
using Api.Models;
using Api.Repository;

namespace Api.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository  _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreatedClienteDto> CreateCliente(CreateClienteDto dto)
    {
        var exintingCliente = await _repository.GetByCpfAsync(dto.Cpf);

        if (exintingCliente != null)
        {
            throw new Exception("Cpf já cadastrado no sistema!");
        }

        var cliente = new Cliente()
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Telefone = dto.Telefone,
            Tipo = dto.Tipo
        }; 
        
        await _repository.AddClienteAsync(cliente);

        return new CreatedClienteDto()
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            DataCadastro = DateTime.Now
        };
    }
    
}