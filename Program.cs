using Microsoft.OpenApi.Models;
using SlaTracker_Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SlaTracker-Core API",
        Version = "v1",
        Description = "API RESTful para motor de evaluacion de SLAs"
    });
});

builder.Services.AddScoped<ISlaService, SlaService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SlaTracker-Core v1");
    c.RoutePrefix = "swagger";
});

app.UseAuthorization();
app.MapControllers();

app.Run();
