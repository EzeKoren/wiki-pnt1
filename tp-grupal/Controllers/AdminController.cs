using Microsoft.AspNetCore.Mvc;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(string query = null)
        {
            List<Articulo> articulos;
            if (query == null) 
            { 
                articulos = Repositorio.GetAll();
            } else
            {
                articulos = Repositorio.Buscar(query);
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
            Articulo art = new Articulo(
                col["titulo"][0],
                col["categoria"][0],
                col["contenido"][0],
                col["imagen"][0]
            );

            Repositorio.Agregar(art);

            return Redirect("/admin");
        }

        public IActionResult Editar(string id)
        {
            Articulo art = Repositorio.Get(id);
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

            Repositorio.Modificar(col["_id"][0], art);

            return Redirect("/admin");
        }

        public IActionResult Eliminar(string id)
        {
            Repositorio.Eliminar(id);

            return Redirect("/admin");
        }
    }
}
