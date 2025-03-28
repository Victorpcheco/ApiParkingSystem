namespace Api.Dto;

public class CreatedVeiculoDto
{
    public int Id { get; set; }
    public string Placa  { get; set; }
    public DateTime? DataCadastro { get; set; } =  DateTime.Now;
}