using ContactAPI.Data;
using ContactAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext and Connection String
builder.Services.AddDbContext<ContactDbContext>(cdb => cdb.UseSqlServer(builder.Configuration.GetConnectionString("ContactDbConnectionString")), ServiceLifetime.Singleton);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger UI (from Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IContactService, ContactService>();
builder.Services.AddScoped<IContactDbService, ContactDbService>();


var app = builder.Build();

app.MapGet("/hello", () => "Hello World!")
   .WithName("HelloWorld")   // Adds metadata
   .WithOpenApi();           // Marks endpoint for OpenAPI

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Swashbuckle – Swagger UI at /swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
