using ElevatorControl.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<ElevatorService>();
builder.Services.AddControllers();
builder.Services.AddCors(opts =>
    opts.AddDefaultPolicy(policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                   // genera el JSON de Swagger
    app.UseSwaggerUI(c =>               // UI interactiva en /swagger
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ElevatorControl API v1");
        c.RoutePrefix = string.Empty;  // para que UI quede en la raíz ("/")
    });
}

app.UseCors();
app.MapControllers();

app.Run();

