using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Ports.Secondary;
using FluentValidation;
using MapperComponent.Mappers;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent;
using RepositoryComponent.Models;
using RepositoryComponent.Repositories;
using ValidationComponent.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add context
builder.Services.AddDbContext<BirdSightsDBContext>(context =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerDev"));
});

// Add mappers
builder.Services.AddScoped<IMapper<Bird, BirdModel>, BirdModelMapper>();
builder.Services.AddScoped<IMapper<BirdModel, Bird>, BirdMapper>();
builder.Services.AddScoped<IMapper<BirdSight, BirdSightModel>, BirdSightModelMapper>();
builder.Services.AddScoped<IMapper<BirdSightModel, BirdSight>, BirdSightMapper>();

// Add validators
builder.Services.AddScoped<IValidator<Bird>, BirdCreateValidator>();
builder.Services.AddScoped<IValidator<Tuple<int, Bird>>, BirdUpdateValidator>();
builder.Services.AddScoped<IValidator<BirdSight>, BirdSightCreateValidator>();
builder.Services.AddScoped<IValidator<Tuple<int, BirdSight>>, BirdSightUpdateValidator>();

// Add services
builder.Services.AddScoped<IService<Bird>, BirdService>();
builder.Services.AddScoped<IService<BirdSight>, BirdSightService>();

// Add repositories
builder.Services.AddScoped<IRepository<Bird>, BirdRepository>();
builder.Services.AddScoped<IRepository<BirdSight>, BirdSightRepository>();

// Add swagger
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
