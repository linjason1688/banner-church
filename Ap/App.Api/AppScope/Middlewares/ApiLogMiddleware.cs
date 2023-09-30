#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Application.Common.Dtos;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiLogMiddleware
    {
        private static readonly Dictionary<string, bool> availableContentTypes = new Dictionary<string, bool>()
        {
            {
                "application/json", true
            },
            {
                "application/xml", true
            }
        };

        private static readonly Regex contentTypeRegex = new Regex(@"\w{1,}\/\w{1,}");

        private readonly RequestDelegate next;
        private readonly ILogger<ApiLogMiddleware> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ApiLogMiddleware(RequestDelegate next, ILogger<ApiLogMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public async Task InvokeAsync(HttpContext context /* other dependencies */)
        {
            var request = context.Request;

            if (!request.Path.StartsWithSegments(new PathString("/api")))
            {
                await this.next(context);

                return;
            }

            try
            {
                await this.ProcessExecutionLoggingAsync(context);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private async Task<string> ReadAsStringAsync(Stream stream)
        {
            return await new StreamReader(stream, Encoding.UTF8).ReadToEndAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private async Task ProcessExecutionLoggingAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();

            var handledId = context.GetRequestHandledId();

            var request = context.Request;

            // request body log
            string bodyContent;

            // we should ignore charset hint & safe retrieve contentType (nullable);
            var match = contentTypeRegex.Match(request.ContentType.SafeToString().ToLower());
            var contentType = match.Value;

            if (availableContentTypes.ContainsKey(contentType) && availableContentTypes[contentType])
            {
                request.EnableBuffering();

                var stream = request.Body;
                bodyContent = await this.ReadAsStringAsync(stream);

                // renew as stream for body
                stream = new MemoryStream(Encoding.UTF8.GetBytes(bodyContent));
                stream.Seek(0, SeekOrigin.Begin);
                request.Body = stream;
            }
            else
            {
                bodyContent = $"**un-supported body content! ({contentType})";
            }

            // prepare to log response body
            var response = context.Response;

            var originalResponseStream = response.Body;

            var responseStream = new MemoryStream();

            context.Response.Body = responseStream;

            try
            {
                await this.next(context);
            }
            finally
            {
                var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
                var ignoreBodyAttr = endpoint?.Metadata.GetMetadata<ApiLogIgnoreBodyAttribute>();

                var shouldIgnoreRequestBodyLog = ignoreBodyAttr?.IgnoreRequestBody;
                var shouldIgnoreResponseBodyLog = ignoreBodyAttr?.IgnoreResponseBody;

                //
                if (shouldIgnoreRequestBodyLog.HasValue && shouldIgnoreRequestBodyLog.Value)
                {
                    bodyContent = $"**body content ignore by {nameof(ApiLogIgnoreBodyAttribute)}!";
                }

                string responseBody;

                responseStream.Seek(0, SeekOrigin.Begin);

                if (shouldIgnoreResponseBodyLog.HasValue && shouldIgnoreResponseBodyLog.Value)
                {
                    responseBody = $"**body content ignore by {nameof(ApiLogIgnoreBodyAttribute)}!";
                }
                else
                {
                    responseBody = await this.ReadAsStringAsync(responseStream);
                }

                // reset to begin
                responseStream.Seek(0, SeekOrigin.Begin);

                await responseStream.CopyToAsync(originalResponseStream);

                watch.Stop();

                var info = new ApiActionInfo()
                {
                    HandledId = handledId,
                    SourceIp = context.GetClientIpAddress(),
                    HttpMethod = request.Method,
                    RequestPath = request.Path.ToString(),
                    RequestQueryString = request.QueryString.ToUriComponent(),
                    RequestBody = bodyContent,
                    ResponseStatusCode = response.StatusCode,
                    ResponseBody = responseBody,
                    RequestHeaders = string.Join(
                        "\n",
                        request.Headers
                           .Where(x => !string.Equals(x.Key, "Cookie", StringComparison.InvariantCulture))
                           .Select(x => $"{x.Key}={x.Value}")
                    ),
                    TimeElapsed = watch.ElapsedMilliseconds
                };

                var skipApiLogAttr = endpoint?.Metadata.GetMetadata<SkipApiLogAttribute>();

                if (null != skipApiLogAttr)
                {
                    this.logger.LogDebug(
                        "Skip ApiLog by {@Attr} for path: {@RequestPath}",
                        nameof(SkipApiLogAttribute),
                        info.RequestPath
                    );
                }
                else
                {
                    // save for api audit log
                    var auditService = context.RequestServices.GetService<ApiAuditService>();

                    if (null != auditService)
                    {
                        auditService.AddLog(info);
                    }
                    else
                    {
                        this.logger.LogDebug("{@Info}", info);
                    }
                }
            }
        }
    }
}
