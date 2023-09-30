using System;

namespace App.Application.Common.Interfaces.Services.Core
{
    public interface IScopeContextService
    {
        /// <summary>
        /// in the same di scope, the value should be the same
        /// </summary>
        Guid TransactionId { get; }
    }
}
