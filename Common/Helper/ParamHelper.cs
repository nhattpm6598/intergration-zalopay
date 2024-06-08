using Newtonsoft.Json;

namespace Eco.Infrastructure.ZaloPay.Common.Helper
{
    public static class ParamHelper
    {
        public static IDictionary<string, object>? ParamsDic<T>(this T blinding)
            => JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(blinding));

    }
}
