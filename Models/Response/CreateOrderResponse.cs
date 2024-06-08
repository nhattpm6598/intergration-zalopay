using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace Eco.Infrastructure.ZaloPay.Models.Response
{
    public class CreateOrderResponse :BaseResponse
    {
        /// <summary>
        /// ZpTransactionToken
        /// </summary>
        [JsonProperty("zp_trans_token")]
        public string ZpTransactionToken { get; set; } = string.Empty;

        /// <summary>
        /// OrderUrl
        /// </summary>
        [JsonProperty("order_url")]
        public string OrderUrl { get; set; } = string.Empty;

        /// <summary>
        /// OrderUrl
        /// </summary>
        [JsonProperty("order_token")]
        public string OrderTransactionToken { get; set; } = string.Empty;
    }
}
