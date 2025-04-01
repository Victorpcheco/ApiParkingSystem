using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class RegistroRepository : IRegistroRepository
{
    private readonly AppDbContext _context;

    public RegistroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Registro> GetByIdAsync(int id)
    {
        return await _context.Tb_registros.FindAsync(id);
    }

    public async Task<IEnumerable<Registro>> GetAllAsync()
    {
        return await _context.Tb_registros.ToListAsync();
    }

    public async Task<Registro> GetRegistroAbertoPorPlacaAsync(string placaVeiculo)
    {
        return await _context.Tb_registros
            .FirstOrDefaultAsync(r => r.PlacaVeiculo == placaVeiculo && r.DataSaida == null);
    }

    public async Task AddAsync(Registro registro)
    {
        await _context.Tb_registros.AddAsync(registro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Registro registro)
    {
        _context.Tb_registros.Update(registro);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsRegistroAbertoAsync(string placaVeiculo)
    {
        return await _context.Tb_registros
            .AnyAsync(r => r.PlacaVeiculo == placaVeiculo && r.DataSaida == null);
    }
}
