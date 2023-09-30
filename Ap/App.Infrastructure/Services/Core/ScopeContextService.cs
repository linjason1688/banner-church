using System;
using App.Application.Common.Interfaces.Services.Core;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Core
{
    /// <summary>
    /// 供此 di scope 提供 identity key
    /// </summary>
    [ScopedService(typeof(IScopeContextService))]
    public class ScopeContextService
        : IScopeContextService
    {
        private readonly Guid txnId;

        public ScopeContextService(
            IServiceProvider provider
        )
        {
            this.txnId = Guid.NewGuid();
        }

        /// <summary>
        /// in the same di scope, the value should be the same
        /// </summary>
        public Guid TransactionId => this.txnId;
    }
}
