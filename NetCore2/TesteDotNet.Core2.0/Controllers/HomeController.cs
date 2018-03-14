using Microsoft.AspNetCore.Mvc;

namespace TesteDotNet.Core2._0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Detalhe()
        {
            return View();
        }
    }
}
