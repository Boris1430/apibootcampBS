using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IProducto
    {
        Task<List<Producto>> GetListaProductos(int productoID);
        Task<List<Producto>> GetPrecioProducto(double precio);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
    }
}
