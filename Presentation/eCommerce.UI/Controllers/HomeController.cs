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
            ViewBag.Username = null;

            if(HttpContext.Session.GetString("loggedUser")!= null)
            { 
                ViewBag.Username = HttpContext.Session.GetString("loggedUser").ToString();
            }
            return View(await repo.GetAll());
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var product = await repo.GetById(id);
            if (product != null)
            {
                ViewBag.Username = null;

                if (HttpContext.Session.GetString("loggedUser") != null)
                {
                    ViewBag.Username = HttpContext.Session.GetString("loggedUser").ToString();
                }
                return View(product);
            }
            return RedirectToAction("Index","Home");
        }
    }
}