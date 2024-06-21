namespace AuctionSystem.Services
{
    public interface IPaymentService
    {
        Task<string> CreatePayment(decimal amount);
        Task<bool> CapturePayment(string orderId);
        Task<string> GetApprovalLink(string orderId);
    }
}
