using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Api.Models;

public class Registro
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int VeiculoId { get; set; }
    
    [Required] 
    public int UsuarioId { get; set; }
    
    [Required]
    public DateTime DataEntrada { get; set; } = DateTime.UtcNow;
    
    public DateTime? DataSaida { get; set; } 
    
    [NotMapped] // Não será persistido no banco
    public TimeSpan? TempoPermanencia => 
        DataSaida.HasValue ? DataSaida - DataEntrada : null;
    
    [ForeignKey("VeiculoId")]
    public Veiculo Veiculo { get; set; }
    
    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; }
}