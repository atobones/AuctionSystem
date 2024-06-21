// Controllers/BidController.cs
using Microsoft.AspNetCore.Mvc;
using AuctionSystem.Data;
using AuctionSystem.Models;
using System.Linq;

namespace AuctionSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly DataContext _context;

        public BidController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PlaceBid(Bid bid)
        {
            _context.Bids.Add(bid);
            _context.SaveChanges();
            return Ok(bid);
        }

        [HttpGet("{auctionItemId}")]
        public IActionResult GetBids(int auctionItemId)
        {
            var bids = _context.Bids.Where(b => b.AuctionItemId == auctionItemId).ToList();
            return Ok(bids);
        }
    }
}
