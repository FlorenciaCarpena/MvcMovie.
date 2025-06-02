using System.Security.Claims;
using LoginMVCClase.BaseDeDatosFicticia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LoginMVCClase.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = FakeUserDB.Users.FirstOrDefault(u => u.User == username && u.Password == password);

            if (user != null)
            {
                // Crear claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                // Crear identidad y principal
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Guardar en sesión 
                HttpContext.Session.SetString("User", user.User);

                // Iniciar sesión
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Redirigir al Home
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Credenciales inválidas";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            // Cierra sesión
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Borra sesión
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
