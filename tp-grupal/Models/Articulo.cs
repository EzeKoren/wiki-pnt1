namespace tp_grupal.Models
{
    public class Articulo
    {
        public string _id { get; private set; }
        public string titulo { get; private set; }
        public string contenido { get; private set; }
        public string imagen { get; private set; }

        public Articulo (string id, string titulo, string contenido, string imagen)
        {
 
            _id = id;
            this.titulo = titulo;
            this.contenido = contenido;
            this.imagen = imagen;
        }

        public Articulo(string titulo, string contenido, string imagen)
        {
            this.titulo = titulo;
            this.contenido = contenido;
            this.imagen = imagen;
        }

    }
}
