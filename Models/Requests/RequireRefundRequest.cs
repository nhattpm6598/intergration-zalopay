using Eco.Infrastructure.ZaloPay.Abstraction;
using Eco.Infrastructure.ZaloPay.Models.Common;
using Newtonsoft.Json;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Infrastructure.ZaloPay.Models.Requests
{
    public class RequireRefundRequest : BaseRequest, IMac
    {
        /// <summary>
        /// ID hoàn tiền sẽ được ứng dụng tạo ra. Định dạng: yymmdd_appid_xxxxxxxxxx.
        /// </summary>
        [JsonProperty("m_refund_id")]
        public string RefundId { get; set; } = string.Empty;

        public void SetRefund(string refundTransaction)
        {
            this.RefundId = $"{Utils.GetDateStr()}_{this.AppId}_{refundTransaction}";
        }

        [JsonProperty("zp_trans_id")]
        public string ZPTransactionId { get; set; } = string.Empty;


        [JsonProperty("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Thời điểm (timestamp) khi đơn hoàn tiền được tạo ra, tính bằng mili giây (ms).
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; } = Utils.GetTimeStamp();

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// SetMac
        /// </summary>
        /// <param name="key"></param>
        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.ZPTransactionId + "|" + this.Amount + "|" + this.Description + "|" + this.Timestamp;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
