using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Domain.Primitives
{
    public record DomainEvent(Guid Id) : INotification;
}
