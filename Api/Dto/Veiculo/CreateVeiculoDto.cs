namespace Api.Dto;

public class CreateVeiculoDto
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public int? ClientId { get; set; } // "?" permite null
    public DateTime? DataCadastro { get; set; } = DateTime.Now;

}