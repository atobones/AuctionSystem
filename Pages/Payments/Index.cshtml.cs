using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuctionSystem.Data;
using AuctionSystem.Models;

namespace AuctionSystem.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public List<Payment> Payments { get; set; }

        public async Task OnGetAsync()
        {
            Payments = await _context.Payments.ToListAsync();
        }
    }
}
