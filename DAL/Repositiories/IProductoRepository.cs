using ProductosApi.DAL.Models;

namespace ProductosApi.DAL.Repositories
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
        Producto Agregar(Producto producto);      
        void Actualizar(Producto producto);       
        bool Eliminar(int id);                    
        List<Producto> BuscarPorCategoria(string categoria);  
    }
}