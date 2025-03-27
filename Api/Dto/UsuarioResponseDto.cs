using Api.Enums;

namespace Api.Dto;

public class UsuarioResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public UsuarioRoleEnum Role { get; set; }
    public bool Ativo { get; set; }
}