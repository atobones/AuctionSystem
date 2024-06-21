// Models/AuctionItem.cs
namespace AuctionSystem.Models
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal StartingBid { get; set; }
        public DateTime EndDate { get; set; }
    }
}
