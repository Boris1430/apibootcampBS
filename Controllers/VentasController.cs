using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VentasController : Controller
    {
        private readonly IVentas _venta;
        private ControlError Log = new ControlError();
        public VentasController(IVentas venta)
        {
            this._venta = venta;
        }
        [HttpGet]
        [Route("GetVenta")]
        public async Task<Respuesta> GetVenta(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVenta(numFactura);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "GetVenta", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutVenta")]
        public async Task<Respuesta> PutVenta([FromBody] Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PutVenta(venta);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "PutVenta", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostVenta")]
        public async Task<Respuesta> PostVenta([FromBody] Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PostVenta(venta);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "PostVenta", ex.Message);
            }
            return respuesta;
        }
        [HttpDelete]
        [Route("DeleteVenta")]
        public async Task<Respuesta> DeleteVenta(string? idFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.DeleteVenta(idFactura);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "DeleteVenta", ex.Message);
            }
            return respuesta;
        }
    }
}
