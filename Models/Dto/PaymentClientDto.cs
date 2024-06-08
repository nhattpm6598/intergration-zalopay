namespace Infrastructure.ZaloPay.Models.Dto
{
    public class RequirePaymentInput
    {
        public string TransactionToken { get; set; } = string.Empty;

        public string PayToken { get; set; } = string.Empty;

        public long UserId { get; set; }    
    }

    public class RequirePaymentOutput : BaseResult
    {
        public string PayTransactionId { get; set; } = string.Empty;
    }
}
