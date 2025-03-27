using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Tb_usuarios.FindAsync(id);
    }
    
    public async Task<Usuario> GetByMatriculaAsync(string matricula)
    {
        return await _context.Tb_usuarios.FirstOrDefaultAsync(u => u.Matricula == matricula);
    }
    
    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Tb_usuarios.ToListAsync();
    }
    
    public async Task AddAsync(Usuario usuario)
    {
        await _context.Tb_usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Tb_usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Usuario usuario)
    {
        _context.Tb_usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        
    }
    
}