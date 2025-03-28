using Api.Data;
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
    
    
}