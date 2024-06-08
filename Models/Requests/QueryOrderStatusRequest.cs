using Eco.Infrastructure.ZaloPay.Models.Common;
using ZaloPay.Helper.Crypto;

namespace Infrastructure.ZaloPay.Models.Requests
{
    public class QueryOrderStatusRequest : AppTransactionBaseRequest
    {
        /// <summary>
        /// SetMac
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetMac(string key)
        {
            string macData = this.AppId + "|" + this.AppTransactionId + "|" + key;
            this.Mac = HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key, macData);
        }
    }
}
