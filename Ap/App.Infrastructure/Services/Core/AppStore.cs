using System.Collections.Concurrent;
using App.Domain.Entities.Core;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Core
{
    /// <summary>
    /// </summary>
    [SingletonService]
    public class AppStore
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;


        /// <summary>
        /// 存放 api log
        /// </summary>
        public ConcurrentQueue<ApiAuditLog> ApiLogQueue { get; } = new ConcurrentQueue<ApiAuditLog>();

        public ConcurrentQueue<ExceptionLog> ExceptionLogQueue { get; } = new ConcurrentQueue<ExceptionLog>();

        public AppStore(
            IMapper mapper,
            ILogger<AppStore> logger
        )
        {
            this.mapper = mapper;
            this.logger = logger;
        }
    }
}
