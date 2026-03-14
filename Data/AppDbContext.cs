using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.TaskModels;
using TaskManager.UserModels;

namespace TaskManager_Backend.Data;

public class AppDbContext: DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

      // modelBuilder.Entity<Role>().HasData(new Role
      // {
      //    Name = "Admin",
      //    Id=1
      // });
   }

    public DbSet<User> Users {get; set;}
    public DbSet<Role> UserRoles {get; set;}
    public DbSet<TaskItem> Tasks {get; set;}
    
}
