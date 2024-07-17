using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;
        public ProductoController(IProducto producto) 
        {
            this._producto = producto;
        }
        [HttpGet]
        [Route("GetListaProductos")]
        public async Task<List<Producto>> GetListaProductos(int productoID)
        {
            var respuesta = new List<Producto>();
            try
            {
                respuesta = await _producto.GetListaProductos(productoID);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetPrecioProducto")]
        public async Task<List<Producto>> GetPrecioProducto(double precio)
        {
            var respuesta = new List<Producto>();
            try
            {
                respuesta = await _producto.GetPrecioProducto(precio);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody]Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto); 
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)  
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }
    }
}
