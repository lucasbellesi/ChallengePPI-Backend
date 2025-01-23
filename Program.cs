using ChallengePPI.Backend.Data;
using ChallengePPI.Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();

// Agregar el contexto de la base de datos usando SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios personalizados
builder.Services.AddScoped<OrderCalculationService>();

// Configuración de CORS (opcional, dependiendo de tus necesidades)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configuración de Swagger para documentar la API
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Middleware de redirección a HTTPS
app.UseHttpsRedirection();

// Middleware de CORS
app.UseCors();

// Middleware de autorización
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();
