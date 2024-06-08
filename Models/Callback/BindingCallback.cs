using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace Eco.Infrastructure.ZaloPay.Models.Callback
{
    public class BindingCallback : BaseCallback
    {
    }

    public class BindingData
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; } = string.Empty;

        [JsonProperty("app_trans_id")]
        public string AppTransactionId { get; set; } = string.Empty;

        [JsonProperty("binding_data")]
        public string Data { get; set; } = string.Empty;

        [JsonProperty("pay_token")]
        public string PayToken { get; set; } = string.Empty;

        [JsonProperty("zp_user_id")]
        public string ZPUserId { get; set; } = string.Empty;

        [JsonProperty("masked_user_phone")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonProperty("binding_id")]
        public string BindingId { get; set; } = string.Empty;

        [JsonProperty("binding_type")]
        public string BindingType { get; set; } = string.Empty;

        [JsonProperty("server_time")]
        public string ServerTime { get; set; } = string.Empty;

        [JsonProperty("merchant_user_id")]
        public string MerchantUserId { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("msg_type")]
        public string MsgType { get; set; } = string.Empty;

        [JsonProperty("card_id")]
        public string CardId { get; set; } = string.Empty;

        [JsonProperty("masked_card_number")]
        public string MaskedCardNumber { get; set; } = string.Empty;

        [JsonProperty("issuing_bank_logo")]
        public string IssuingBankLogo { get; set; } = string.Empty;

        [JsonProperty("issuing_bank_name")]
        public string IssuingBankName { get; set; } = string.Empty;
    }

    public class MerchantData
    {
        public string UserId { get; set; } = string.Empty;

        public string Channel { get; set; } = string.Empty;

        public string UserType { get; set; } = string.Empty;

        public string TenantId { get; set; } = string.Empty;
    }
}
