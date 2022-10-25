using GameShopV1.Data;
using GameShopV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShopV1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly GameShopDbContext _gameShopDbContext;

        public OrdersController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }
        public IActionResult Index(string PlayerEmail)
        {
            var order = _gameShopDbContext.Orders
                .Include(x => x.Player)
                .Include(x => x.Game)
                .Where(x => x.PlayerId == x.Player.Id && x.GameId == x.GameId)
                .Select(x => new DisplayOrder()
                {
                    OrderId = x.Id,
                    GameName = x.Game.Name,
                    PlayerName = x.Player.Name,
                    PurchaseDate = x.PurchaseDate
                }).ToList();
                
            return View(order);
        }
    }
}
