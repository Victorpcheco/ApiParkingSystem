using Api.Dto;

namespace Api.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioResponseDto>> GetAllUsuariosAsync();
    Task<UsuarioResponseDto> GetUsuarioByIdAsync(int id);
    Task<UsuarioResponseDto> CreateUsuarioAsync(CreateUsuarioRequestDto createUsuarioRequest);
    Task<bool> UpdateUsuarioAsync(int id, CreateUsuarioRequestDto updateUsuarioRequest);
    Task<bool> DeleteUsuarioAsync(int id);
    Task<bool> ToggleUsuarioStatusAsync(int id);
}