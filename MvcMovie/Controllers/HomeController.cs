
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();  // Este método busca la vista Index.cshtml
        }
    
    public IActionResult Privacy()
        {
            return View();
        }
    } 
}

