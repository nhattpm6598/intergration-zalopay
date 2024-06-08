using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace BE.Eco.Infrastructure.ZaloPay.Models.Callback
{
    public class PaymentCallback : BaseCallback
    {
    }

    public class PaymentData
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; } = string.Empty;

        [JsonProperty("app_trans_id")]
        public string AppTransactionId { get; set; } = string.Empty;

        [JsonProperty("app_time")]
        public string AppTime { get; set; } = string.Empty;

        [JsonProperty("app_user")]
        public string AppUser { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("embed_data")]
        public string EmbedData { get; set; } = string.Empty;

        [JsonProperty("item")]
        public string Item { get; set; } = string.Empty;

        [JsonProperty("zp_trans_id")]
        public string ZPTransactionId { get; set; } = string.Empty;

        [JsonProperty("server_time")]
        public double ServerTime { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonProperty("merchant_user_id")]
        public string MerchantUserId { get; set; } = string.Empty;

        [JsonProperty("zp_user_id")]
        public string ZPUserId { get; set; } = string.Empty;

        [JsonProperty("user_fee_amount")]
        public int UserFeeAmount { get; set; }

        [JsonProperty("discount_amount")]
        public int DiscountAmount { get; set; } 
    }

    public class PaymentEmbedData
    {
        public string OrderCode { get; set; } = string.Empty;

        public string TenantId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public string CallBackUrl { get; set; } = string.Empty;

        [JsonProperty("zlppaymentid")]
        public string ZLPPaymentId { get; set; } = string.Empty;  
    }
}
