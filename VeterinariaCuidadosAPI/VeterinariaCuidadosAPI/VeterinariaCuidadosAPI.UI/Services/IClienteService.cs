using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllCliente();
        Task<Cliente> GetClienteDetails(string id);
        Task SaveCliente(Cliente cliente);
        Task DeleteCliente(string id);
    }
}
