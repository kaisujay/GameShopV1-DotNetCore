using GameShopV1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameShopV1.Data
{
    public class GameShopDbContext : DbContext
    {
        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
