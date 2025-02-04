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
using Serilog.Formatting.Compact;
using Serilog;
using PadronProveedoresAPI.MiddleWare.Logs;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Añade la configuración para el DbContext SQLSWRVER
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Configura Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Nivel minimo en desarrollo
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) //filtra losgs de microsoft
    .Enrich.FromLogContext() // Permite agregar contexto adicional
    .WriteTo.File(
        new CompactJsonFormatter(), // Formaoto json
        "logs/log.json", // ruta del archivo log
        rollingInterval: RollingInterval.Day // Log diario
        ) // Guarda en archivo JSON
    .CreateLogger();

builder.Host.UseSerilog(); // Usa Serilog como proveedor de logging

// Add services to the container (into the file ServiceConfig.cs)
builder.Services.AddServices( builder.Configuration );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se registra CustomLogger como un servicio
builder.Services.AddSingleton<CustomLogger>();

var app = builder.Build();

// Usa el middleware de manejo de errores
app.UseMiddleware<ErrorHandleMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder
        .WithOrigins("http://localhost:5173") // Permitir tu origen específico
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
