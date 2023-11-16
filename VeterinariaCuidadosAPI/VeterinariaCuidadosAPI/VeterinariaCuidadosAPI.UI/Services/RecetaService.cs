using System.Text;
using System.Text.Json;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public class RecetaService : IRecetaService
    {
        public readonly HttpClient _httpClient;
        public RecetaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteReceta(string Id)
        {
            await _httpClient.DeleteAsync($"api/receta/{Id}");
        }

        public async Task<IEnumerable<Receta>> GetAllReceta()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Receta>>(
                await _httpClient.GetStreamAsync($"api/receta"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Receta> GetRecetaDetails(string Id)
        {
            return await JsonSerializer.DeserializeAsync<Receta>(
                await _httpClient.GetStreamAsync($"api/receta/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveReceta(Receta receta)
        {
            var recetaJson = new StringContent(JsonSerializer.Serialize(receta),
                Encoding.UTF8, "application/json");

            if (string.IsNullOrEmpty(receta.Id))
                await _httpClient.PostAsync("api/receta", recetaJson);
            else
                await _httpClient.PutAsync($"api/receta/{receta.Id}", recetaJson);
        }
    }
}
