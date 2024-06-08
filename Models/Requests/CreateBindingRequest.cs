using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Eco.Infrastructure.ZaloPay.Models.Requests
{
    public class CreateBlindingRequest : AppTransactionBaseRequest, IMac
    {
        /// <summary>
        /// OrderRequestDate
        /// </summary>
        [Required]
        [JsonProperty("req_date")]
        public long OrderRequestDate { get; set; } = Utils.GetTimeStamp();

        /// <summary>
        /// MaxAmount
        /// </summary>
        [JsonProperty("max_amount")]
        public int MaxAmount { get; set; }

        /// <summary>
        /// RedirectUrl
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; } = string.Empty;

        /// <summary>
        /// RedirectDeepLink
        /// </summary>
        [JsonProperty("redirect_deep_link")]
        public string RedirectDeepLink { get; set; } = string.Empty;

        /// <summary>
        /// BindingData
        /// </summary>
        [JsonProperty("binding_data")]
        public string BindingData { get; set; } = string.Empty;

        /// <summary>
        /// BindingType
        /// </summary>
        [JsonProperty("binding_type")]
        public string BindingType { get; set; } = string.Empty;

        /// <summary>
        /// CallBackUrl
        /// </summary>
        [JsonProperty("callback_url")]
        public string CallBackUrl { get; set; } = string.Empty;

        /// <summary>
        /// Identifier
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = string.Empty;

        /// <summary>
        /// SetMac
        /// </summary>
        /// <param name="key"></param>
        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.AppTransactionId + "|" + this.BindingData + "|" + this.BindingType + "|" + this.Identifier + "|" + this.MaxAmount + "|" + this.OrderRequestDate;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }

        /// <summary>
        /// SetBindingData
        /// </summary>
        /// <param name="bindingData"></param>
        public void SetBindingData(object bindingData)
        {
            this.BindingData = JsonConvert.SerializeObject(bindingData);
        }
    }
}
