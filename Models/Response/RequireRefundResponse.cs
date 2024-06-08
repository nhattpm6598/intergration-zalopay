using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace Infrastructure.ZaloPay.Models.Response
{
    public class RequireRefundResponse : BaseResponse
    {
        [JsonProperty("refund_id")]
        public long RefundId { get; set; }
    }
}
