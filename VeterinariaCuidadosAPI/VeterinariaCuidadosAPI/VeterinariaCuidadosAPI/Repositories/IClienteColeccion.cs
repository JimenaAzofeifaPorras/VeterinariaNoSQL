using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
        public interface IClienteColeccion
        {
            Task InsertCliente(Cliente cliente);

            Task UpdateCliente(Cliente cliente);

            Task DeleteCliente(String id);

            Task<List<Cliente>> GetAllClientes();

            Task<Cliente> GetClienteById(String id);
        }
    }
