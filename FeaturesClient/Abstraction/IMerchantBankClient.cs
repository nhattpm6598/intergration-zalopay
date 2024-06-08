using Infrastructure.ZaloPay.Models.Response;

namespace Infrastructure.ZaloPay.FeaturesClient.Abstraction
{
    public interface IMerchantBankClient
    {
        Task<GetMerchantBankResponse> GetAsync();
    }
}
