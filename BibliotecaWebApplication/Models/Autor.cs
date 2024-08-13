using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplication.Models
{
    public class Autor
    {
        [Key]
        public Guid AutorId { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }


        public Autor ()
        {
            this.AutorId = Guid.NewGuid();
        }

        //Propiedades de navegacion 
        public ICollection<Autorlibro> AutorLibros { get; set; } = new List<Autorlibro> ();
    }
}
