namespace Infrastructure.ZaloPay.Models.Dto
{
    public class CancelBindingInput
    {
        public long UserId { get; set; }

        public string ContractId { get; set; } = string.Empty;
    }

    public class CancelBindingOutput : BaseResult
    {
    }

    public class ContractBindingInput
    {
        public long UserId { get; set; }

        public object Data { get; set; } = new();

        public ApplicationType Type { get; set; }

        public BindingType BindingType { get; set; } = BindingType.WALLET;

        public string Channel { get; set; } = string.Empty;

        public string RedirectLink { get; set; } = string.Empty;

        public string CallbackLink { get; set; } = string.Empty;

        public string UserType { get; set; } = string.Empty;

        public long TenantId { get; set; }

    }

    public class ContractBindingOutput : BaseResult
    {
        public string Link { get; set; } = string.Empty;

        public string BindingId { get; set; } = string.Empty;

        public string AppTransactionId { get; set; } = string.Empty;
    }

    public class ContractBindingInfoInput
    {
        public string AppTransactionId { get; set; } = string.Empty;

        public string BindingId { get; set; } = string.Empty;
    }

    public class ContractBindingInfoOutput : BaseResult
    {
        public string PayToken { get; set; } = string.Empty;    

        public string Account { get; set; } = string.Empty; 
    }
}
