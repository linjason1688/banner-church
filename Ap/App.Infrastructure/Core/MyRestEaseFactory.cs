#region

using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using RestEase;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Core
{
    /// <summary>
    /// 
    /// </summary>
    [TransientService]
    public class MyRestEaseFactory
    {
        private static readonly int HttpTimeoutSeconds = 120;

        private readonly MyHttpClientHandler httpHandler;

        private readonly AsyncRetryPolicy<HttpResponseMessage> httpRetryPolicy;

        /// <summary>
        /// 
        /// </summary>
        public MyRestEaseFactory(
            ILogger<MyRestEaseFactory> logger,
            MyHttpClientHandler httpHandler
        )
        {
            this.httpHandler = httpHandler;
            this.httpRetryPolicy = Policy
               .HandleResult<HttpResponseMessage>(
                    r =>
                    {
                        var shouldRetry = r.StatusCode is >= HttpStatusCode.BadRequest;

                        if (!shouldRetry)
                        {
                            return false;
                        }

                        // var resBody = r.Content.ReadAsStringAsync().Result;

                        // logger.LogWarning(
                        //     "Retry api({@Status}): {@Url},\n reqBody: {@ReqBody},\n resBody:{@ResBody}",
                        //     r.StatusCode,
                        //     r.RequestMessage?.RequestUri,
                        //     r.RequestMessage?.Content?.ReadAsStringAsync().Result,
                        //     resBody
                        // );

                        logger.LogWarning(
                            "Retry api({@Status}): {@Url}",
                            r.StatusCode,
                            r.RequestMessage?.RequestUri
                        );

                        return true;
                    }
                )
               .WaitAndRetryAsync(
                    1,
                    retryTime => TimeSpan.FromSeconds(retryTime * 5)
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateRestClient<T>(
            string url
        )
        {
            var policyHttpMessageHandler = new PolicyHttpMessageHandler(this.httpRetryPolicy);

            policyHttpMessageHandler.InnerHandler = this.httpHandler;

            var httpClient = new HttpClient(policyHttpMessageHandler)
            {
                BaseAddress = new Uri(url),
                Timeout = TimeSpan.FromSeconds(HttpTimeoutSeconds)
            };

            return RestClient.For<T>(httpClient);
        }
    }
}
