using Infrastructure.ZaloPay.Models.Requests;
using Infrastructure.ZaloPay.Models.Response;
using Newtonsoft.Json;
using Infrastructure.ZaloPay.Common.Enums;
using Infrastructure.ZaloPay.Common.Helper;

namespace BE.Eco.Infrastructure.ZaloPay.Features
{
    public class ContractClient : GenericClient, IContractClient
    {
        public ContractClient(
            IOptions<ZaloPayOptions> options,
            IHttpClientFactory httpClientFactory,
            ILogger<GenericClient> logger) : base(options, httpClientFactory, logger)
        {
        }

        /// <summary>
        /// Binding
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<ContractBindingOutput> Binding(ContractBindingInput input)
        {
            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesAgeementBinding}";

            CreateBlindingRequest blinding = new()
            {
                AppId = _options.Config.AppId,
                RedirectUrl = input.RedirectLink ?? _options.Config.RedirectUrl,
                RedirectDeepLink = input.RedirectLink ?? _options.Config.RedirectDeepLink,
                CallBackUrl = !string.IsNullOrEmpty(input.CallbackLink)
                    ? input.CallbackLink 
                    : _options.Config.CallBackContractUrl.AddParam(new
                    {
                        BindingType = input.BindingType == BindingType.WALLET ? "ZaloPay" : BindingType.CARD.DescriptionAttr(),
                        input.UserType,
                        input.TenantId
                    }), // end param callback
                MaxAmount = 0,
                BindingType = input.BindingType.DescriptionAttr(),
                Identifier = input.UserId.ToString(),
            };

            blinding.SetAppTransactionId(Guid.NewGuid().ToString("N"));
            blinding.SetBindingData(input.Data);
            //field end
            blinding.SetMac(_options.Config.MerchantKey);

            _logger.LogInformation(JsonConvert.SerializeObject(blinding));

            //response
            CreateBindingResponse response = await PostAsyncV2<CreateBindingResponse>(endpoint, blinding.ParamsDic());

            //result
            return new ContractBindingOutput()
            {
                Status = (response.ReturnCode == ZLResponseCode.SUCCESS) ? Status.SUCCESS : Status.FAILED,
                StatusMessage = $"{response.ReturnMessage}-{response.SubReturnMessage}",
                Link = (input.Type == ApplicationType.App && !string.IsNullOrEmpty(response.DeepLink)) 
                    ? response.DeepLink  
                    : response.BindingQrLink,
                BindingId = response.BindingToken,
                AppTransactionId = blinding.AppTransactionId,
            };
        }

        /// <summary>
        /// GetInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ContractBindingInfoOutput> GetInfo(ContractBindingInfoInput input)
        {
            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesGetContractInfo}";

            GetContractBindingInfoRequest request = new GetContractBindingInfoRequest()
            {
                AppId = _options.Config.AppId,
                ReqDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
            };
            request.SetAppTransactionId(Guid.NewGuid().ToString("N"));
            request.SetMac(_options.Config.MerchantKey);

            GetContractBindingInfoResponse response = await PostAsync<GetContractBindingInfoResponse>(endpoint, request.ParamsDic());

            return new ContractBindingInfoOutput()
            {
                Status = (response.ReturnCode == ZLResponseCode.SUCCESS) ? Status.SUCCESS : Status.FAILED,
                PayToken = response.Data.PayToken,
                Account = response.Data.MaskedUserPhone
            };
        }


        /// <summary>
        /// Unbinding
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CancelBindingOutput> Unbinding(CancelBindingInput input)
        {
            if (string.IsNullOrEmpty(input.ContractId)) return new CancelBindingOutput() { Status = Status.FAILED };

            string endpoint = $"{_options.ApiConfig.Endpoint}{_options.ApiConfig.RoutesAgeementUnBinding}";

            CancelBindingRequest unbinding = new()
            {
                AppId = _options.Config.AppId,
                BindingId = input.ContractId,
                Identifier = input.UserId.ToString()
            };
            unbinding.SetMac(_options.Config.MerchantKey);

            CancelBindingResponse response = await PostAsync<CancelBindingResponse>(endpoint, unbinding.ParamsDic());

            return new CancelBindingOutput()
            {
                Status = (response.ReturnCode == ZLResponseCode.SUCCESS) ? Status.SUCCESS : Status.FAILED,
                StatusMessage = response.ReturnMessage,
            };
        }
    }
}
