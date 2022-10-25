namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int id { get; set; }
        public string nombre { get; set; }

        // relacionando la tabla autores con la tabla libros
        public List<Libro> Libros { get; set; }

    }
}
