using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions options) : base(options)
        {

        }

        public DbSet <Autor> autores { get; set; }

        // sin este dbset no se creara un nuevo query en ls DB
        public DbSet <Libro> libros { get; set; }
    }
}
