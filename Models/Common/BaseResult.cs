
namespace BE.Eco.Infrastructure.ZaloPay.Models.Common
{
    public class BaseResult
    {
        public Status Status { get; set; }

        public string StatusMessage { get; set; } = string.Empty;
    }

}
