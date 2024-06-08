using Newtonsoft.Json;

namespace Infrastructure.ZaloPay.Models.Response
{
#nullable disable
    public class GetMerchantBankResponse
    {
        /// <summary>
        /// ReturnCode
        /// </summary>
        [JsonProperty("returncode")]
        public int ReturnCode { get; set; }

        /// <summary>
        /// ReturnMessage
        /// </summary>
        [JsonProperty("returnmessage")]
        public string ReturnMessage { get; set; } = string.Empty;
        public Dictionary<int, List<Bank>> Banks { get; set; }
    }



    public class Bank
    {
        public string BankCode { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int PcmId { get; set; }
        public long MinAmount { get; set; }
        public long MaxAmount { get; set; }
    }
}
