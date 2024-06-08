using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;

namespace Eco.Infrastructure.ZaloPay.Models.Response
{
    public class CreateBindingResponse : BaseResponse
    {
        /// <summary>
        /// BindingToken
        /// </summary>
        [JsonProperty("binding_token")]
        public string BindingToken { get; set; } = string.Empty;

        /// <summary>
        /// DeepLink
        /// </summary>
        [JsonProperty("deep_link")]
        public string DeepLink { get; set; } = string.Empty;

        /// <summary>
        /// BlindingQrLink
        /// </summary>
        [JsonProperty("binding_qr_link")]
        public string BindingQrLink { get; set; } = string.Empty;

        /// <summary>
        /// ShortLink
        /// </summary>
        [JsonProperty("short_link")]
        public string ShortLink { get; set; } = string.Empty;
    }
}
