var builder = WebApplication.CreateBuilder(args);

// 1. Agrega el servicio para que el sistema reconozca los controladores.
builder.Services.AddControllers();

// (Opcional, para documentación de la API)
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

// 2. Le dice a la aplicación que use las rutas definidas en tus controladores.
app.MapControllers();

app.Run();