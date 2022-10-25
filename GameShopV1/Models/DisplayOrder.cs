namespace GameShopV1.Models
{
    public class DisplayOrder
    {
        public int OrderId { get; set; }
        public string GameName { get; set; }
        public string PlayerName { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
