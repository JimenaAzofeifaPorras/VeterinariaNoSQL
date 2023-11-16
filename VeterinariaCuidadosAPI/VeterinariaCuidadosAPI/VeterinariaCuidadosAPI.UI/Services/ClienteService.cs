using System.Text;
using System.Text.Json;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCliente(string Id)
        {
            await _httpClient.DeleteAsync($"api/cliente/{Id}");
        }

        public async Task<IEnumerable<Cliente>> GetAllCliente()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Cliente>>(
                await _httpClient.GetStreamAsync($"api/cliente"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Cliente> GetClienteDetails(string Id)
        {
            return await JsonSerializer.DeserializeAsync<Cliente>(
                await _httpClient.GetStreamAsync($"api/cliente/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveCliente(Cliente cliente)
        {
            var clienteJson = new StringContent(JsonSerializer.Serialize(cliente),
                Encoding.UTF8, "application/json");

            if (string.IsNullOrEmpty(cliente.Id))
                await _httpClient.PostAsync("api/cliente", clienteJson);
            else
                await _httpClient.PutAsync($"api/cliente/{cliente.Id}", clienteJson);
        }
    }
}