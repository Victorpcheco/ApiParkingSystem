using Api.Dto;
using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Services;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculosRepository  _veiculosRepository;


    public VeiculoService(IVeiculosRepository veiculosRepository)
    {
        _veiculosRepository = veiculosRepository;
    }

    public async Task<CreatedVeiculoDto> CreateVeiculoAsync(CreateVeiculoDto dto)
    {
        var existingCar = await _veiculosRepository.GetByPlacaAsync(dto.Placa);
        if (existingCar != null)
        {
            throw new Exception("Carro já cadastrado no sistema!");
        }

        var veiculo = new Veiculo()
        {
            Modelo = dto.Modelo,
            Placa = dto.Placa
        };

        await _veiculosRepository.AddVeiculoAsync(veiculo);

        return new CreatedVeiculoDto()
        {
            Placa = veiculo.Placa,
            Id = veiculo.Id,
            DataCadastro = veiculo.DataCadastro,
        }; 

    }

    public async Task<CreateVeiculoDto> GetVeiculoByIdAsync(int id)
    {
        var veiculo = await _veiculosRepository.GetVeiculoById(id);
        if (veiculo == null)
        {
            throw new Exception("Veiculo não encontrado!");
        }
        return new CreateVeiculoDto()
        {
            Id = veiculo.Id,
            Placa = veiculo.Placa,
            Modelo = veiculo.Modelo,
            ClientId = veiculo.ClienteId,
            DataCadastro = veiculo.DataCadastro
        };

    }

    public async Task<IEnumerable<Veiculo>> GetVeiculosAsync()
    {
        var veiculos = await _veiculosRepository.GetVeiculosAsync();
        if (veiculos == null)
        {
            throw new Exception("Nenhum veículo cadastrado!");
        }
        return veiculos;
    }


    public async Task<bool> UpdateVeiculoAsync(int id, CreateVeiculoDto dto)
    {
        var existingVeiculo = await _veiculosRepository.GetVeiculoById(id);
        if (existingVeiculo == null)
        {
            throw new Exception("Veículo não cadastrado!");
        }
        
        existingVeiculo.Placa = dto.Placa;
        existingVeiculo.Modelo = dto.Modelo;
        
        await _veiculosRepository.UpdateVeiculoAsync(existingVeiculo);
        return true;
    }

    public async Task<bool> DeleteVeiculoAsync(int id)
    {
        var existingVeiculo = await _veiculosRepository.GetVeiculoById(id);
        if (existingVeiculo == null)
        {
            throw new Exception("Veículo não cadastrado!");
        }
        
        await _veiculosRepository.DeleteVeiculoAsync(existingVeiculo);
        return true;
    }
}