using System.Security.Cryptography;

namespace tp_grupal.Models
{
    public class Categoria
    {
        public string nombre { get; set; }
  
        public Categoria(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
