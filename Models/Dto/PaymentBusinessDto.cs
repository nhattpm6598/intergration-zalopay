namespace Infrastructure.ZaloPay.Models.Dto
{
    public class OrderPaymentInput
    {
        public OrderPaymentUser User { get; set; } = new();

        public OrderPaymentOrder Order { get; set; } = new();

        public string CallBackUrl { get; set; } = string.Empty;

        public string ServiceCallBackUrl { get; set; } = string.Empty;
    }

    public class OrderPaymentOutput : BaseResult
    {
        public string Notes { get; set; } = string.Empty;

        public string TransactionId { get; set; } = string.Empty;

        public string OrderTransactionId { get; set; } = string.Empty;
    }

    public class OrderPaymentUser
    {
        public long TenantId { get; set; }

        public long Id { get; set; }

        public string AppId { get; set; } = string.Empty;

        public string PayToken { get; set; } = string.Empty;
    }

    public class OrderPaymentOrder
    {
        public long Amount { get; set; }

        public string TransactionId { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public List<object> Item { get; set; } = new List<object>();

        public string Code { get; set; } = string.Empty;
    }

}
