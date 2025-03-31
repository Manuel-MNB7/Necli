using Necli.LogicaNegocio;
using Necli.LogicaNegocio.Services;
using Necli.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Registrar dependencias en el contenedor
builder.Services.AddScoped<CuentaRepository>(); // Agrega el repositorio requerido
builder.Services.AddScoped<UsuarioRepository>(); // Ya registrado
builder.Services.AddScoped<CuentasService>();    // Ya registrado
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<TransacionService>();
builder.Services.AddScoped<TransacionRepository>();







// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure el HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
