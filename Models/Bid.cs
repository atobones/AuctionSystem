namespace AuctionSystem.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int AuctionItemId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidDate { get; set; }
    }
}
