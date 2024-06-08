namespace Infrastructure.ZaloPay.Models.Dto
{
    public class RefundInput
    {
        public string TransactionId { get; set; } = string.Empty;

        public string RefundTransactionId { get; set; } = string.Empty;

        public long Amount { get; set; }

        public string Description { get; set; } = string.Empty;
    }

    public class RefundOutput : BaseResult
    {
        public long RefundId { get; set; }

        public string RefundTransactionId { get; set; } = string.Empty;

        public long ErrorCode { get; set; }

    }

    public class QueryRefundInput
    {
        public string RefundTransactionId { get; set; } = string.Empty;
    }

    public class QueryRefundOutput : BaseResult { }
}
