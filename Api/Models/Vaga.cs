using System.ComponentModel.DataAnnotations;
using Api.Enums;

namespace Api.Models;

public class Vaga
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string IdentificacaoVaga { get; set; }
    [Required]
    public VagaTipoEnum Tipo { get; set; } // Moto ou Carro
    public bool Ocupado { get; set; } =  false;
}