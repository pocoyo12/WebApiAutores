using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {

        private readonly AppDbContex contex;
        public AutoresController(AppDbContex contex)
        {
            this.contex = contex;
        }
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
           return await contex.autores.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            contex.Add(autor);
            await contex.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Autor autor)
        {
            if(autor.id != id)
            {
                return BadRequest("El ID del autor no coincide");
            }

            //estamos llendo a la tabla autores a verificar que existe el id 
            // de lo contrario no podremos verificarlo
            var existe = await contex.autores.AnyAsync(x => x.id == id);

            if (!existe)
            {
                return NotFound();
            }

            contex.Update(autor);

            await contex.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, Autor autor)
        {
            //estamos llendo a la tabla autores a verificar que existe el id 
            // de lo contrario no podremos verificarlo
            var existe = await contex.autores.AnyAsync(x=> x.id == id);

            if(!existe)
            {
                return NotFound();
            }

            contex.Remove( new Autor() { id = id });
            await contex.SaveChangesAsync();

            return Ok();
        }
    }
}
