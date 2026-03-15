using TaskManager_Backend.Models;

namespace TaskManager_Backend.Interfaces;
public interface IJwtService
{
    public string GenerateToken(User user);
}