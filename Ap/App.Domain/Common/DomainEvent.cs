using System;

namespace App.Domain.Common
{
    /// <summary>
    /// </summary>
    public class DomainEvent
    {
        public bool IsPublished { get; set; }

        public DateTimeOffset CreatedAt { get; }

        public DomainEvent()
        {
            this.CreatedAt = DateTimeOffset.UtcNow;
        }
    }
}
