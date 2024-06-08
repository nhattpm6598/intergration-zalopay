using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace Infrastructure.ZaloPay.Models.Response
{
    public class GetContractBindingInfoResponse : BaseResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; } = new();
    }

    public class Data
    {
        [JsonProperty("app_id")]
        public long AppId { get; set; }

        [JsonProperty("app_trans_id")]
        public string AppTransId { get; set; } = string.Empty;

        [JsonProperty("binding_id")]
        public string BindingId { get; set; } = string.Empty;

        [JsonProperty("pay_token")] 
        public string PayToken { get; set; } = string.Empty;

        [JsonProperty("server_time")]
        public long ServerTime { get; set; }

        [JsonProperty("merchant_user_id")]
        public string MerchantUserId { get; set; } = string.Empty;

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("msg_type")]
        public long MsgType { get; set; }

        [JsonProperty("zp_user_id")]
        public string ZpUserId { get; set; } = string.Empty;

        [JsonProperty("masked_user_phone")]
        public string MaskedUserPhone { get; set; } = string.Empty;
    }
}
