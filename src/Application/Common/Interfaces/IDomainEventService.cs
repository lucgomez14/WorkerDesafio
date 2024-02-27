using worker_application.Domain.Common;
using System.Threading.Tasks;

namespace worker_application.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
