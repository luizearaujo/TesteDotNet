using System.Web.Mvc;

namespace TesteDotNet.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Detalhe()
        {
            return View();
        }
    }
}