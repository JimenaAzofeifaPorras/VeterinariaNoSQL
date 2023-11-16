using System.Text;
using System.Text.Json;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public class MascotaService : IMascotaService
    {
        public readonly HttpClient _httpClient;
        public MascotaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteMascota(string Id)
        {
            await _httpClient.DeleteAsync($"api/mascota/{Id}");
        }

        public async Task<IEnumerable<Mascota>> GetAllMascota()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Mascota>>(
                await _httpClient.GetStreamAsync($"api/mascota"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Mascota> GetMascotaDetails(string Id)
        {
            return await JsonSerializer.DeserializeAsync<Mascota>(
                await _httpClient.GetStreamAsync($"api/cliente/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveMascota(Mascota mascota)
        {
            var mascotaJson = new StringContent(JsonSerializer.Serialize(mascota),
                 Encoding.UTF8, "application/json");

            if (string.IsNullOrEmpty(mascota.Id))
                await _httpClient.PostAsync("api/mascota", mascotaJson);
            else
                await _httpClient.PutAsync($"api/mascota/{mascota.Id}", mascotaJson);
        }
    }
}