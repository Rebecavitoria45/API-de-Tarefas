using System.Data.Common;
using ApiTarefas.Database;
using ApiTarefas.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

 var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TarefasContext>(options => 
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35))) // Especifique a versão do seu servidor MySQL aqui.
);
// Add services to the container.
builder.Services.AddScoped<TarefaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
