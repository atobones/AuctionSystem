using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AuctionSystem.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AuctionSystem.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(UserManager<ApplicationUser> userManager, ILogger<DeleteModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public ApplicationUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _userManager.FindByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Attempting to delete user with ID: {Id}", id);
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                _logger.LogWarning("User with ID: {Id} not found", id);
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID: {Id} successfully deleted", id);
                return RedirectToPage("./Index");
            }

            foreach (var error in result.Errors)
            {
                _logger.LogError("Error deleting user with ID: {Id}. Error: {Error}", id, error.Description);
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}


