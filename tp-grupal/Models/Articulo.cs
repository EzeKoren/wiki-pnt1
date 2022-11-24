using MessagePack;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace tp_grupal.Models
{
    public class Articulo
    {
        [Key]
        public string _id { get; private set; }
        [Required]
        public string titulo { get; private set; }
        [Required]
        public string categoria { get; private set; }
        [Required]
        public string contenido { get; private set; }
        [Required]
        public string imagen { get; private set; }

        public Articulo(string id, string titulo, string categoria, string contenido, string imagen)
        {
            _id = id;
            this.titulo = titulo;
            this.categoria = categoria;
            this.contenido = contenido;

            if (Uri.IsWellFormedUriString(imagen, UriKind.Absolute))
                this.imagen = imagen;
            else throw new ArgumentException("La imagen debe ser una URL valida");

        }

        public Articulo(string titulo, string categoria, string contenido, string imagen)
        {
            this.titulo = titulo;
            this.categoria = categoria;
            this.contenido = contenido;

            if (Uri.IsWellFormedUriString(imagen, UriKind.Absolute))
                this.imagen = imagen;
            else throw new ArgumentException("La imagen debe ser una URL valida");
        }
    }
}
