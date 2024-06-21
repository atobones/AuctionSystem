using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AuctionSystem.Pages
{
    public class UserProfileModel : PageModel
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public void OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                Username = User.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
                Email = User.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
                FirstName = User.FindFirst(ClaimTypes.GivenName)?.Value ?? string.Empty;
                LastName = User.FindFirst(ClaimTypes.Surname)?.Value ?? string.Empty;
            }
        }
    }
}
