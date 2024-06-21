using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AuctionSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AuctionSystem.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            User = await _userManager.FindByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var userToUpdate = await _userManager.FindByIdAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ApplicationUser>(
                userToUpdate,
                "user",
                u => u.UserName, u => u.Email))
            {
                var result = await _userManager.UpdateAsync(userToUpdate);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Users/Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}

