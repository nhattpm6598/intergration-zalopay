
namespace BE.Eco.Infrastructure.ZaloPay.Features
{
    public class PaymentClient : GenericClient, IPaymentClient
    {
        public PaymentClient(
            IOptions<ZaloPayOptions> options,
            IHttpClientFactory httpClientFactory,
            ILogger<GenericClient> logger) : base(options, httpClientFactory, logger)
        {
        }

        /// <summary>
        /// 3. require payment order
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<RequirePaymentOutput> RequirePaymentAsync(RequirePaymentInput input)
        {
            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesAgeementPay}"; ;

            AutoPaymentRequest require = new()
            {
                AppId = _options.Config.AppId,
                TransactionToken = input.TransactionToken,
                PayToken = input.PayToken,
                Identifier = input.UserId.ToString()
            };
            require.SetMac(_options.Config.MerchantKey);

            // call client
            AutoPaymentResponse response = await PostAsync<AutoPaymentResponse>(endpoint, require.ParamsDic());

            // response
            return new()
            {
                Status = (response.ReturnCode == ZLResponseCode.PROCESSING) ? Status.SUCCESS : Status.FAILED,
                StatusMessage = $"RequirePayment: {response.SubReturnMessage}",
                PayTransactionId = response.TransactionId
            };
        }
    }
}
