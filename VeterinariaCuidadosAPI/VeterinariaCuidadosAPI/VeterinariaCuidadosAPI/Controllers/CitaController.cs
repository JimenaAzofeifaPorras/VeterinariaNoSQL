using Microsoft.AspNetCore.Mvc;
using VeterinariaCuidadosAPI.Models;
using VeterinariaCuidadosAPI.Repositories;

namespace VeterinariaCuidadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : Controller
    {
        private ICitaColeccion db = new CitaColeccion();

        [HttpGet]
        public async Task<ActionResult> GetAllCitas()
        {
            return Ok(await db.GetAllCitas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCitaDetails(string id)
        {
            return Ok(await db.GetCitasById(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCita([FromBody] Cita cita)
        {
            if (cita == null)
                return BadRequest();

            await db.InsertCita(cita);

            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCita([FromBody] Cita cita, string id)
        {
            if (cita == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("Cita o Id no pueden ser nulos o vacíos.");
            }

            var existingCita = await db.GetCitasById(id);

            if (existingCita == null)
            {
                return NotFound("Cita no encontrada.");
            }

            existingCita.Fecha = cita.Fecha;
            existingCita.MascotaId = cita.MascotaId;
            existingCita.Descripcion = cita.Descripcion;

            await db.UpdateCita(existingCita);

            return Ok("Actualizado exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(string id)
        {
            await db.DeleteCita(id);

            return NoContent();
        }
    }
}
