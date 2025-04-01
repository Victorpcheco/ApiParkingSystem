using Api.Models;

namespace Api.Services;

public interface IRegistroService
{
    Task<Registro> RegistrarEntradaAsync(string placaVeiculo, int usuarioId);
    Task<Registro> RegistrarSaidaAsync(string placaVeiculo);
    Task<TimeSpan> CalcularTempoPermanenciaAsync(DateTime entrada, DateTime saida);
}