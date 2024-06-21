using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AuctionSystem.Services
{
    public class PayPalPaymentService : IPaymentService
    {
        private readonly PayPalHttpClient _client;

        public PayPalPaymentService(IConfiguration configuration)
        {
            var environment = configuration["PayPal:Environment"] == "sandbox" ?
                (PayPalEnvironment)new SandboxEnvironment(
                    configuration["PayPal:ClientId"],
                    configuration["PayPal:ClientSecret"]
                ) :
                new LiveEnvironment(
                    configuration["PayPal:ClientId"],
                    configuration["PayPal:ClientSecret"]
                );

            _client = new PayPalHttpClient(environment);
        }

        public async Task<string> CreatePayment(decimal amount)
{
    var order = new OrderRequest()
    {
        CheckoutPaymentIntent = "CAPTURE",
        PurchaseUnits = new List<PurchaseUnitRequest>
        {
            new PurchaseUnitRequest
            {
                AmountWithBreakdown = new AmountWithBreakdown
                {
                    CurrencyCode = "USD",
                    Value = amount.ToString("F2", CultureInfo.InvariantCulture) 
                }
            }
        },
        ApplicationContext = new ApplicationContext
        {
            ReturnUrl = "https://localhost:5001/api/Payment/Success",
            CancelUrl = "https://localhost:5001/api/Payment/Cancel"
        }
    };

    var request = new OrdersCreateRequest();
    request.Prefer("return=representation");
    request.RequestBody(order);

    var response = await _client.Execute(request);
    var result = response.Result<Order>();

    return result.Id; // Возвращаем ID заказа
}

        public async Task<bool> CapturePayment(string orderId)
        {
            var request = new OrdersCaptureRequest(orderId);
            request.RequestBody(new OrderActionRequest());
            var response = await _client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.Created;
        }

      public async Task<string> GetApprovalLink(string orderId)
{
    var request = new OrdersGetRequest(orderId);
    var response = await _client.Execute(request);
    var result = response.Result<Order>();

    var approvalLink = result.Links?.FirstOrDefault(link => link.Rel.Equals("approve", StringComparison.OrdinalIgnoreCase))?.Href;
    return approvalLink ?? string.Empty;
}
    }
}




