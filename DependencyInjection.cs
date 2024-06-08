using BE.Eco.Infrastructure.ZaloPay.Features;
using Infrastructure.ZaloPay.Features;
using Infrastructure.ZaloPay.FeaturesClient;
using Infrastructure.ZaloPay.FeaturesClient.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eco.Infrastructure.ZaloPay
{
    public static class DependecyInjection
    {
        public static IServiceCollection RegisterZaloPay(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ZaloPayOptions>(configuration.GetSection(ZaloPayOptions.Key));

            services.AddHttpClient();

            services.AddTransient<IGenericClient, GenericClient>();

            services.AddTransient<IBalanceClient, BalanceClient>();
            services.AddTransient<IContractClient, ContractClient>();
            services.AddTransient<IOrderClient, OrderClient>();
            services.AddTransient<IPaymentClient, PaymentClient>();
            services.AddTransient<IRefundClient, RefundClient>();
            services.AddTransient<IMerchantBankClient, MerchantBankClient>();

            return services;
        }
    }
}
