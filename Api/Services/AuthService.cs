using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Dto;
using Api.Models;
using Api.Repository;
using Api.Utils;
using Microsoft.IdentityModel.Tokens;


namespace Api.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var usuario = await _usuarioRepository.GetByMatriculaAsync(loginRequestDto.Matricula);

        if (usuario == null || !PasswordHasher.VerifyHashedPassword(loginRequestDto.Senha, usuario.Senha))
        {
            throw new UnauthorizedAccessException("Matrícula ou senha inválidos");
        }

        if (!usuario.Ativo)
        {
            throw new UnauthorizedAccessException("Usuário inativo");
        }

        var token = GenerateJwtToken(usuario);

        return new LoginResponseDto
        {
            Token = token,
            Nome = usuario.Nome,
            Matricula = usuario.Matricula,
            Role = usuario.Role
        };
    }
    
    private string GenerateJwtToken(Usuario usuario)
    {
        // Obter a chave secreta do JWT
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
    
        // Criar as credenciais de assinatura
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Matricula),
                new Claim(ClaimTypes.Role, usuario.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = signingCredentials, 
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
