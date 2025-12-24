using APICarros.Data.Context;
using APICarros.Data.Dependencies;
using APICarros.Domain.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  --> ConfigureServices()

var connectionString = builder.Configuration.GetConnectionString("MySql");

// Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

//DB Context
builder.Services.AddDbContext<MySqlContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CarroValidation>();

//Dependency Injection
builder.Services.AddApplicationDependencies();

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

app.Run();
