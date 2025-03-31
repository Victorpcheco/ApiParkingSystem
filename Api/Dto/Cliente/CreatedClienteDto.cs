namespace Api.Dto;

public class CreatedClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; } =  DateTime.UtcNow;
}