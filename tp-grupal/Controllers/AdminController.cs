using Microsoft.AspNetCore.Mvc;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class AdminController : Controller
    {
        private static Repositorio repositorio = new Repositorio();

        public IActionResult Dashboard()
        {
            List<Articulo> articulos = repositorio.GetAll();
            return View(articulos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Editar(Articulo art)
        {
            return View(art);
        }

        [HttpPost]
        public IActionResult Crear(IFormCollection col)
        {
            List<string> cat = col["categorias"][0].Split(",").Select(c => c.Trim()).ToList();

            Articulo art = new Articulo(
               col["titulo"][0],
               col["contenido"][0],
               col["imagen"][0]
           );
             string IdArt = repositorio.Agregar(art);

            foreach (string catItem in cat)
            {
                repositorio.addCategoria(catItem, IdArt);

            }

            return View();
        }
    }
}
