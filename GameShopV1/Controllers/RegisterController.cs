using GameShopV1.Data;
using GameShopV1.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly GameShopDbContext _gameShopDbContext;

        public RegisterController(GameShopDbContext gameShopDbContext)
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
            var newPlayer = new Player()
            {
                Name = player.Name,
                Email = player.Email,
                Age = player.Age
            };
            _gameShopDbContext.Players.Add(newPlayer);
            _gameShopDbContext.SaveChanges();
            return View();
        }
    }
}
