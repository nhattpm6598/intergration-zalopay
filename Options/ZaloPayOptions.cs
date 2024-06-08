namespace Eco.Infrastructure.ZaloPay.Options
{
    public class ZaloPayOptions
    {
        public const string Key = "ZaloPayOptions";

        public MerchantConfig Config { get; set; } = new();

        public MerchantApiConfig ApiConfig { get; set; } = new();

        public DelayPayment DelayPayment { get; set; } = new();
    }

    public class DelayPayment
    {
        public int Distance { get; set; }

        public int Times { get; set; }
    }

    public class MerchantConfig
    {
        public int AppId { get; set; }

        public string MerchantKey { get; set; } = string.Empty;

        public string RedirectUrl { get; set; } = string.Empty;

        public string RedirectDeepLink { get; set; } = string.Empty;

        public string CallBackPaymentUrl { get; set; } = string.Empty;

        public string CallBackContractUrl { get; set; } = string.Empty;

    }

    public class MerchantApiConfig
    {
        public string Endpoint { get; set; } = string.Empty;

        public string EndpointGateway { get; set; } = string.Empty;

        public string RoutesOrderCreate { get; set; } = string.Empty;

        public string RoutesAgeementBinding { get; set; } = string.Empty;

        public string RoutesAgeementUnBinding { get; set; } = string.Empty;

        public string RoutesGetContractInfo { get; set; } = string.Empty;

        public string RoutesAgeementBalance { get; set; } = string.Empty;

        public string RoutesAgeementPay { get; set; } = string.Empty;

        public string RoutesOrderStatus { get; set; } = string.Empty;

        public string RoutesRefund { get; set; } = string.Empty;

        public string RoutesRefundStatus { get; set; } = string.Empty;

        public string RoutesGetListMerchantBanks { get; set; } = string.Empty;
    }
}
