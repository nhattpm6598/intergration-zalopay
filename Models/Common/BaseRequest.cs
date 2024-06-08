using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Eco.Infrastructure.ZaloPay.Models.Common
{
    public abstract class BaseRequest
    {
        /// <summary>
        /// AppId
        /// </summary>
        [Required]
        [JsonProperty("app_id")]
        public int AppId { get; set; } 

        /// <summary>
        /// Mac
        /// </summary>
        [Required]
        [JsonProperty("mac")]
        public string Mac { get; set; } = string.Empty;
    }

    public class AppTransactionBaseRequest : BaseRequest
    {

        /// <summary>
        /// AppTransactionId
        /// </summary>
        [JsonProperty("app_trans_id")]
        public string AppTransactionId { get; set; } = string.Empty;

        /// <summary>
        /// SetAppTransactionId
        /// </summary>
        /// <param name="appTransactionId"></param>
        public void SetAppTransactionId(string appTransactionId)
        {
            this.AppTransactionId = DateTime.Now.ToString("yyMMdd") + "_" + appTransactionId;
        }
    }
}
