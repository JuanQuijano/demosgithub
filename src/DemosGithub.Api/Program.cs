using DemosGithub.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/products", (ProductService svc) =>
    Results.Ok(svc.GetAll()));

app.MapGet("/products/{id:int}", (int id, ProductService svc) =>
    svc.GetById(id) is { } product ? Results.Ok(product) : Results.NotFound());

app.MapGet("/products/search", (string term, ProductService svc) =>
    Results.Ok(svc.Search(term)));

app.MapGet("/products/total-value", (ProductService svc) =>
    Results.Ok(new { TotalValue = svc.CalculateTotalValue() }));

app.Run();
