using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GymRepository;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<GymContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GymContext") ?? throw new InvalidOperationException("Connection string 'GymContext' not found.")));*/

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection for DB
//builder.Services.AddScoped<IGymRepo, MockDB>();
builder.Services.AddScoped<IGymRepo, RealDB>();

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
