using Microsoft.AspNetCore.Mvc;
using tp_grupal.Data;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listado = _context.Articulos.ToList();
            return View(listado);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Articulo art)
        {
            if (ModelState.IsValid)
            {
                _context.Articulos.Add(art);
                _context.SaveChanges();
                return Redirect("/admin");
            }

            return View(art);

        }

        public IActionResult Editar(int id)
        {
            var art = _context.Articulos.Find(id);
            return View(art);
        }

        [HttpPost]
        public IActionResult Editar(Articulo art)
        {
            if (ModelState.IsValid)
            {
                _context.Articulos.Update(art);
                _context.SaveChanges();
                return Redirect("/admin");
            }

            return View(art);
        }

        public IActionResult Eliminar(int id)
        {
            _context.Articulos.Remove(_context.Articulos.Find(id));
            _context.SaveChanges();
            return Redirect("/admin");
        }
    }
}
