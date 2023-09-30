using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UAParser;
using Yozian.DependencyInjectionPlus.Attributes;
using Yozian.Extension;

namespace App.Infrastructure.Services.Impl
{
    /// <summary>
    /// </summary>
    [ScopedService(typeof(IClientInfoService))]
    public class ClientInfoService : IClientInfoService
    {
        private static readonly Regex mobileRegex = new Regex(
            string.Join(
                "|",
                new List<string>()
                {
                    @"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal",
                    @"elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge ",
                    @"maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?",
                    @"phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian",
                    @"treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino"
                }
            ),
            RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled
        );

        private static readonly List<string> possibleIpHeaders = new List<string>()
        {
            "HTTP_CLIENT_IP",
            "HTTP_X_FORWARDED_FOR",
            "HTTP_X_FORWARDED",
            "HTTP_FORWARDED_FOR",
            "HTTP_FORWARDED",
            "X-Forwarded-For"
        };

        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly ILogger logger;


        private readonly IMapper mapper;

        public ClientInfoService(
            IMapper mapper,
            ILogger<ClientInfoService> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            this.mapper = mapper;
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;

            var context = httpContextAccessor.HttpContext;

            if (null == context)
            {
                return;
            }

            this.ClientInfo = new ClientRequestInfo()
            {
                ExampleHeaderKeyX = this.getHeaderValueIgnoreCase(context, "X-Example-Key"),
                IpAddress = this.getClientIpAddress(context),
                DeviceInfo = this.DeviceInfo
            };
        }

        public ClientRequestInfo ClientInfo { get; private set; }


        public DeviceInfo DeviceInfo
        {
            get
            {
                var context = this.httpContextAccessor.HttpContext;

                var uaHeader = context.Request
                   .Headers
                   .FirstOrDefault(
                        x => "User-Agent".Equals(x.Key)
                            || "User-Agent".ToLower().Equals(x.Key)
                    );

                var parser = Parser.GetDefault();

                var info = parser.Parse(uaHeader.Value);

                var browser = new DeviceInfo()
                {
                    IsMobileDevice = mobileRegex.IsMatch(uaHeader.Value),
                    IsWindows = info.OS.Family.ToLower().Contains("windows"),
                    OsFamily = info.OS.Family,
                    Browser = info.UA.Family,
                    BrowserMajorVersion = int.Parse(info?.UA?.Major ?? "0"),
                    BrowserFullVersion = $"{info?.UA.Major}.{info?.UA.Minor}.{info?.UA.Patch}",
                    DeviceFamily = info.Device.Family,
                    DeviceBrand = info.Device.Brand,
                    DeviceModel = info.Device.Model
                };

                return browser;
            }
        }
#if DEBUG
        public void SetClientInfo(ClientRequestInfo info)
        {
            this.ClientInfo = info;
        }

#endif


        private string getClientIpAddress(HttpContext context)
        {
            var ipValue = string.Empty;

            foreach (var header in possibleIpHeaders)
            {
                ipValue = this.getHeaderValueIgnoreCase(context, header);

                if (!string.IsNullOrEmpty(ipValue))
                {
                    break;
                }
            }

            if (IPAddress.TryParse(ipValue ?? string.Empty, out var ip))
            {
                return ipValue;
            }

            return context.Connection.RemoteIpAddress.SafeToString();
        }

        private string getHeaderValueIgnoreCase(HttpContext context, string key)
        {
            return context.Request.Headers
               .FirstOrDefault(
                    kv => string.Equals(kv.Key, key, StringComparison.InvariantCultureIgnoreCase)
                )
               .Value;
        }
    }
}
