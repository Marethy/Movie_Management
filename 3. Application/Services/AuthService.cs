using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1._3._Application.DTOs;
using WebApplication1._3._Application.Interfaces.Services;
using WebApplication1.Application.DTOs;
using WebApplication1.Domain.Entities;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<string> RegisterAsync(RegisterDTO registerDto)
    {
        var user = new User
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            FullName = registerDto.FullName // Gán giá trị FullName
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
            return "User registered successfully!";
        }

        throw new Exception("Registration failed");
    }

    public async Task<string> LoginAsync(LoginDTO loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user == null) throw new Exception("User not found");

        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
        if (result.Succeeded)
        {
            var token = await GenerateJwtTokenAsync(user.UserName);
            return token;
        }

        throw new Exception("Invalid login attempt");
    }

    public async Task<string> GenerateJwtTokenAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            // Thêm các claim khác nếu cần (role, quyền, v.v.)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
