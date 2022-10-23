namespace GameShopV1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
