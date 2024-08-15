using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplication.Models
{
    public class Libro
    {
        [Key]
        public Guid LibroId { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int NumeroPaginas { get; set; }

        public ICollection<Autor> Autores { get; set; } = new List<Autor>();


        public ICollection<Autorlibro> LibroAutores { get; set; } = new List<Autorlibro>();

        public bool TieneAutores => Autores.Any();

        public Libro()
        {
            this.LibroId = Guid.NewGuid();
        }
    }
}

