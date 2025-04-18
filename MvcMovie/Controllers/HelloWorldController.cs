using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TuProyecto.Controllers  // Asegurate de usar el namespace correcto de tu app
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public string Index()
        {
            return "This is my default action...";
        }
        // GET: /HelloWorld/Welcome?name=Rick&numtimes=4
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        // GET: /HelloWorld/Welcome/3?name=Rick
        public string WelcomeConId(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}
