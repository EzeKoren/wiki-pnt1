using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using System.Linq;
using tp_grupal.Data;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string query = null)
        {
            List<Articulo> articulos;
            if (query == null)
            {
                articulos = _context.Articulos.ToList();
            }
            else
            {
                articulos = _context.Articulos.Where(art => art.titulo.Contains(query)).ToList();
            }

            return View(articulos);
        }

        public IActionResult Articulo(int id)
        {
            Articulo art = _context.Articulos.Find(id);
            List<Articulo> otros = _context.Articulos.ToList();
            Tuple<Articulo, List<Articulo>> model = new Tuple<Articulo, List<Articulo>>(art, otros);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}