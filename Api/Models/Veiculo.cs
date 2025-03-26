using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Veiculo
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Marca { get; set; }
    [Required]
    public string Modelo { get; set; }
    [Required]
    public string Placa { get; set; }
    [Required]
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Cliente Cliente { get; set; }
    
}