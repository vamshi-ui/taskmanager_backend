using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.TaskModels;

namespace TaskManager.UserModels;

[Table("tb_users")]
public class User
{
    public int UserId { get; set; }
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
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public int RoleId { get; set; }

    public Role? UserRole { get; set; }

    public ICollection<TaskItem>? userTasks { get; set; }

    public User()
    {
        CreatedAt = DateTime.Now;
    }
}

[Table("tb_user_roles")]

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
}