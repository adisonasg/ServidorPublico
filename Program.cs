using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using ServidorPublico.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// SQLite - banco persistente
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=servidores.db"));

// MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// FluentValidation (versão 11+)
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation(); // Adiciona validação automática
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Registra validadores

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Servidores API", Version = "v1" });
});

var app = builder.Build();

// Migrate database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();


