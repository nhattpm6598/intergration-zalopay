namespace Infrastructure.ZaloPay.Models.Dto
{

    public class CreateOrderInput
    {
        public string BankCode { get; set; } = string.Empty;

        public string AppUserId { get; set; } = string.Empty;
        
        public string PayToken { get; set; } = string.Empty;
        
        public string TransactionId { get; set; } = string.Empty;
        
        public long Amount { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public List<object> Item { get; set; } = new();
        
        public object EmbedData { get; set; } = new();
        
        public long TenantId { get; set; }
        
        public long UserId { get; set; }

        public string CallbackUrl { get; set; } = string.Empty;

        public BindingType BindingType { get; set; }
    }

    public class CreateOrderOutput : BaseResult
    {
        public string TransactionToken { get; set; } = string.Empty;

        public string OrderTransactionId { get; set; } = string.Empty;

        public string OrderPaymentUrl { get; set; } = string.Empty;

        public string OrderToken { get; set; } = string.Empty;
    }

    public class GetOrderStatusInput
    {
        public string OrderTransactionId { get; set; } = string.Empty;
    }

    public class GetOrderStatusOutput : BaseResult
    {
        /// <summary>
        ///1 - SUCCESS
        ///2 - FAIL
        ///3 - PROCESSING
        /// </summary>
        public int StatusOrders { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// refund transaction
        /// </summary>
        public string RefundTransactionToken { get; set; } = string.Empty;
    }
}
