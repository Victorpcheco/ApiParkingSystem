using Api.Enums;

namespace Api.Dto;

public class LoginResponseDto
{
    public string Token { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public UsuarioRoleEnum Role { get; set; }
}