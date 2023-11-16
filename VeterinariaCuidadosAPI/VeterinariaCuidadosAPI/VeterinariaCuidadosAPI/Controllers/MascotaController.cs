using Microsoft.AspNetCore.Mvc;
using VeterinariaCuidadosAPI.Models;
using VeterinariaCuidadosAPI.Repositories;

namespace VeterinariaCuidadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : Controller
    {
        private IMascotaColeccion db = new MascotaColeccion();

        [HttpGet]
        public async Task<ActionResult> GetAllMascotas()
        {
            return Ok(await db.GetAllMascotas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMascotaDetails(string id)
        {
            return Ok(await db.GetMascotaById(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateMascota([FromBody] Mascota mascota)
        {
            if (mascota == null)
                return BadRequest();

            if (mascota.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre no deberia de estar vacio");
            }

            await db.InsertMascota(mascota);

            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMascota([FromBody] Mascota mascota, string id)
        {
            if (mascota == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("Mascota o Id no pueden ser nulos o vacíos.");
            }

            if (mascota.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre no debería estar vacío.");
                return BadRequest(ModelState);
            }

            mascota.Id = id;
            await db.UpdateMascota(mascota);

            return Ok("Actualizado exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(string id)
        {
            await db.DeleteMascota(id);

            return NoContent(); //significa que todo salio bien
        }
    }
}

