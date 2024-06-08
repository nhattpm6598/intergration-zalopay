namespace Infrastructure.ZaloPay.Models.Dto
{

    public class GetBalanceInput
    {
        public string PayToken { get; set; } = string.Empty;

        public long UserId { get; set; }

        public long Amount { get; set; }
    }

    public class GetBalanceOutput : BaseResult
    {
        public string BankCode { get; set; } = string.Empty;

    }
}
