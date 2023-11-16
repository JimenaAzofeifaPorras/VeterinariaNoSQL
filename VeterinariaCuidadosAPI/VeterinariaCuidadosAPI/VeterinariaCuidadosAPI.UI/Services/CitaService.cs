using System.Text;
using System.Text.Json;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public class CitaService : ICitaService
    {
        public readonly HttpClient _httpClient;
        public CitaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCitas(string Id)
        {
            await _httpClient.DeleteAsync($"api/cita/{Id}");
        }

        public async Task<IEnumerable<Cita>> GetAllCitas()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Cita>>(
                await _httpClient.GetStreamAsync($"api/cita"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Cita> GetCitasDetails(string Id)
        {
            return await JsonSerializer.DeserializeAsync<Cita>(
                await _httpClient.GetStreamAsync($"api/cita/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveCitas(Cita cita)
        {
            var citaJson = new StringContent(JsonSerializer.Serialize(cita),
                Encoding.UTF8, "application/json");

            if (string.IsNullOrEmpty(cita.Id))
                await _httpClient.PostAsync("api/cita", citaJson);
            else
                await _httpClient.PutAsync($"api/cita/{cita.Id}", citaJson);
        }
    }
}
