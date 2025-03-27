using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Cliente> Tb_clientes { get; set; }
    public DbSet<Registro> Tb_registros { get; set; }
    public DbSet<Usuario> Tb_usuarios { get; set; }
    public DbSet<Vaga> Tb_vagas { get; set; }
    public DbSet<Veiculo> Tb_veiculos { get; set; }


    // configuração adicional das relações entre as tabelas configuradas na model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Veiculo>()
            .HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict); // Impede a exclusão caso o Veiculo esteja associado ao Cliente. 
        
        
        modelBuilder.Entity<Registro>()
            .HasOne(r => r.Veiculo)
            .WithMany()
            .HasForeignKey(r => r.VeiculoId)
            .OnDelete(DeleteBehavior.Cascade); // Delete em cascata. 

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Role)
            .HasConversion<string>();
    }
    
}