using Microsoft.AspNetCore.Mvc;
using VeterinariaCuidadosAPI.Models;
using VeterinariaCuidadosAPI.Repositories;

namespace VeterinariaCuidadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private IClienteColeccion db = new ClienteColeccion();

        [HttpGet]
        public async Task<ActionResult> GetAllClientes()
        {
            return Ok(await db.GetAllClientes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClienteDetails(string id)
        {
            return Ok(await db.GetClienteById(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (cliente.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre no deberia de estar vacio");
            }

            await db.InsertCliente(cliente);

            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente([FromBody] Cliente cliente, string id)
        {
            if (cliente == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("Cliente o Id no pueden ser nulos o vacíos.");
            }

            if (cliente.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre no debería estar vacío.");
                return BadRequest(ModelState);
            }

            cliente.Id = id;
            await db.UpdateCliente(cliente);

            return Ok("Actualizado exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            await db.DeleteCliente(id);

            return NoContent(); //significa que todo salio bien
        }
    }
}
