using System;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces.Services.Core;
using App.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Core
{
    /// <summary>
    /// </summary>
    [ScopedService(typeof(IDomainEventService))]
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger logger;
        private readonly IMediator mediator;

        public DomainEventService(
            ILogger<DomainEventService> logger,
            IMediator mediator
        )
        {
            this.logger = logger;
            this.mediator = mediator;
        }


        public async Task Publish(DomainEvent domainEvent)
        {
            this.logger.LogDebug("Publishing domain event. Event - {@Event}", domainEvent.GetType().Name);
            await this.mediator.Publish(this.GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification) Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()),
                domainEvent
            );
        }
    }
}
