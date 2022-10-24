using GameShopV1.Data;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV1.Controllers
{
    public class StoreController : Controller
    {
        private readonly GameShopDbContext _gameShopDbContext;
        public StoreController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }
        public IActionResult Index()
        {
            var games = _gameShopDbContext.Games.ToList();
            return View(games);
        }
    }
}
