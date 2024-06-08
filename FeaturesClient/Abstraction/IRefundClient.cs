using Infrastructure.ZaloPay.Models.Requests;
using Infrastructure.ZaloPay.Models.Response;

namespace Infrastructure.ZaloPay.FeaturesClient.Abstraction
{
    public interface IRefundClient
    {
        Task<RefundOutput> RefundAsync(RefundInput input);

        Task<QueryRefundOutput> QueryAsync(QueryRefundInput input);
    }
}
