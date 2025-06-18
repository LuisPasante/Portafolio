using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioDTO _repositorioDTO;
        public HomeController(ILogger<HomeController> logger,IRepositorioDTO repositorioDTO )
        {
            _logger = logger;
            _repositorioDTO = repositorioDTO;
        }

        public IActionResult Index()
        {  
            var proyectos  = _repositorioDTO.ObtenerProyectos().Take(3);
            var modelo = new HomeDTO {  Proyectos = proyectos  };
            return View("Index", modelo);
        }
     
        public IActionResult Proyectos()
        {
            var proyectos = _repositorioDTO.ObtenerProyectos();
            return View("_Proyectos",proyectos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
