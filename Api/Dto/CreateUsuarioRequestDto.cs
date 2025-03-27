using Api.Enums;

namespace Api.Dto;

public class CreateUsuarioRequestDto
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Senha { get; set; }
    public UsuarioRoleEnum Role { get; set; }
}