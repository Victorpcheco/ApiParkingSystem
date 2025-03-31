using Api.Data;
using Api.Dto;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class VeiculoRepository :  IVeiculosRepository
{
    private readonly AppDbContext _context;
    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddVeiculoAsync(Veiculo veiculo)
    {

        await _context.Tb_veiculos.AddAsync(veiculo);
        await _context.SaveChangesAsync();
        
    }

    public async Task<Veiculo> GetByPlacaAsync(string placa)
    {
        return await _context.Tb_veiculos
            .FirstOrDefaultAsync(v => v.Placa == placa);
    }

    public async Task<Veiculo> GetVeiculoById(int id)
    {
        return await _context.Tb_veiculos.FindAsync(id);
        
    }

    public async Task<IEnumerable<Veiculo>> GetVeiculosAsync()
    {
        return await _context.Tb_veiculos.ToListAsync();
    }

    public async Task UpdateVeiculoAsync(Veiculo veiculo)
    {
         _context.Tb_veiculos.Update(veiculo);
         await _context.SaveChangesAsync();
    }

    public async Task DeleteVeiculoAsync(Veiculo veiculo)
    {
        _context.Tb_veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();
    }
    
}