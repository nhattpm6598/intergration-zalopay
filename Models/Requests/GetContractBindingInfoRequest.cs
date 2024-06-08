using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using ZaloPay.Helper.Crypto;

namespace Infrastructure.ZaloPay.Models.Requests
{
    public class GetContractBindingInfoRequest : AppTransactionBaseRequest, IMac
    {
        [JsonProperty("req_date")]
        public long ReqDate { get; set; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.AppTransactionId + "|" + this.ReqDate;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
