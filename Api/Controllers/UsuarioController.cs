using System.Security.Claims;
using Api.Dto;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;




[ApiController]
[Route("api/usuario")]
[Authorize]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpGet] // get users
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetAll()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }
    
    [HttpGet("{id}")] // get byYd
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UsuarioResponseDto>> GetById(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost] // create user 
    [Authorize(Roles = "Admin")] 
    public async Task<ActionResult<UsuarioResponseDto>> Create(CreateUsuarioRequestDto createUsuarioRequestDto)
    {
        try
        {
            var usuario = await _usuarioService.CreateUsuarioAsync(createUsuarioRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPut("{id}")] // update users
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, CreateUsuarioRequestDto createUsuarioRequestDto)
    {
        var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value;
        var result = await _usuarioService.UpdateUsuarioAsync(id, createUsuarioRequestDto);
        if (!result) return NotFound();
        return NoContent();
    }
    
    [HttpDelete("{id}")] // delete users
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _usuarioService.DeleteUsuarioAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpPatch("{id}/mudar-status")] // alter status users 
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        var result = await _usuarioService.ToggleUsuarioStatusAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
    
    
    
}