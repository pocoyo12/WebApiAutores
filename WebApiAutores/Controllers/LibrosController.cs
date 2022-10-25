using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Migrations;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/Libros")]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContex contex;
        public LibrosController(AppDbContex contex)
        {
            this.contex = contex;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<libros>> Get(int id)
        {
            return await contex.libros.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
