using ProductosApi.BL.Dtos;

namespace ProductosApi.BL.Services;

public interface IProductoService
{
    List<ProductoDto> ObtenerTodos();
    ProductoDto? ObtenerPorId(int id);
    ProductoDto Crear(CreateProductoDto dto);
    ProductoDto? Actualizar(int id , CreateProductoDto dto );
    bool Eliminar(int id);
}