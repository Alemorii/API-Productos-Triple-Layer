using ProductosApi.DAL.Repositories;
using ProductosApi.BL.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// aqui un minimal api raiz para funcionar de guia 
app.MapGet("/", () => Results.Text("""
    Productos API funcionando

    Endpoints disponibles:
        GET    /api/productos
        GET    /api/productos/{id}
        POST   /api/productos
        PUT    /api/productos/{id}
        DELETE /api/productos/{id}
    """, "text/plain; charset=utf-8"));
app.Run();
