using GameShopV1.Data;
using GameShopV1.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV1.Controllers
{
    public class LogInController : Controller
    {
        private readonly GameShopDbContext _gameShopDbContext;

        public LogInController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            var playerExists = _gameShopDbContext.Players
            .Where(x => x.Email == player.Email && x.Age == player.Age)
            .FirstOrDefault();

            if (playerExists != null)
            {
                return RedirectToAction("Index", "Store",playerExists);
            }
            else
            {
                ViewBag.AuthenticationError = "Sorry Invalid Credentials !";
                return View();
            }
        }
    }
}
