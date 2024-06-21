using Microsoft.AspNetCore.Identity;

namespace AuctionSystem.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public ApplicationRole()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
