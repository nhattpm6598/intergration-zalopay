namespace Infrastructure.ZaloPay.Features.Abstraction
{
    public interface IBalanceClient
    {
        Task<GetBalanceOutput> GetAsync(GetBalanceInput input);
    }
}
