using System.ComponentModel.DataAnnotations;
using Api.Enums;

namespace Api.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Matricula { get; set; }
    [Required]
    public string Senha { get; set; }
    [Required]
    public UsuarioRoleEnum Role { get; set; } // Admin ou User
    public bool Ativo { get; set; } =  true; // Ao cadastrar inicia como ativo
    
}