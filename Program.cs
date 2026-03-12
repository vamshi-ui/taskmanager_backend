using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// register services
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
