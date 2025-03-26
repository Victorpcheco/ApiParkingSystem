using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Registro
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int VeiculoId { get; set; }
    [Required]
    public int VagaId { get; set; }
    [Required] 
    public int UsuarioId { get; set; }
    [Required]
    public DateTime DataEntrada { get; set; } = DateTime.Now;
    public DateTime DataSaida { get; set; } 
    public string TempoPermanencia { get; set; }
    public decimal ValorTotal { get; set; } // Valor cobrado pelo estacionamento 
    
    [ForeignKey("VeiculoId")]
    public Veiculo Veiculo { get; set; }
    
    [ForeignKey("VagaId")]
    public Vaga Vaga { get; set; }
    
    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; }
    
    
}