using System.Linq;

namespace tp_grupal.Models
{
    public class Repositorio
    {
        private static string claveAdmin = "Clave.1";

        // TODO: Cambiar por DB
        private SortedList<string, Articulo> articulos;
        private SortedList<string, Categoria> categorias;
        private SortedList<string, Articulo_Categoria> articulos_cat;

        public Repositorio ()
        {
            this.articulos = new SortedList<string, Articulo>();
            this.categorias = new SortedList<string, Categoria>();
            this.articulos_cat = new SortedList<string, Articulo_Categoria>();
        }

        public Articulo Get (string id) { 
            return this.articulos[id];
        }

        public List<Articulo> GetAll ()
        {
            List<Articulo> list = new List<Articulo>();
            foreach (string id in this.articulos.Keys)
            {
                list.Add(this.articulos[id]);
            }
            return list;
        }

        public List<Articulo> GetCategoria (Categoria categoria)
        {
            List<Articulo> list = new List<Articulo>();
            foreach (string id in this.articulos.Keys)
            {
                Articulo articulo = this.articulos[id];
                if (articulo.categorias.Contains(categoria))
                {
                    list.Add(articulo);
                }
            }
            return list;
        }

        public List<Articulo> Buscar (string query)
        {
            List<Articulo> list = new List<Articulo>();
            foreach (string id in this.articulos.Keys)
            {
                Articulo articulo = this.articulos[id];
                if (
                    articulo.titulo.Contains(query) ||
                    articulo.categorias.Any(categoria => categoria.Equals(query))
                ) {
                    list.Add(articulo);
                } 
            }
            return list;
        }

        public string Agregar (Articulo art)
        {
            string id = Guid.NewGuid().ToString();

            Articulo a = new Articulo(
                id, 
                art.titulo, 
                art.contenido, 
                art.imagen
            );

            this.articulos.Add(id, a);
            return id;
        }

        public void Modificar (string id, Articulo art)
        {
            Articulo a = new Articulo(
                id,
                art.titulo,
                art.contenido,
                art.imagen
            );

            this.articulos[id] = a;
        }

        public void Eliminar (string id)
        {
            this.articulos.Remove(id);
        }


        public void addCategoria(string catItem, string IdArt)
        {
            Categoria cat = new Categoria ()


        }
    }
}
