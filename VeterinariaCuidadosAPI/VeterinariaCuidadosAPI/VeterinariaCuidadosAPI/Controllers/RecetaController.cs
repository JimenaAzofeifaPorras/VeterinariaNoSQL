using Microsoft.AspNetCore.Mvc;
using VeterinariaCuidadosAPI.Models;
using VeterinariaCuidadosAPI.Repositories;

namespace VeterinariaCuidadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : Controller
    {
        private IRecetaColeccion db = new RecetaColeccion();

        [HttpGet]
        public async Task<ActionResult> GetAllRecetas()
        {
            return Ok(await db.GetAllRecetas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRecetaDetails(string id)
        {
            return Ok(await db.GetRecetaById(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateReceta([FromBody] Receta receta)
        {
            if (receta == null)
                return BadRequest();

            if (receta.Nombre_Factura == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre de la factura no deberia de estar vacio");
            }

            await db.InsertReceta(receta);

            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReceta([FromBody] Receta receta, string id)
        {
            if (receta == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("La receta no puede estar nulo o vacia.");
            }

            if (receta.Nombre_Factura == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre de la factura no debería estar vacío.");
                return BadRequest(ModelState);
            }

            receta.Id = id;
            await db.UpdateReceta(receta);

            return Ok("Actualizado exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta(string id)
        {
            await db.DeleteReceta(id);

            return NoContent(); //significa que todo salio bien
        }
    }
}