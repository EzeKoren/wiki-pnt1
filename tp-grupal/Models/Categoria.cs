using System.Security.Cryptography;

namespace tp_grupal.Models
{
    public class Categoria
    {
        public string nombre { get; set; }
        public string id_categoria { get; set; }

        public Categoria(string nombre, string id)
        {
            this.nombre = nombre;
            this.id_categoria = id;
        }
    }
}
