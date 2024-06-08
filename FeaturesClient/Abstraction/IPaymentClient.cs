namespace BE.Eco.Infrastructure.ZaloPay.Features.Abstraction
{
    public interface IPaymentClient
    {
        Task<RequirePaymentOutput> RequirePaymentAsync(RequirePaymentInput input);
    }
}
