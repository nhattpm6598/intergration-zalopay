using Eco.Infrastructure.ZaloPay.Options;
using Infrastructure.ZaloPay.Common.Constants;
using Infrastructure.ZaloPay.Common.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Infrastructure.ZaloPay.Features.Common
{
    public interface IGenericClient
    {
        Task<T> PostAsync<T>(string url, IDictionary<string, object>? content);
    }

    public class GenericClient : IGenericClient
    {
        protected readonly ZaloPayOptions _options;
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly ILogger<GenericClient> _logger;

        public GenericClient(IOptions<ZaloPayOptions> options,IHttpClientFactory httpClientFactory, ILogger<GenericClient> logger)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// PostAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ZaloException"></exception>
        public async Task<T> PostAsync<T>(string url, IDictionary<string, object>? content)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                UriBuilder builder = new(url);
                builder.Port = -1;
                builder.Query = await GetQuery(url, content);

                HttpResponseMessage message = await httpClient.PostAsync(builder.ToString(), null);

                string messsageContent = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(messsageContent)) throw new ZaloException(Error.Code.NotFoundResponse, $"PostAsync_{url}: response message {message}");

                return JsonConvert.DeserializeObject<T>(messsageContent)!;
            }
        }

        public async Task<T> PostAsyncV2<T>(string url, IDictionary<string, object>? content)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                StringContent stringContent = new(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                HttpResponseMessage message = await httpClient.PostAsync(url, stringContent);

                string messsageContent = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

                _logger.LogWarning(messsageContent);

                if (string.IsNullOrEmpty(messsageContent)) throw new ZaloException(Error.Code.NotFoundResponse, $"PostAsync_{url}: response message is null");

                return JsonConvert.DeserializeObject<T>(messsageContent)!;
            }
        }

        /// <summary>
        /// GetQuery
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ZaloException"></exception>
        private async Task<string> GetQuery(string url, IDictionary<string, object>? content)
        {
            if (content is null) throw new ZaloException(Error.Code.NotFoundContent, $"PostAsync_{url}: {nameof(content)}");

            Dictionary<string, string> dataStr = new();

            foreach (var item in content)
            {
                dataStr.Add(key: item.Key, value: item.Value?.ToString() ?? "null");
            }

            string query;
            using (var param = new FormUrlEncodedContent(dataStr))
            {
                query = await param.ReadAsStringAsync();
            }

            return query;
        }
    }
}
