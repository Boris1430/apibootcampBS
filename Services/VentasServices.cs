using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class VentasServices : IVentas
    {
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();
        public VentasServices(VentasContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> GetVenta(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                if (numFactura != null && !numFactura.Equals("0"))
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            where v.NumFact.Equals(numFactura)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = v.Caja,
                                                Vendedor = v.Vendedor,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "Ok";
                }
                else
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            where v.Estado.Equals("Registrada")
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = v.Caja,
                                                Vendedor = v.Vendedor,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "Ok";
                    Log.LogErrorMetodos("VentaServices", "GetVenta", "PruebaLog");
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = "Se presento una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentasServices", "GetVenta", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PutVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Ventas.Update(venta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasServices", "PutVenta", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                bool existeFacturaId;
                existeFacturaId = await _context.Ventas.Where(x => x.IdFactura == venta.IdFactura).AnyAsync(); 

                if (!existeFacturaId)
                {
                    double newFacturaId = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura).FirstOrDefault() + 1;
                    venta.IdFactura = newFacturaId;
                    venta.FechaHora = DateTime.Now;

                    _context.Ventas.Add(venta);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Ok";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "PostVenta", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> DeleteVenta(double idFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                Venta? ventaToDelete = await _context.Ventas.FirstOrDefaultAsync(x => x.IdFactura == idFactura);

                if (ventaToDelete is not null)
                {
                    ventaToDelete.Estado = 2;

                    _context.Ventas.Update(ventaToDelete);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = ventaToDelete;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe una venta registrada con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasServices", "DeleteVenta", ex.Message);
            }
            return respuesta;
        }
    }
}
