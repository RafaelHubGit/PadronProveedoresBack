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
builder.Services.AddServices();

// Registrar TypesenseService
builder.Services.AddScoped<TypeSenseService>(sp =>
{
    //var pRepository = sp.GetRequiredService<ProveedorService>();
    //return new TypesenseService("http://localhost:8108", "xyz", pRepository);
    //return new TypeSenseService("http://10.68.2.200:8108", "xyz", pRepository);

    var pRepository = sp.GetRequiredService<ProveedorService>();
    var typeSenseSettings = sp.GetService<IOptions<TypeSenseSettings>>().Value;
    return new TypeSenseService(typeSenseSettings.ServerUrl, typeSenseSettings.ApiKey, pRepository);
});

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
