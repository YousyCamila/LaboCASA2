using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplication.Models
{
    public class Libro
    {
        [Key] 
        public  Guid LibroId { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int NumeroPaginas { get; set; }

        public Libro ()

        {
            this.LibroId = Guid.NewGuid ();
        }

        //Propiedades de navegacion 
        public ICollection<Autorlibro> LibroAutores { get; set; } = new List<Autorlibro>();
    }
}
