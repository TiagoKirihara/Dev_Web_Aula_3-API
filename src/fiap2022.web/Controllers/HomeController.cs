using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace fiap2022.Controllers
{
    public class HomeController : Controller
    {

        //public JsonResult Index()
        //public ActionResult Index()
        //public ActionResult<Pessoa> Index()
        //public Pessoa Index()
        //public IActionResult Index()
        //public ViewResult Index()
        public ViewResult Index()
        {

            ViewData["nome"] = "Gabriel";
            ViewData["pessos"] = new Pessoa() { Nome = "Luiz" };
            //TempData["TesteTempData"] = "Teste";// new Pessoa() { Nome = "Roberto" };
            ViewBag.Categoria = "Alimentos";



            var viewModel = new HomeViewModel()
            {
                Pessoas = new List<Pessoa>(),
                Paises = new List<Pais>()
            };

            for (int i = 0; i < 3; i++)
            {
                viewModel.Pessoas.Add(new Pessoa() { Nome = $"Ana {i + 1}" });
                viewModel.Paises.Add(new Pais() { Nome = $"Brasil {i + 1}" });
            }

            //return View("teste");
            return View(viewModel);
        }

        public IActionResult Sobre()
        {
            return View();
        }
    }
}
