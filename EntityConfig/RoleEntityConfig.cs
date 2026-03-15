using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager_Backend.Models;

public class RoleEntityConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role()
            {
                Id=1,
                Name="Admin",
                Description="Admin for Task Manager"
            }
        );
        builder.HasData(
            new Role()
            {
                Id=2,
                Name="User",
                Description="User for Task Manager"
            }
        );
    }
}