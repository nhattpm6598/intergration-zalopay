using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Eco.Infrastructure.ZaloPay.Models.Requests
{
    public class AutoPaymentRequest : BaseRequest, IMac
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = string.Empty;

        /// <summary>
        /// TransactionToken
        /// </summary>
        [JsonProperty("zp_trans_token")]
        public string TransactionToken { get; set; } = string.Empty;

        /// <summary>
        /// PayToken
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
        /// SetMac
        /// </summary>
        /// <param name="key"></param>
        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.Identifier + "|" + this.TransactionToken + "|" + this.PayToken + "|" + this.OrderRequestDate;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
