using System.Threading.Tasks;
using App.Domain.Common;

namespace App.Application.Common.Interfaces.Services.Core
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
