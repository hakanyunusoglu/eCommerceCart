using eCommerce.Persistence.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices repo;
        public HomeController(IProductServices _repo)
        {
            repo = _repo;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("loggedUser") != null)
            {

                return View(await repo.GetAll());
            }
            else
            {
                return RedirectToAction("SignIn", "User");
            }
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var product = await repo.GetById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> CartAdd(Guid id)
        {
            return View();
        }
    }
}