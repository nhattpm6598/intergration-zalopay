using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace BE.Eco.Infrastructure.ZaloPay.Models.Requests
{
    public class CancelBindingRequest : BaseRequest, IMac
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = string.Empty;

        /// <summary>
        /// Identifier
        /// </summary>
        [JsonProperty("binding_id")]
        public string BindingId { get; set; } = string.Empty;

        /// <summary>
        /// OrderRequestDate
        /// </summary>
        [Required]
        [JsonProperty("req_date")]
        public long OrderRequestDate { get; set; } = Utils.GetTimeStamp();

        /// <summary>
        /// SetMac
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.Identifier + "|" + this.BindingId + "|" + this.OrderRequestDate;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
