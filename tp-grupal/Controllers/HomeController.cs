using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using tp_grupal.Data;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index(string query = null)
        {
            List<Articulo> articulos;
            if (query == null)
            {
                articulos = GetAll();
            }
            else
            {
                articulos = Buscar(query);
            }

            return View(articulos);
        }

        public IActionResult Articulo(string id)
        {
            Articulo art = Get(id);
            List<Articulo> otros = GetAll();
            Tuple<Articulo, List<Articulo>> model = new Tuple<Articulo, List<Articulo>>(art, otros);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // DB

        public List<Articulo> GetAll()
        {
            return _db.Articulos.ToList();
        }
        
        public Articulo Get(string id)
        {
            return _db.Articulos.Find(id);
        }
        public List<Articulo> Buscar(string query)
        {
            return _db.Articulos.Where(art =>
                art.titulo.Contains(query) ||
                art.categoria.Contains(query)
            ).ToList();
        }

    }
}