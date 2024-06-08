using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Infrastructure.ZaloPay.Models.Requests
{
    public class QueryRefundRequest : BaseRequest, IMac
    {
        [JsonProperty("m_refund_id")]
        public string RefundId { get; set; } = string.Empty;

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; } = Utils.GetTimeStamp();

        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.RefundId +  "|" + this.Timestamp;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
