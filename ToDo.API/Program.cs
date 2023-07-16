using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Context;
using ToDo.Infra.Repositories;

;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string strConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ToDoContext>(option =>
{
    option.UseSqlServer(strConnection);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();


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
