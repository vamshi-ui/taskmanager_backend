using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager_Backend.Models;

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed
}

public enum TaskPriority
{
    High,
    Medium,
    Low
}

[Table("tb_tasks")]
public class TaskItem
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }

    public User? User { get; set; }

    public TaskItem()
    {
        CreatedAt = DateTime.Now;
    }
}