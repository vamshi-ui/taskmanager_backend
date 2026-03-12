using System;
using Microsoft.EntityFrameworkCore;
using TaskManager_Backend.Models;

namespace TaskManager_Backend.Data;

public class AppDbContext: DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

 public DbSet<TaskItem> Tasks { get; set; }
}
