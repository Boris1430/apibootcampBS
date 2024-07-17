using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVenta(string? numFactura);
        Task<Respuesta> PutVenta(Venta venta);
        Task<Respuesta> PostVenta(Venta venta);
        Task<Respuesta> DeleteVenta(string? idFactura);
    }
}