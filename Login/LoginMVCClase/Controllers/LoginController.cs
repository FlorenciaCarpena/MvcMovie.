using System.Security.Claims;
using LoginMVCClase.BaseDeDatosFicticia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LoginMVCClase.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login (String username, string password) 
        {
            var user = FakeUserDB.Users.FirstOrDefault(u => u.User == username && u.Password == password);

            if (user != null)

            { 
                
                    var claims=new List<Claim>
                    {
                        new Claim (ClaimTypes.Name, username)
                    }
                
                ;
              HttpContext.Session.SetString("User", user.User);
                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("Cookies", principal);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Error = "Credenciales Invalidad";
            }
                return View();

        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
