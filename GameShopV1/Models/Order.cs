namespace GameShopV1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
