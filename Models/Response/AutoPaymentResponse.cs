using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace Eco.Infrastructure.ZaloPay.Models.Response
{
    public class AutoPaymentResponse : BaseResponse
    {
        /// <summary>
        /// AppTransactionId
        /// </summary>
        [JsonProperty("app_trans_id")]
        public string AppTransactionId { get; set; } = string.Empty;

        /// <summary>
        /// TransactionId
        /// </summary>
        [JsonProperty("zp_trans_id")]
        public string TransactionId { get; set; } = string.Empty;
    }
}
