using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Api.Models;

public class Registro
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string PlacaVeiculo { get; set; }
    
    [Required] 
    public int UsuarioId { get; set; }
    
    [Required]
    public DateTime DataEntrada { get; set; } = DateTime.UtcNow;
    
    public DateTime? DataSaida { get; set; }

    public TimeSpan TempoDePermanencia { get; set; }
    
    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; }
}