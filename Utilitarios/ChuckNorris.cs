using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitarios
{
    public class ChuckNorris
    {
        private ControlError log = new ControlError();
        public async Task<Respuesta> GetChuckNorris(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisDTO>(json);
                respuesta.Mensaje = "Se consumio correctamente";

            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorris", "GetChuckNorris", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetChuckRandomCategory(string url, string categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?category={categoria}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckRandomCategoryDTO>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";

            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorris", "GetChuckRandomCategory", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetChuckCategory(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<List<string>>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";

            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorris", "GetChuckCategory", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetChuckQuery(string url, string texto)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?query={texto}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckQueryDTO>(json);
                respuesta.Mensaje = "Ha sido consumido correctamente";

            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorris", "GetChuckQuery", ex.Message);
            }
            return respuesta;
        }
    }
}
