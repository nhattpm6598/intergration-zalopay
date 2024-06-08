using Infrastructure.ZaloPay.Models.Requests;
using Infrastructure.ZaloPay.Models.Response;

namespace BE.Eco.Infrastructure.ZaloPay.Features.Abstraction
{
    public interface IContractClient
    {
        Task<ContractBindingOutput> Binding(ContractBindingInput input);

        Task<CancelBindingOutput> Unbinding(CancelBindingInput input);

        Task<ContractBindingInfoOutput> GetInfo(ContractBindingInfoInput input);
    }
}
