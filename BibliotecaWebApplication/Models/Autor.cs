using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaWebApplication.Models
{
    public class Autor
    {
        [Key]
        public Guid AutorId { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        public string FotoPath {  get; set; }

        [NotMapped]
        public IFormFile Foto { get; set; }


        public Autor ()
        {
            this.AutorId = Guid.NewGuid();
        }

        //Propiedades de navegacion 
        public ICollection<Autorlibro> AutorLibros { get; set; } = new List<Autorlibro> ();
    }
}
