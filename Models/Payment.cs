using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionSystem.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Amount { get; set; }
        public int AuctionItemId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
