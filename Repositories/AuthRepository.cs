using Microsoft.EntityFrameworkCore;
using TaskManager_Backend.Data;
using TaskManager_Backend.DTOS;
using TaskManager_Backend.Interfaces;
using TaskManager_Backend.Models;

namespace TaskManager_Backend.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _dbcontext;
    public AuthRepository(AppDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public async Task<User> Login(LoginRequest req)
    {
        var userDetails = await _dbcontext.Users.FirstOrDefaultAsync<User>(u => u.Email == req.Email);
        if (userDetails == null)
        {
            return null;
        }
        var isValidDetails = BCrypt.Net.BCrypt.Verify(req.Password, userDetails.PasswordHash);

        if (isValidDetails)
        {
            return userDetails;
        }
        return null;

    }

    public async Task<bool> Register(RegisterRequest user)
    {
        var PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        await _dbcontext.Users.AddAsync(new User
        {
            UserName = user.UserName,
            RoleId = user.RoleId,
            PasswordHash = PasswordHash,
            Email = user.Email,
        });
        await _dbcontext.SaveChangesAsync();
        return true;
    }
}