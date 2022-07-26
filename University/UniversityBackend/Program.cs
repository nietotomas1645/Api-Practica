//1. Agregamos using para trabajar con EF

using Microsoft.EntityFrameworkCore;
using UniversityBackend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// 2: coneccion con la base de datos sql

const string CONNECTIONNAME = "UniversityDB";

var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);


// 3. Add contexto
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.

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
