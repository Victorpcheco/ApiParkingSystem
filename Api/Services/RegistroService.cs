using Api.Models;
using Api.Repository;

namespace Api.Services;

public class RegistroService : IRegistroService

{
    private readonly IRegistroRepository _registroRepository;

    public RegistroService(IRegistroRepository registroRepository)
    {
        _registroRepository = registroRepository;
    }

    public async Task<Registro> RegistrarEntradaAsync(string placaVeiculo, int usuarioId)
    {
        if (await _registroRepository.ExistsRegistroAbertoAsync(placaVeiculo))
        {
            throw new InvalidOperationException("Já existe um registro aberto para este veículo.");
        }

        var novoRegistro = new Registro
        {
            PlacaVeiculo = placaVeiculo,
            UsuarioId = usuarioId,
            DataEntrada = DateTime.UtcNow
        };

        await _registroRepository.AddAsync(novoRegistro);
        return novoRegistro;
    }

    public async Task<Registro> RegistrarSaidaAsync(string placaVeiculo)
    {
        var registro = await _registroRepository.GetRegistroAbertoPorPlacaAsync(placaVeiculo);

        if (registro == null)
        {
            throw new KeyNotFoundException("Não foi encontrado um registro aberto para esta placa.");
        }

        registro.DataSaida = DateTime.UtcNow;
        registro.TempoDePermanencia = await CalcularTempoPermanenciaAsync(
            registro.DataEntrada, registro.DataSaida.Value);

        await _registroRepository.UpdateAsync(registro);
        return registro;
    }

    public async Task<TimeSpan> CalcularTempoPermanenciaAsync(DateTime entrada, DateTime saida)
    {
        return await Task.FromResult(saida - entrada);
    }
}
