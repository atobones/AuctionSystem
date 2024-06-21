using Microsoft.AspNetCore.Mvc.RazorPages;
using AuctionSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuctionSystem.Data;

namespace AuctionSystem.Pages.Payments
{
    public class PaymentModel : PageModel
    {
        private readonly DataContext _context;

        public PaymentModel(DataContext context)
        {
            _context = context;
        }

        public IList<Payment> Payments { get; set; }

        public async Task OnGetAsync()
        {
            Payments = await _context.Payments.ToListAsync();
        }
    }
}
