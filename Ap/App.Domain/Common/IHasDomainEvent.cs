using System.Collections.Generic;

namespace App.Domain.Common
{
    /// <summary>
    /// </summary>
    public interface IHasDomainEvent
    {
        public IList<DomainEvent> DomainEvents { get; }
    }
}
