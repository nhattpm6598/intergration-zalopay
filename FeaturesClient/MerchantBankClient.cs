using Infrastructure.ZaloPay.FeaturesClient.Abstraction;
using Infrastructure.ZaloPay.Models.Requests;
using Infrastructure.ZaloPay.Models.Response;
using Newtonsoft.Json;

namespace Infrastructure.ZaloPay.FeaturesClient
{
    public class MerchantBankClient : GenericClient, IMerchantBankClient
    {
        public MerchantBankClient(IOptions<ZaloPayOptions> options,
                                  IHttpClientFactory httpClientFactory,
                                  ILogger<GenericClient> logger) : base(options, httpClientFactory, logger)
        {
        }

        public async Task<GetMerchantBankResponse> GetAsync()
        {
            string endpoint = $"{_options.ApiConfig.EndpointGateway}{_options.ApiConfig.RoutesGetListMerchantBanks}"; 

            GetMerchantBankRequest require = new()
            {
                AppId = _options.Config.AppId
            };
            require.SetMac(_options.Config.MerchantKey);

            _logger.LogWarning($"{endpoint} \n {JsonConvert.SerializeObject(require)}");

            // call client
            GetMerchantBankResponse response = await PostAsyncV2<GetMerchantBankResponse>(endpoint, require.ParamsDic());

            return response;
        }
    }
}
