using BE.Eco.Infrastructure.ZaloPay.Common.Enums;
using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Eco.Infrastructure.ZaloPay.Models.Requests
{
    public class CreateOrderRequest : AppTransactionBaseRequest, IMac
    {
        /// <summary>
        /// AppUser
        /// </summary>
        [JsonProperty("app_user")]
        public string AppUser { get; set; } = string.Empty;

        /// <summary>
        /// AppTime
        /// </summary>
        [JsonProperty("app_time")]
        public long AppTime { get; set; } = Utils.GetTimeStamp();

        /// <summary>
        /// Amount
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// CallbackUrl
        /// </summary>
        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; } = string.Empty;

        /// <summary>
        /// RedirectUrl
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; } = string.Empty;

        /// <summary>
        /// DeviceInfo
        /// </summary>
        [JsonProperty("device_info")]
        public string DeviceInfo { get; set; } = string.Empty;

        /// <summary>
        /// Item
        /// </summary>
        [JsonProperty("item")]
        public string Item { get; set; } = string.Empty;

        /// <summary>
        /// SetItem
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(object item) => this.Item = JsonConvert.SerializeObject(item);

        /// <summary>
        /// EmbedData
        /// </summary>
        [JsonProperty("embed_data")]
        public string EmbedData { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="embedData"></param>
        public void SetEmbedData(object embedData) => this.EmbedData = JsonConvert.SerializeObject(embedData);

        /// <summary>
        /// ProductCode
        /// </summary>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; } = nameof(ProductType.AGREEMENT);

        /// <summary>
        /// BankCode
        /// </summary>
        [JsonProperty("bank_code")]
        public string BankCode { get; set; } = string.Empty;

        /// <summary>
        /// Phone
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.AppTransactionId + "|" + this.AppUser + "|" + this.Amount + "|" + this.AppTime + "|" + this.EmbedData + "|" + this.Item;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
