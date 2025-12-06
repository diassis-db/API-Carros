using APICarros.Data;
using APICarros.Domain.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  --> ConfigureServices()

var connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

builder.Services.AddDbContext<MySqlContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CarroValidation>();

var app = builder.Build();     //Configure()

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();  //Middleware pipeline to handle authorization

app.MapControllers();
//app.MapGet("/",() => Results.Redirect("api/v1/carro")); //Redireciona para o controller de Carro.

app.Run();
