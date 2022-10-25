namespace WebApiAutores.Entidades
{
    public class Libro
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int autorid { get; set; }
        public Autor autor { get; set; }
        
    }
}
