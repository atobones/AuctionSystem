using System.Threading.Tasks;

using System;
using System.Threading.Tasks;

namespace AuctionSystem.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<string> CreatePayment(decimal amount)
        {
            string paymentId = Guid.NewGuid().ToString();

            return Task.FromResult(paymentId);
        }

        public Task<bool> CapturePayment(string orderId)
        {
            return Task.FromResult(true);
        }

        public Task<string> GetApprovalLink(string orderId)
        {
            return Task.FromResult($"https://approval-link.com/{orderId}");
        }
    }
}
