using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Infrastructure.ZaloPay.Models.Requests
{
    public class GetMerchantBankRequest : IMac
    {
        /// <summary>
        /// AppId
        /// </summary>
        [Required]
        [JsonProperty("appid")]
        public int AppId { get; set; }

        /// <summary>
        /// ReqTime
        /// </summary>
        [JsonProperty("reqtime")]
        public long ReqTime { get; set; } = Utils.GetTimeStamp();

        /// <summary>
        /// Mac
        /// </summary>
        [Required]
        [JsonProperty("mac")]
        public string Mac { get; set; } = string.Empty;

        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.ReqTime;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
