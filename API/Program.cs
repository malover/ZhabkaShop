using Application.DTO;
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

app.MapGet("/products/", async (IUnitOfWork unitOfWork) => await unitOfWork.ProductRepository.GetAllAsync());

app.MapGet("/products/{id}", async (int id, IUnitOfWork unitOfWork) => await unitOfWork.ProductRepository.GetProductByIdAsync(id));

app.MapPost("/products/", async (ProductDto product, IUnitOfWork unitOfWork) =>
{
    await unitOfWork.ProductRepository.AddProductAsync(product);
    await unitOfWork.SaveAsync();
    return Results.Ok();
});

app.MapPut("/products/{id}", async (ProductDto product, IUnitOfWork unitOfWork) =>
{
    await unitOfWork.ProductRepository.UpdateProductAsync(product);
    await unitOfWork.SaveAsync();
    return Results.Ok();
});

app.MapDelete("/products/{id}", async (int id, IUnitOfWork unitOfWork) =>
{
    await unitOfWork.ProductRepository.DeleteProductAsync(id);
    await unitOfWork.SaveAsync();
    return Results.Ok();
});

app.MapGet("/orders/", async (IUnitOfWork unitOfWork) => await unitOfWork.OrderRepository.GetAllAsync());

app.MapPost("/orders/", async (OrderDto order, IUnitOfWork unitOfWork) =>
{
    await unitOfWork.OrderRepository.AddOrderAsync(order);
    await unitOfWork.SaveAsync();
    return Results.Ok();
});

app.MapPut("/orders/fulfill", async (int id, IUnitOfWork unitOfWork) =>
{
    try
    {
        await unitOfWork.OrderRepository.FulfillOrderAsync(id);
        await unitOfWork.SaveAsync();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.StatusCode(500);
    }
});

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
