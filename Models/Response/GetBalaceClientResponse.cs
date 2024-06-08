using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace Eco.Infrastructure.ZaloPay.Models.Response
{
    public class GetBalaceClientResponse : BaseResponse
    {
        /// <summary>
        /// Data
        /// </summary>
        [JsonProperty("data")]
        public List<Data> Data { get; set; } = new();

        /// <summary>
        /// discount_amount
        /// </summary>
        [JsonProperty("discount_amount")]
        public int DiscountAmount { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// Channel
        /// </summary>
        [JsonProperty("channel")]
        public int Channel { get; set; }

        /// <summary>
        /// Payable
        /// </summary>
        [JsonProperty("payable")]
        public bool Payable { get; set; }

        /// <summary>
        /// bank_code
        /// </summary>
        [JsonProperty("bank_code")]
        public string BankCode { get; set; } = string.Empty;
    }
}
