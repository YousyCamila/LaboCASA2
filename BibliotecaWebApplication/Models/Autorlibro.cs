namespace BibliotecaWebApplication.Models
{
    public class Autorlibro
    {
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }


        public  Guid LibroId { get; set; }
        public Libro Libro { get; set; }
    }
}
