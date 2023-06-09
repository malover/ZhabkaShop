using Persistence.ServiceExtensions;
using Application.Interfaces;
using Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDbProvider(builder.Configuration);
builder.Services.RegisterRepositories();

var app = builder.Build();

#region MinimalApi

app.MapGet("/products/", async (IUnitOfWork unitOfWork) =>
{
    await unitOfWork.ProductRepository.GetAllAsync();
    return Results.Ok();
});

app.MapGet("/products/{id}", async (int id, IUnitOfWork unitOfWork) =>
{
    await unitOfWork.ProductRepository.GetProductByIdAsync(id);
    return Results.Ok();
});

app.MapPost("/products/", async (Product product, IUnitOfWork unitOfWork) =>
{
    await unitOfWork.ProductRepository.AddProductAsync(product);
    await unitOfWork.SaveAsync();
    return Results.Ok();
});

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
