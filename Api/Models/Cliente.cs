using System.ComponentModel.DataAnnotations;
using Api.Enums;

namespace Api.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Cpf { get; set; }
    [Required]
    public string Telefone { get; set; }
    [Required]
    public ClienteTipoEnum Tipo { get; set; } // Avulso ou Mensalista
    public DateTime? DataCadastro { get; set; } =  DateTime.Now;
}