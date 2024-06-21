using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AuctionSystem.Models;

namespace AuctionSystem.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginModel Input { get; set; } = new LoginModel();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ваш код аутентификации здесь

            return RedirectToPage("Index");
        }
    }
}


