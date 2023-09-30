#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Infrastructure.Core.Dtos;
using App.Infrastructure.Dtos.Services;
using App.Infrastructure.Services.Core;
using App.Utility.Extensions;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Core
{
    /// <summary>
    /// 
    /// </summary>
    [TransientService]
    public class MyHttpClientHandler : HttpClientHandler
    {
        private static readonly List<string> availableLogContentTypes = new List<string>()
        {
            "text",
            "html",
            "json",
            "xml"
        };

        private readonly ILogger<MyHttpClientHandler> logger;

        static MyHttpClientHandler()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="auditService"></param>
        public MyHttpClientHandler(
            ILogger<MyHttpClientHandler> logger,
            ApiAuditService auditService
        )
        {
            this.logger = logger;

            this.ServerCertificateCustomValidationCallback = this.validateCertificate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var reqBody = string.Empty;

            if (null != request.Content)
            {
                reqBody = await request.Content.ReadAsStringAsync(cancellationToken);
            }

            var response = await base.SendAsync(request, cancellationToken);

            var resContentType = response.Content.Headers?.ContentType?.MediaType;

            var canLoggedContentType = availableLogContentTypes.Any(
                t => null != resContentType && resContentType.Contains(t)
            );

            var resBody = string.Empty;

            if (canLoggedContentType)
            {
                // automatically read by charset we should register codePages 
                resBody = await response.Content.ReadAsStringAsync(cancellationToken);
            }

            stopWatch.Stop();

            var req = response.RequestMessage;

            var reqHeaders = req.Headers.ToDictionary(kv => kv.Key, kv => kv.Value);

            reqHeaders["Authorization"] = new[]
            {
                "**replaced**"
            };

            var ctx = new ApiCallContext
            {
                ContextId = Guid.NewGuid(),
                DestHost = req?.RequestUri?.Host,
                HttpMethod = req?.Method?.ToString(),
                RequestPath = req?.RequestUri?.AbsolutePath,
                RequestQueryString = req?.RequestUri?.Query,
                RequestHeaders = reqHeaders?.ToJson(),
                ResponseStatusCode = (int) response.StatusCode,
                RequestBody = reqBody,
                ResponseBody = resBody,
                TimeElapsed = stopWatch.ElapsedMilliseconds
            };

            if (ctx.ResponseStatusCode != 200)
            {
                this.logger.LogDebug(
                    "External Api Call Context: {@Context}",
                    new
                    {
                        ctx.ContextId,
                        ctx.TimeElapsed,
                        ctx.ResponseStatusCode,
                        ctx.DestHost,
                        ctx.HttpMethod,
                        ctx.RequestPath,
                        ctx.RequestQueryString,
                        ctx.RequestHeaders,
                        ctx.RequestBody,
                        ctx.ResponseBody
                    }
                );
            }

            return response;
        }

        private bool validateCertificate(
            HttpRequestMessage msg,
            X509Certificate2 X509Certificate2,
            X509Chain X509Chain,
            SslPolicyErrors sslPolicyErrors
        )
        {
            return true;
        }
    }
}
