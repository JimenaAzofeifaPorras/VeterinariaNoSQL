using Microsoft.AspNetCore.Mvc;
using VeterinariaCuidadosAPI.Models;
using VeterinariaCuidadosAPI.Repositories;

namespace VeterinariaCuidadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetroalimentacionController : Controller
    {
        private IRetroalimentacionColeccion db = new RetroalimentacionColeccion();

        [HttpGet]
        public async Task<ActionResult> GetAllRetroalimentacion()
        {
            return Ok(await db.GetAllRetroalimentacion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRetroalimentacionDetails(string id)
        {
            return Ok(await db.GetRetroalimentacionById(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateRetroalimentacion([FromBody] Retroalimentacion retroalimentacion)
        {
            if (retroalimentacion == null)
                return BadRequest();

            await db.InsertRetroalimentacion(retroalimentacion);

            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRetroalimentacion([FromBody] Retroalimentacion retroalimentacion, string id)
        {
            if (retroalimentacion == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("La Retroalimentacion no puede estar nulo o vacia.");
            }

            if (retroalimentacion.UsuarioCorreo == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El mail de la retroalimentacion no debería estar vacío.");
                return BadRequest(ModelState);
            }

            retroalimentacion.Id = id;
            await db.UpdateRetroalimentacion(retroalimentacion);

            return Ok("Actualizado exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRetroalimentacion(string id)
        {
            await db.DeleteRetroalimentacion(id);

            return NoContent(); //significa que todo salio bien
        }
    }
}
