using Api.Models;

namespace Api.Repository;

public interface IUsuarioRepository
{
    Task<Usuario> GetByIdAsync(int id);
    Task<Usuario> GetByMatriculaAsync(string matricula);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(Usuario usuario);
}