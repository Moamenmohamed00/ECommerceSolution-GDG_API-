using ECommerce.Application.Interfaces;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DotNetEnv;
using ECommerce.Persistence.DatasSed;
var builder = WebApplication.CreateBuilder(args);

Env.Load();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ECommerceDb>(Options =>
Options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
//Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Configure the HTTP request pipeline.
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ECommerceDb>();
    db.Database.Migrate(); 
    ECommerceSeed.SeedAsync(db).Wait();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
