using LoginMVCClase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace LoginMVCClase.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult formethod(string username, string password, string name, string fechanacimiento, string email)
        {
            UsuarioModel usuario = new UsuarioModel();
            List<UsuarioModel> listUsuario = new List<UsuarioModel>();
            for (int i = 0; i <= 5; i++) 
            {
                usuario = new UsuarioModel();
                usuario.email = "florenciacarpena@gmail.com";
                usuario.username = "FCarpena";
                usuario.password = "password";
                usuario.fechadenacimiento_ = DateTime.Now;
                usuario.name = "Florencia Carpena";
                usuario.id = i;

                listUsuario.Add(usuario);


            }

            

                return View("Index");
        }

    }
}
