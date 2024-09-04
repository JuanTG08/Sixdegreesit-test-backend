using BackendApi.Servicios.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Referencia que se usa para especificar los CORS
string NameCors = "AllowSpecificOriginsWithCors";

// Leer la configuración de CORS desde appsettings.json
string[] corsOrigins = builder.Configuration.GetValue<string>("Cors")?.Split(",", StringSplitOptions.RemoveEmptyEntries);
builder.Services.AddCors(options =>
{
    options.AddPolicy(NameCors,
        policy =>
        {
            policy.WithOrigins(corsOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Agregamos servicios al contenedor.
// Registrar los controladores
builder.Services.AddControllers();

// Configurar Swagger para documentación de la API
// Swagger permite la generación automática de documentación para la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra el servicio IServicioUsuario con su implementación ServicioUsuarios.
// Este servicio tendrá un ciclo de vida 'scoped', lo que significa que se creará una
// nueva instancia por cada solicitud HTTP.
builder.Services.AddScoped<IServicioUsuario, ServicioUsuarios>();

var app = builder.Build();

// Aplicar la política de CORS definida anteriormente
app.UseCors(NameCors);

// Configurar el pipeline de la aplicación HTTP sí es es desarrollo
if (app.Environment.IsDevelopment())
{
    // Usar Swagger solo en desarrollo para ver la documentación de la API
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Forzar el uso de HTTPS para la seguridad

app.UseAuthorization(); // Manejar la autorización en la aplicación

app.MapControllers(); // Mapear los controladores a las rutas de la API

app.Run(); // Ejecutar la aplicación
