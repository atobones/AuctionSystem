using Microsoft.AspNetCore.Mvc;
using AuctionSystem.Services;
using AuctionSystem.Models;

namespace AuctionSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest request)
        {
            var paymentId = await _paymentService.CreatePayment(request.Amount);
            var approvalLink = await _paymentService.GetApprovalLink(paymentId);
            return Ok(new { paymentId, approvalLink });
        }

        [HttpPost("capture")]
        public async Task<IActionResult> CapturePayment([FromQuery] string orderId)
        {
            var result = await _paymentService.CapturePayment(orderId);
            return result ? Ok() : StatusCode(500);
        }

        [HttpGet("success")]
        public IActionResult PaymentSuccess()
        {
            return Ok("Payment successful.");
        }

        [HttpGet("cancel")]
        public IActionResult PaymentCancel()
        {
            return Ok("Payment cancelled.");
        }
    }
}
