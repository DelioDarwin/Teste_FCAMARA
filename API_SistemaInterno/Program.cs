using API_SistemaInterno.Data;
using API_SistemaInterno.RabitMQ;
using API_SistemaInterno.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<IRabitMQUsuario, RabitMQUsuario>();


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
