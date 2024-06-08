using Newtonsoft.Json;

namespace Eco.Infrastructure.ZaloPay.Models.Common
{
    public abstract class BaseResponse
    {
        /// <summary>
        /// ReturnCode
        /// </summary>
        [JsonProperty("return_code")]
        public int ReturnCode { get; set; }

        /// <summary>
        /// ReturnMessage
        /// </summary>
        [JsonProperty("return_message")]
        public string ReturnMessage { get; set; } = string.Empty;

        /// <summary>
        /// SubReturnCode
        /// </summary>
        [JsonProperty("sub_return_code")]
        public int SubReturnCode { get; set; }

        /// <summary>
        /// SubReturnMessage
        /// </summary>
        [JsonProperty("sub_return_message")]
        public string SubReturnMessage { get; set; } = string.Empty;

    }
}
