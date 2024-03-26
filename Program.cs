using Microsoft.EntityFrameworkCore;
using WebApiGerenciador.DataContext;
using WebApiGerenciador.Services.ColaboradorServices;
using WebApiGerenciador.Services.PontoServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//referenciando interface com service
builder.Services.AddScoped<IColaboradorInterface, ColaboradorService>();
builder.Services.AddScoped<IPontoInterface, PontoService>();

//criando conexão com o banco de dados definido em appsettings.json/appsettings.Development.jason 
// na string definida por "DefaultConnection"
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
