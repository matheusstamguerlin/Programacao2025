using Microsoft.AspNetCore.Mvc;

namespace Aula03parte2.Controllers
{
    public class JogoVelhoControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
