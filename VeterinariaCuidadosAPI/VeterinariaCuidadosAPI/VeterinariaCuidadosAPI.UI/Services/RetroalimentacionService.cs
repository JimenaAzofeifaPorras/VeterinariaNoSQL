using System.Text.Json;
using System.Text;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public class RetroalimentacionService : IRetroalimentacionService
    {
        public readonly HttpClient _httpClient;
        public RetroalimentacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteRetroalimentacion(string Id)
        {
            await _httpClient.DeleteAsync($"api/retroalimentacion/{Id}");
        }

        public async Task<IEnumerable<Retroalimentacion>> GetAllRetroalimentacion()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Retroalimentacion>>(
                await _httpClient.GetStreamAsync($"api/retroalimentacion"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Retroalimentacion> GetRetroalimentacionDetails(string Id)
        {
            return await JsonSerializer.DeserializeAsync<Retroalimentacion>(
                await _httpClient.GetStreamAsync($"api/retroalimentacion/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveRetroalimentacion(Retroalimentacion retroalimentacion)
        {
            var retroalimentacionJson = new StringContent(JsonSerializer.Serialize(retroalimentacion),
                Encoding.UTF8, "application/json");

            if (string.IsNullOrEmpty(retroalimentacion.Id))
                await _httpClient.PostAsync("api/retroalimentacion", retroalimentacionJson);
            else
                await _httpClient.PutAsync($"api/retroalimentacion/{retroalimentacion.Id}", retroalimentacionJson);
        }
    }
}
