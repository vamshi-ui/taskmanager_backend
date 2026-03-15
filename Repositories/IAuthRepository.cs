using TaskManager_Backend.DTOS;
using TaskManager_Backend.Models;

namespace TaskManager_Backend.Interfaces;

public interface IAuthRepository
{
    public Task<bool> Register(RegisterRequest user);
    public Task<User> Login(LoginRequest req);
}