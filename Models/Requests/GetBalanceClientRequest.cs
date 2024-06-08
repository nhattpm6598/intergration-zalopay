using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Eco.Infrastructure.ZaloPay.Models.Requests
{
    public class GetBalanceClientRequest : BaseRequest, IMac
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = string.Empty;

        /// <summary>
        /// Identifier
        /// </summary>
        [JsonProperty("pay_token")]
        public string PayToken { get; set; } = string.Empty;

        /// <summary>
        /// OrderRequestDate
        /// </summary>
        [Required]
        [JsonProperty("req_date")]
        public long OrderRequestDate { get; set; } = Utils.GetTimeStamp();

        /// <summary>
        /// Amount
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// SetMac
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.PayToken + "|" + this.Identifier + "|" + this.Amount + "|" + this.OrderRequestDate;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
