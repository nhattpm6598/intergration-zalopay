namespace Infrastructure.ZaloPay.Features
{
    public class BalanceClient : GenericClient, IBalanceClient
    {
        public BalanceClient(
            IOptions<ZaloPayOptions> options,
            IHttpClientFactory httpClientFactory,
            ILogger<GenericClient> logger) : base(options, httpClientFactory, logger)
        {
        }

        /// <summary>
        /// GetBalanceAsync
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetBalanceOutput> GetAsync(GetBalanceInput input)
        {
            string address = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesAgeementBalance}";

            GetBalanceClientRequest balance = new()
            {
                AppId = _options.Config.AppId,
                Identifier = input.UserId.ToString(),
                PayToken = input.PayToken,
                Amount = input.Amount
            };
            balance.SetMac(_options.Config.MerchantKey);

            // call api
            GetBalaceClientResponse response = await PostAsync<GetBalaceClientResponse>(address, balance.ParamsDic());

            // response
            if (response.SubReturnCode == ZLResponseCode.SUCCESS)
            {
                Data? dataResponse = response.Data.Where(_ => _.BankCode == "zp_app").FirstOrDefault();

                if (dataResponse!.Payable)
                {
                    return new() { Status = Status.SUCCESS, StatusMessage = nameof(StatusMessage.PAYMENT_CAN_BE_MADE), BankCode = dataResponse.BankCode };
                }
                return new() { Status = Status.FAILED, StatusMessage = $"{nameof(StatusMessage.PAYMENT_CANT_BE_MADE_ZP_CHANNEL)}: {response.SubReturnMessage}" };
            }
            return new() { Status = Status.FAILED, StatusMessage = $"{nameof(StatusMessage.PAYMENT_CANT_BE_MADE)}: {response.SubReturnMessage}" };
        }
    }
}
