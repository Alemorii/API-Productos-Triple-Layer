using ProductosApi.DAL.Models;
using ProductosApi.DAL.Repositories;

namespace ProductosApi.DAL.Repositories
{
    public class ProductoRepositoryInMemory : IProductoRepository
    {
        private static readonly List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Ryzen 5600g", Precio = 279000m, Categoria = "CPU", Activo = true },
            new Producto { Id = 2, Nombre = "i9 9900k", Precio = 500000m, Categoria = "CPU", Activo = true },
            new Producto { Id = 3, Nombre = "Rtx 3060", Precio = 200000m, Categoria = "GPU", Activo = true },
        };

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public Producto Agregar(Producto producto)
        {
            producto.Id = _productos.Count == 0 ? 1 : _productos.Max(p => p.Id) + 1;
            _productos.Add(producto);
            return producto;
        }

        public void Actualizar(Producto producto)
        {
            var index = _productos.FindIndex(p => p.Id == producto.Id);
            if (index != -1)
                _productos[index] = producto;
        }

        public bool Eliminar(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto is null) return false;

            _productos.Remove(producto);
            return true;
        }

        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return _productos
                .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}