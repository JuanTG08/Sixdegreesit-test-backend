using BackendApi.Servicios.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Referencia que se usa para especificar los CORS
string NameCors = "AllowSpecificOriginsWithCors";

// Leer la configuraci�n de CORS desde appsettings.json
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

// Configurar Swagger para documentaci�n de la API
// Swagger permite la generaci�n autom�tica de documentaci�n para la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra el servicio IServicioUsuario con su implementaci�n ServicioUsuarios.
// Este servicio tendr� un ciclo de vida 'scoped', lo que significa que se crear� una
// nueva instancia por cada solicitud HTTP.
builder.Services.AddScoped<IServicioUsuario, ServicioUsuarios>();

var app = builder.Build();

// Aplicar la pol�tica de CORS definida anteriormente
app.UseCors(NameCors);

// Configurar el pipeline de la aplicaci�n HTTP s� es es desarrollo
if (app.Environment.IsDevelopment())
{
    // Usar Swagger solo en desarrollo para ver la documentaci�n de la API
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Forzar el uso de HTTPS para la seguridad

app.UseAuthorization(); // Manejar la autorizaci�n en la aplicaci�n

app.MapControllers(); // Mapear los controladores a las rutas de la API

app.Run(); // Ejecutar la aplicaci�n
