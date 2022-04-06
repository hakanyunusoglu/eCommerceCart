using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eCommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository<Product> repo;
        public HomeController(IProductRepository<Product> _repo)
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