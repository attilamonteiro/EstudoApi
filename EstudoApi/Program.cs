using EstudoApi.Domain.Configuration;
using EstudoApi.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using EstudoApi.Infrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.ConfigureInfrastructureDependencies();
builder.Services.ConfigureDomainDependencies();

builder.Services.AddConnections();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
