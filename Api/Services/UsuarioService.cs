using Api.Dto;
using Api.Models;
using Api.Repository;
using Api.Utils;

namespace Api.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<UsuarioResponseDto>> GetAllUsuariosAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return usuarios.Select(u => new UsuarioResponseDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Matricula = u.Matricula,
            Role = u.Role,
            Ativo = u.Ativo
        });
    }

    public async Task<UsuarioResponseDto> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null) return null;
        
        
        return new UsuarioResponseDto()
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Matricula = usuario.Matricula,
            Role = usuario.Role,
            Ativo = usuario.Ativo
        };
    }

    public async Task<UsuarioResponseDto> CreateUsuarioAsync(CreateUsuarioRequestDto createUsuarioRequestDto)
    {
        var existingUser = await _usuarioRepository.GetByMatriculaAsync(createUsuarioRequestDto.Matricula);
        if (existingUser != null)
        {
            throw new Exception("Matrícula já cadastrada");
        }

        var usuario = new Usuario
        {
            Nome = createUsuarioRequestDto.Nome,
            Matricula = createUsuarioRequestDto.Matricula,
            Senha = PasswordHasher.HashPassword(createUsuarioRequestDto.Senha),
            Role = createUsuarioRequestDto.Role,
            Ativo = true
        };
         
        await _usuarioRepository.AddAsync(usuario);

        return new UsuarioResponseDto()
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Matricula = usuario.Matricula,
            Role = usuario.Role,
            Ativo = usuario.Ativo
        };
    }

    public async Task<bool> UpdateUsuarioAsync(int id, CreateUsuarioRequestDto updateUsuarioRequest)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null) return false;

        usuario.Nome = updateUsuarioRequest.Nome;
        usuario.Matricula = updateUsuarioRequest.Matricula;
        usuario.Role = updateUsuarioRequest.Role;
            
        if (!string.IsNullOrEmpty(updateUsuarioRequest.Senha))
        {
            usuario.Senha = PasswordHasher.HashPassword(updateUsuarioRequest.Senha);
        }

        await _usuarioRepository.UpdateAsync(usuario);
        return true;
    }

    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null) return false;

        await _usuarioRepository.DeleteAsync(usuario);
        return true;
    }
    
    public async Task<bool> ToggleUsuarioStatusAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null) return false;

        usuario.Ativo = !usuario.Ativo;
        await _usuarioRepository.UpdateAsync(usuario);
        return true;
    }
    
}
