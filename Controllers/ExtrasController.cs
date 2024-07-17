using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using EjemploEntity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExtrasController : Controller
    {
        private ControlError Log = new ControlError();
        private readonly IConfiguration _configuration;
        private PokeApi pokeApi = new PokeApi();
        private ChuckNorris chuckNorris = new ChuckNorris();

        public ExtrasController(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPokeApi").Value!;

                respuesta = await pokeApi.GetPokeApi(url);

            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetChuckNorris")]
        public async Task<Respuesta> GetChuckNorris(String? Url)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckNorris").Value;
                respuesta = await chuckNorris.GetChuckNorris(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetChuckNorris", ex.Message);
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetChuckRandomCategory")]
        public async Task<Respuesta> GetChuckRandomCategory(string categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckRandom_Category").Value!;
                respuesta = await chuckNorris.GetChuckRandomCategory(url, categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetChuckRandomCategory", ex.Message);
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetChuckCategory")]
        public async Task<Respuesta> GetChuckCategory()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckCategory").Value!;
                respuesta = await chuckNorris.GetChuckCategory(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetChuckCategory", ex.Message);
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetChuckQuery")]
        public async Task<Respuesta> GetChuckQuery(string texto)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckQuery").Value!;
                respuesta = await chuckNorris.GetChuckQuery(url, texto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ExtrasController", "GetChuckQuery", ex.Message);
            }
            return respuesta;
        }

    }
}
