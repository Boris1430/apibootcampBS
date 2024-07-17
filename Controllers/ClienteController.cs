using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : Controller
    {
        public readonly ICliente _cliente;
        private ControlError Log = new ControlError();  
        public ClienteController(ICliente cliente) 
        {
            this._cliente = cliente;
        }
        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(int Cliente_Id, string? Cliente_Nombre,double Cedula)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.GetCliente(Cliente_Id, Cliente_Nombre, Cedula);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ClienteController", "GetCliente", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PostCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ClienteController", "PostCliente", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _cliente.PutCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ClienteController", "GetCliente", ex.Message);
            }
            return respuesta;
        }
    }
}
