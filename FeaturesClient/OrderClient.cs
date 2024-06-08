using Infrastructure.ZaloPay.Common.Helper;
using Infrastructure.ZaloPay.Models.Requests;
using Infrastructure.ZaloPay.Models.Response;

namespace Infrastructure.ZaloPay.Features
{
    public class OrderClient : GenericClient, IOrderClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="httpClientFactory"></param>
        /// <param name="logger"></param>
        public OrderClient(IOptions<ZaloPayOptions> options,
                            IHttpClientFactory httpClientFactory,
                            ILogger<GenericClient> logger) : base(options, httpClientFactory, logger)
        {
        }

        /// <summary>
        /// CreateOrder
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CreateOrderOutput> CreateAsync(CreateOrderInput input)
        {
            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesOrderCreate}";

            CreateOrderRequest order = new()
            {
                BankCode = input.BankCode,
                AppId = _options.Config.AppId,
                AppUser = input.AppUserId,
                Amount = input.Amount,
                Title = input.Title,
                Description = input.Description,
                CallbackUrl = input.CallbackUrl ??
                    (
                    input.BindingType == BindingType.WALLET
                        ? _options.Config.CallBackPaymentUrl.AddParam(new { BindingType = "ZaloPay" })
                        : _options.Config.CallBackPaymentUrl.AddParam(new { BindingType = input.BindingType.DescriptionAttr() })
                    ),
                RedirectUrl = _options.Config.RedirectUrl
            };
            order.SetAppTransactionId(input.TransactionId);
            order.SetItem(input.Item);
            order.SetEmbedData(input.EmbedData);
            order.SetMac(_options.Config.MerchantKey);

            // call api
            CreateOrderResponse response = await PostAsync<CreateOrderResponse>(endpoint, order.ParamsDic());

            // response
            return new()
            {
                Status = (response.ReturnCode == ZLResponseCode.SUCCESS) ? Status.SUCCESS : Status.FAILED,
                StatusMessage = $"{nameof(StatusMessage.ORDER_CANT_CREATE)}: {response.SubReturnMessage}",
                TransactionToken = response.ZpTransactionToken,
                OrderPaymentUrl = response.OrderUrl,
                OrderTransactionId = order.AppTransactionId,
                OrderToken = response.OrderTransactionToken
            };

        }

        /// <summary>
        /// QueryOrderStatus
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<GetOrderStatusOutput> GetStatusAsync(GetOrderStatusInput input)
        {
            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesOrderStatus}";

            QueryOrderStatusRequest query = new QueryOrderStatusRequest()
            {
                AppId = _options.Config.AppId,
                AppTransactionId = input.OrderTransactionId
            };
            query.SetMac(_options.Config.MerchantKey);

            QueryOrderStatusResponse response = await PostAsync<QueryOrderStatusResponse>(endpoint, query.ParamsDic());

            // response
            return new()
            {
                StatusOrders = response.return_code,
                Amount = response.amount,
                Status = (response.return_code == ZLResponseCode.SUCCESS) ? Status.SUCCESS
                        : (response.return_code == ZLResponseCode.PROCESSING) ? Status.PROCESSING : Status.FAILED,
                StatusMessage = $"{nameof(StatusMessage.GET_STATUS_ORDER)}: {response.sub_return_message}",
                RefundTransactionToken = response.zp_trans_id.ToString()
            };
        }
    }
}
