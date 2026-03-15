
using System.ComponentModel.DataAnnotations;

namespace TaskManager_Backend.DTOS;

public class RegisterRequest
{
    [Required(ErrorMessage = "UserName field is requied")]
    [MaxLength(50, ErrorMessage = "UserName length cannot exceed maximum of 50 characters")]
    [MinLength(3)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email field is requied")]
    [EmailAddress(ErrorMessage = "enter valid Email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is requied")]
    [MaxLength(256)]
    public string PasswordHash { get; set; }

    public int RoleId { get; set; }

}

public class LoginRequest{
    [Required(ErrorMessage = "Email field is requied")]

    public string Email {get; set;}
    
    [Required(ErrorMessage = "Password is requied")]

    public string Password {get; set;}
}