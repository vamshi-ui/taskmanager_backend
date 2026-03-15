using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManager_Backend.Models;
using TaskManager_Backend.Interfaces;

namespace TaskManager_Backend.Services;

public class JwtService : IJwtService
{
private readonly IConfiguration _config;
public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("RoleId", user.RoleId.ToString())
    };


        var key = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(_config["Jwt:Secret"])
);

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "TaskManagerAPI",
            audience: "TaskManagerClient",
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}