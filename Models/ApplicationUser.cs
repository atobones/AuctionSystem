using Microsoft.AspNetCore.Identity;

namespace AuctionSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty; 
        public string Address { get; set; } = string.Empty; 
        public string City { get; set; } = string.Empty; 
        public string State { get; set; } = string.Empty; 
        public string PostalCode { get; set; } = string.Empty; 
    }
}
