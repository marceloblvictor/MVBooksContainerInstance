using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/books", () =>
{
    return "GOT books successfull";
})
.WithName("GetBooks");

app.MapGet("/books/{id:int}", (/*[FromRoute]*/int id, /*[FromQuery]*/int q) =>
{
    return $"Sum: {id} + {q} = {id + q}";
})
.WithName("GetBookAndSum");

app.Run();
