using ProductosApi.BL.Dtos;
using ProductosApi.BL.Services;
using ProductosApi.DAL.Models;
using ProductosApi.DAL.Repositories;

namespace ProductosApi.BL.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repo;

    public ProductoService(IProductoRepository repo)
    {
        _repo = repo;
    }

    public List<ProductoDto> ObtenerTodos()
    {
        return _repo.ObtenerTodos().Select(ToDto).ToList();
    }

    public ProductoDto? ObtenerPorId(int id)
    {
        var producto = _repo.ObtenerPorId(id);
        return producto is null ? null : ToDto(producto);
    }

    public ProductoDto Crear(CreateProductoDto dto)
    {
        var producto = new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            Activo = true
        };

        var creado = _repo.Agregar(producto);
        return ToDto(creado);
    }

    public ProductoDto? Actualizar(int id, CreateProductoDto dto)
    {
        var existente = _repo.ObtenerPorId(id);
        if (existente is null) return null;

        existente.Nombre = dto.Nombre;
        existente.Precio = dto.Precio;
        existente.Categoria = dto.Categoria;

        _repo.Actualizar(existente);
        return ToDto(existente);
    }

    public bool Eliminar(int id)
    {
        return _repo.Eliminar(id);
    }

    private static ProductoDto ToDto(Producto p) => new()
    {
        Id = p.Id,
        Nombre = p.Nombre,
        Precio = p.Precio,
        Categoria = p.Categoria,
        Activo = p.Activo
    };
}