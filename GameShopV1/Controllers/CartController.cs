using GameShopV1.Data;
using GameShopV1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV1.Controllers
{
    public class CartController : Controller
    {
        private Cart _cart;
        private readonly GameShopDbContext _gameShopDbContext;

        public CartController(GameShopDbContext gameShopDbContext)
        {
            _cart = new Cart();
            _cart.Games = new List<Game>();
            _gameShopDbContext = gameShopDbContext;
        }
        public IActionResult Index()
        {
            _cart.Player = _gameShopDbContext.Players
               .Where(x => x.Email == HttpContext.Session.GetString("PlayerEmail"))
               .FirstOrDefault();

            var GameIdsList = HttpContext.Session.GetString("GameId");
            var GameIds = GameIdsList.Split(',').Skip(1);

            foreach (var item in GameIds)
            {
                var game = _gameShopDbContext.Games
                       .Where(x => x.Id == Convert.ToInt32(item))
                       .FirstOrDefault();
                _cart.Games.Add(game);
            }

            return View(_cart);
        }

        public IActionResult AddingToCart(int GameId, string PlayerEmail)
        {
            var player = _gameShopDbContext.Players
                .Where(x => x.Email == PlayerEmail)
                .FirstOrDefault();

            HttpContext.Session.SetString("PlayerEmail", PlayerEmail);
            HttpContext.Session.SetString("GameId", HttpContext.Session.GetString("GameId") + "," + GameId.ToString());

            return RedirectToAction("Index", "Store", player);
        }

        public IActionResult DoOrder(string games, int player)
        {
            var gameList = games.Split(',').Skip(1);
            

            foreach (var item in gameList)
            {
                var orders = new Order()
                {
                    GameId = Convert.ToInt32(item),
                    PlayerId = player,
                    PurchaseDate = DateTime.Now
                };
                _gameShopDbContext.Orders.Add(orders);
                _gameShopDbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Store");
        }
    }
}
