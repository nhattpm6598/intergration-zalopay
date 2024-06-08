using Infrastructure.ZaloPay.FeaturesClient.Abstraction;
using Infrastructure.ZaloPay.Models.Requests;
using Infrastructure.ZaloPay.Models.Response;
using Newtonsoft.Json;

namespace Infrastructure.ZaloPay.FeaturesClient
{
    public class RefundClient : GenericClient, IRefundClient
    {
        public RefundClient(IOptions<ZaloPayOptions> options,
            IHttpClientFactory httpClientFactory,
            ILogger<GenericClient> logger) : base(options, httpClientFactory, logger)
        {
        }

        public async Task<QueryRefundOutput> QueryAsync(QueryRefundInput input)
        {
            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesRefundStatus}"; ;

            QueryRefundRequest require = new()
            {
                AppId = _options.Config.AppId,
                RefundId = input.RefundTransactionId
            };
            require.SetMac(_options.Config.MerchantKey);

            // call client
            QueryRefundResponse response = await PostAsyncV2<QueryRefundResponse>(endpoint, require.ParamsDic());

            _logger.LogWarning(JsonConvert.SerializeObject(response));

            // response
            return new()
            {
                Status = (response.ReturnCode == ZLResponseCode.SUCCESS) ? Status.SUCCESS : Status.FAILED,
                StatusMessage = $"RefundStatus: {response.SubReturnMessage}",
            };
        }

        public async Task<RefundOutput> RefundAsync(RefundInput input)
        {
            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesRefund}"; ;

            RequireRefundRequest require = new()
            {
                AppId = _options.Config.AppId,
                Amount = input.Amount,
                Description = input.Description,
                ZPTransactionId = input.TransactionId,
            };

            require.SetRefund(input.RefundTransactionId);
            require.SetMac(_options.Config.MerchantKey);

            // call client
            RequireRefundResponse response = await PostAsyncV2<RequireRefundResponse>(endpoint, require.ParamsDic());

            // response
            return new()
            {
                Status = (response.ReturnCode == ZLResponseCode.PROCESSING) ? Status.PROCESSING : Status.FAILED,
                StatusMessage = $"RefundPayment: {response.SubReturnMessage}",
                RefundId = response.RefundId,
                RefundTransactionId = require.RefundId,
                ErrorCode = response.SubReturnCode
            };
        }
    }
}
