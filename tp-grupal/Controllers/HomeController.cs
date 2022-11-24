using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using tp_grupal.Models;

namespace tp_grupal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string query = null)
        {
            List<Articulo> articulos;
            if (query == null)
            {
                articulos = Repositorio.GetAll();
            }
            else
            {
                articulos = Repositorio.Buscar(query);
            }

            return View(articulos);
        }

        public IActionResult Articulo(string id)
        {
            Articulo art = Repositorio.Get(id);
            List<Articulo> otros = Repositorio.GetAll();
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