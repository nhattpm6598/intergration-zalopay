namespace Infrastructure.ZaloPay.Features.Abstraction
{
    public interface IOrderClient
    {
        Task<CreateOrderOutput> CreateAsync(CreateOrderInput Input);

        Task<GetOrderStatusOutput> GetStatusAsync(GetOrderStatusInput input);   
    }
}
