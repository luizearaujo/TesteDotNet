using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteDotNet.Core2_0.Models;
using TesteDotNet.Core2_0.Services.Base;

namespace TesteDotNet.Core2_0.Controllers
{
    public class HomeController : Controller
    {
        IService<ItemViewModel> _itemService;
        
        public HomeController(IService<ItemViewModel> itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index(string busca)
        {
            var model = new IndexViewModel
            {
                ListaItem = _itemService.Find(busca),
                Busca = busca
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var model = _itemService.Get(id);

            if (id != null && model == null)
                return View("NaoEncontrado");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _itemService.Save(item);

                return RedirectToAction(nameof(Index));
            }

            item.ListaCategorias = _itemService.Get(null).ListaCategorias;
            return View(item);
        }

        public IActionResult Detalhe(int id)
        {
            var model = _itemService.Get(id);

            if (model == null)
                return View("NaoEncontrado");

            return View(model);
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            _itemService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
