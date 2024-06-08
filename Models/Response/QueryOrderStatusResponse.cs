namespace Infrastructure.ZaloPay.Models.Response
{
    #nullable disable
    public class QueryOrderStatusResponse
    {
        /// <summary>
        /// ReturnCode
        ///1 - SUCCESS
        ///2 - FAIL
        ///3 - PROCESSING
        /// </summary>
        public int return_code { get; set; }
        public string return_message { get; set; }
        public int sub_return_code { get; set; }
        public string sub_return_message { get; set; }
        public bool is_processing { get; set; }
        public int amount { get; set; }
        public long zp_trans_id { get; set; }
        public long server_time { get; set; }
        public int discount_amount { get; set; }
    }
}
