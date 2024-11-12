using EstudoApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=ProductsDb.db")
           .EnableSensitiveDataLogging() 
           .LogTo(Console.WriteLine, LogLevel.Information)); 


var app = builder.Build();

// Configuração do Swagger e dos Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
