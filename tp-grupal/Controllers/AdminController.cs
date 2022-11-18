using Microsoft.AspNetCore.Mvc;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class AdminController : Controller
    {
        private Repositorio repositorio = new Repositorio();

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
        public IActionResult Crear(Articulo art)
        {
            //List<string> cat = categorias.Split(",").Select(c => c.Trim()).ToList();

            //Articulo art = new Articulo(
            //    titulo,
            //    cat,
            //    contenido,
            //    imagen
            //);

            repositorio.Agregar(art);

            return View();
        }
    }
}
