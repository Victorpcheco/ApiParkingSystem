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


    public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
    {
        return await _repository.GetAllClientesAsync();
    }

    public async Task<bool> UpdateClienteAsync(int id, CreateClienteDto dto)
    {
        var existingCliente = await _repository.GetByIdAsync(id);
        if (existingCliente == null)
        {
            throw new Exception("Cliente não cadastrado!");
        }
        
        existingCliente.Nome = dto.Nome;
        existingCliente.Cpf = dto.Cpf;
        existingCliente.Telefone = dto.Telefone;
        existingCliente.Tipo = dto.Tipo;
        
        await _repository.UpdateClienteAsync(existingCliente);
        return true;
    }


    public async Task<bool> DeleteClienteAsync(int id)
    {
        var existingCliente = await _repository.GetByIdAsync(id);
        if (existingCliente == null)
        {
            throw new Exception("Cliente não cadastrado!");
        }
        
        await _repository.DeleteClienteAsync(id);
        return true;
    }
}