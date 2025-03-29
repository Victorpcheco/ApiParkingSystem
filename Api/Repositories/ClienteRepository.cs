using Api.Data;
using Api.Dto;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _dbContext;

    public ClienteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Cliente> GetByCpfAsync(string cpf)
    {
        return await _dbContext.Tb_clientes
            .FirstOrDefaultAsync(c=> c.Cpf == cpf);
    }

    public async Task AddClienteAsync(Cliente cliente)
    {
        await  _dbContext.Tb_clientes.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
    {
        return await _dbContext.Tb_clientes.ToListAsync();
    }

    public async Task UpdateClienteAsync(Cliente cliente)
    {
        _dbContext.Update(cliente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Cliente> GetByIdAsync(int id)
    {
        return await _dbContext.Tb_clientes.FindAsync(id);
    }

    public async Task DeleteClienteAsync(int id)
    {
        _dbContext.Tb_clientes.Remove(await _dbContext.Tb_clientes.FindAsync(id));
        _dbContext.SaveChangesAsync();
    }
}