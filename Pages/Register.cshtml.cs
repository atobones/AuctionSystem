using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AuctionSystem.Models;

namespace AuctionSystem.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterModel Input { get; set; } = new RegisterModel();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ваш код регистрации здесь

            return RedirectToPage("Index");
        }
    }
}



