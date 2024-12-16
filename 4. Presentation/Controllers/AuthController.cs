using Microsoft.AspNetCore.Mvc;
using WebApplication1._3._Application.DTOs;
using WebApplication1._3._Application.Interfaces.Services;
using WebApplication1.Application.DTOs;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDto)
    {
        var token = await _authService.LoginAsync(loginDto);
        return Ok(new { Token = token });
    }
}
