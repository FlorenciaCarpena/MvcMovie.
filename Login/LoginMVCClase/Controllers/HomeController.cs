using LoginMVCClase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace LoginMVCClase.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        private static List<PersonaModel> personas = new List<PersonaModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            ViewBag.Mensaje = "¡Bienvenido a la página principal! Agrega una persona:";
            return View(personas);  
        }

        [HttpPost]
        public IActionResult Agregar(PersonaModel persona)
        {
            if (ModelState.IsValid)
            {
                personas.Add(persona);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
