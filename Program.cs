using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PadronProveedoresAPI;
using PadronProveedoresAPI.Data;
using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Data.Repository.Project;
using PadronProveedoresAPI.Services;
using PadronProveedoresAPI.Services.Project;
using PadronProveedoresAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Añade la configuración para el DbContext SQLSWRVER
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});


// Add services to the container (into the file ServiceConfig.cs)
builder.Services.AddServices( builder.Configuration );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
