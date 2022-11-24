using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json;
using tp_grupal.Data;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public static class Repositorio
    {
        // TODO: Cambiar por DB
        //private static SortedList<string, Articulo> articulos = new SortedList<string, Articulo>();
        private static ApplicationDbContext _db;

        public static void Connect(ApplicationDbContext db)
        {
            _db = db;
        }

        public static Articulo Get(string id)
        {
            return _db.Articulos.Find(id);
        }

        public static List<Articulo> GetAll()
        {
            return _db.Articulos.ToList();
        }

        public static List<Articulo> GetCategoria(string categoria)
        {
            return _db.Articulos.Where(art => art.categoria == categoria).ToList();
        }

        public static List<Articulo> Buscar(string query)
        {
            return _db.Articulos.Where(art =>
                art.titulo.Contains(query) ||
                art.categoria.Contains(query)
            ).ToList();
        }

        public static string Agregar(Articulo art)
        {
            string id = Guid.NewGuid().ToString();

            Articulo a = new Articulo(
                id,
                art.titulo,
                art.categoria,
                art.contenido,
                art.imagen
            );

            _db.Articulos.Add(a);
            return id;
        }

        public static void Modificar(string id, Articulo art)
        {
            Articulo a = new Articulo(
                id,
                art.titulo,
                art.categoria,
                art.contenido,
                art.imagen
            );

            _db.Articulos.Update(a);
        }

        public static void Eliminar(string id)
        {
            _db.Articulos.Remove(_db.Articulos.Find(id));
        }
    }
}
