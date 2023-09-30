using App.Domain.Common;
using MediatR;

namespace App.Application.Common.Dtos
{
    /// <summary>
    /// </summary>
    public class DomainEventNotification<TDomainEvent> : INotification
        where TDomainEvent : DomainEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public TDomainEvent DomainEvent { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainEvent"></param>
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            this.DomainEvent = domainEvent;
        }
    }
}
