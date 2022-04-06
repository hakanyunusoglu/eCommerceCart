using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IAppUserRepository<AppUser> repo;
        public UserController(IAppUserRepository<AppUser> _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = await repo.GetByUsername(model.Username);
                if (loggedUser != null)
                {
                    byte[] passwordHash, passwordSalt;
                    repo.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
                    model.passwordSalt = passwordSalt;
                    model.passwordHash = passwordHash;
                    if (await repo.VerifyPassowrd(model.Password, model.Username, model.passwordHash, model.passwordSalt))
                    {
                        HttpContext.Session.SetString("loggedUser", model.Username);

                        return RedirectToAction("Index", "Home");
                    }
                }
                
            }
            ViewBag.ErrorMessage = "Giriş bilgileri hatalı. Lütfen kontrol edip tekrar deneyiniz!";
            return View(model);
        }
        public async Task<IActionResult> SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
