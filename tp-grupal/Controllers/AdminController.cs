using Microsoft.AspNetCore.Mvc;
using tp_grupal.Data;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string query = null)
        {
            List<Articulo> articulos;
            if (query == null) 
            { 
                articulos = GetAll();
            } else
            {
                articulos = Buscar(query);
            }

            return View(articulos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(IFormCollection col)
        {
            try
            {
                Articulo art = new Articulo(
                    col["titulo"][0],
                    col["categoria"][0],
                    col["contenido"][0],
                    col["imagen"][0]
                );

                Agregar(art);

                return Redirect("/admin");
            } catch(Exception e)
            {
                
            }
        }

        public IActionResult Editar(string id)
        {
            Articulo art = Get(id);
            return View(art);
        }

        [HttpPost]
        public IActionResult Editar(IFormCollection col)
        {
            Articulo art = new Articulo(
                col["titulo"][0],
                col["categoria"][0],
                col["contenido"][0],
                col["imagen"][0]
            );

            Modificar(col["_id"][0], art);

            return Redirect("/admin");
        }

        public IActionResult Eliminar(string id)
        {
            EliminarDB(id);

            return Redirect("/admin");
        }



        // DB

        public Articulo Get(string id)
        {
            return _db.Articulos.Find(id);
        }

        public List<Articulo> GetAll()
        {
            return _db.Articulos.ToList();
        }

        public List<Articulo> Buscar(string query)
        {
            return _db.Articulos.Where(art =>
                art.titulo.Contains(query) ||
                art.categoria.Contains(query)
            ).ToList();
        }


        public string Agregar(Articulo art)
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
            _db.SaveChanges();
            return id;
        }

        public void Modificar(string id, Articulo art)
        {
            Articulo a = new Articulo(
                id,
                art.titulo,
                art.categoria,
                art.contenido,
                art.imagen
            );

            _db.Articulos.Update(a);
            _db.SaveChanges();
        }

        public void EliminarDB(string id)
        {
            _db.Articulos.Remove(_db.Articulos.Find(id));
            _db.SaveChanges();
        }
    }
}
