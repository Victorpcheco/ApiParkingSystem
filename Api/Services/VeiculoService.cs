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

    public async Task<CreateVeiculoDto> CreateVeiculoAsync(CreateVeiculoDto createVeiculoDto)
    {
        var existingCar = await _veiculosRepository.GetByPlacaAsync(createVeiculoDto.Placa);
        if (existingCar != null)
        {
            throw new Exception("Carro já cadastrado no sistema!");
        }

        var veiculo = new Veiculo()
        {
            Marca = createVeiculoDto.Marca,
            Modelo = createVeiculoDto.Modelo,
            Placa = createVeiculoDto.Placa
        };

        await _veiculosRepository.AddVeiculoAsync(veiculo);

        return new CreateVeiculoDto()
        {
            Marca = veiculo.Marca,
            Modelo = veiculo.Modelo,
            Placa = veiculo.Placa
        }; 

    }
    
    
}