using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManager_Backend.Data;

var builder = WebApplication.CreateBuilder(args);
// register services

builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration["ConnectionString"], 
        new MySqlServerVersion(new Version(8, 0, 35)))
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Manager API", Version = "v1" });
});


var app = builder.Build();

// handle request pipeline register middlewares , mapcontrollers, routing pipeline, authentication etc
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
