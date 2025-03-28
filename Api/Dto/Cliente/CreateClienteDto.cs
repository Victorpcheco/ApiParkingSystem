using Api.Enums;

namespace Api.Dto;

public class CreateClienteDto
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public ClienteTipoEnum Tipo { get; set; } // Avulso ou Mensalista
}