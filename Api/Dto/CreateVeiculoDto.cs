namespace Api.Dto;

public class CreateVeiculoDto
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public int? ClientId { get; set; } // "?" permite null

}