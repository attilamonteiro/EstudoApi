using EstudoApi.Domain.Configuration;
using EstudoApi.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureInfrastructureDependencies();
builder.Services.ConfigureDomainDependencies();
builder.Services.ConfigureAutoMapperependencies();

builder.Services.AddConnections(builder.Configuration);

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
